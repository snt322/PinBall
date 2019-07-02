using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kadai_Score : MonoBehaviour {

    struct myStructTarget
    {
        private int mScore;
        private string mTag;

        public myStructTarget(int s, string t)
        {
            mScore = s;
            mTag = t;
        }

        public int Score
        {
            get
            {
                return this.mScore;
            }
        }
        public string Tag
        {
            get
            {
                return this.mTag;
            }
        }
    }




    //得点
    int mGameScore = 0;

    //得点になるターゲットの[タブ]と[得点]を格納するリスト
    List<myStructTarget> mTargetList = null;

    //スコアを表示するUIテキストのインスタンス
    UnityEngine.UI.Text mText = null;

    //スコアを表示するUIテキストの名前
    string mTextName = "Kadai_ScoreText";

	// Use this for initialization
	void Start ()
    {
        //スコアを表示するUIテキストを取得する
        GameObject tmpObj = GameObject.Find(mTextName);
        if(tmpObj)
        {
            mText = tmpObj.GetComponent<UnityEngine.UI.Text>() as UnityEngine.UI.Text;
        }

        //スコアを表示するUIテキストのサイズとフォントサイズを初期化する
        InitTextUISize();


        //得点になるターゲットのリストを初期化
        mTargetList = new List<myStructTarget>(2);

        //SmallCloud
        mTargetList.Add(new myStructTarget(10, "SmallStarTag"));
        //LargeCloud
        mTargetList.Add(new myStructTarget(20, "LargeStarTag"));

    }
	
	// Update is called once per frame
	void Update ()
    {
        //スコア・テキストを更新する
        UpdateScoreText();



    }

    //スコアを表示するUIテキストを更新する
    void UpdateScoreText()
    {
        if(mText != null)
        {
            string str = string.Format("SCORE\n {0, 5}pts", mGameScore);
            mText.text = str;
            Debug.Log("is UpdateScoreText() ?");
        }
    }

    //スコアを表示するUIテキストのサイズを画面に合わせて変更する
    void InitTextUISize()
    {
        if (mText != null)
        {
            int screenWidth = Screen.width;
            int screenHeight = Screen.height;

            Canvas tmpCanvas = mText.GetComponentInParent<Canvas>() as Canvas;
            if(tmpCanvas != null)
            {
                RectTransform canvasRect= tmpCanvas.GetComponent<RectTransform>() as RectTransform;
                if(canvasRect != null)
                {
                    canvasRect.sizeDelta = new Vector2(screenWidth, screenHeight);
                }

            }

            screenHeight /= 5;                                          //mTextのクライアント領域の高さをスクリーンの1/5とする
            screenWidth /= 2;                                           //mTextのクライアント領域の幅をスクリーンの1/2とする

            RectTransform rt= mText.rectTransform;                      //
            rt.sizeDelta = new Vector2(screenWidth, screenHeight);      //

            mText.resizeTextForBestFit = true;                          //フォントサイズをmTextのクライアント領域に自動フィットにする
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        string tag = collision.gameObject.tag;

        foreach(myStructTarget target in mTargetList)
        {
            if(target.Tag == tag)
            {
                mGameScore += target.Score;
            }
        }

        Debug.Log(string.Format("GameScore : {0}", mGameScore));

    }
}
