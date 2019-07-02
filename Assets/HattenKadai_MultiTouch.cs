using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 20190702
 * 参考URL https://docs.unity3d.com/ja/current/Manual/MobileInput.html
 * 
 * 気になる点
 * GUILabelを使用するとUnityRemoteが正常に作動しない?
 */

public class HattenKadai_MultiTouch : MonoBehaviour {

    //デバッグ用メッセージ
    string mMessage = "debug";


    //タッチパネルの左右どちらをタッチしたかを表す列挙体
    enum enumTouchArea
    {
        None = 0,
        Right,
        Left,
    }

    //FripperControllerスクリプト
    FripperController mLFScript = null;
    FripperController mRFScript = null;

    UnityEngine.UI.Text mDebugText = null;

    // Use this for initialization
    void Start ()
    {
        GameObject tmpTObj = GameObject.Find("HattenKadai_DebugText") as GameObject;
        if(tmpTObj)
        {
            mDebugText = tmpTObj.GetComponent<UnityEngine.UI.Text>() as UnityEngine.UI.Text;
        }

        GameObject tmpObj = null;

        tmpObj = GameObject.Find("RightFripper") as GameObject;
        if (tmpObj)
        {
            mRFScript = tmpObj.GetComponent<FripperController>() as FripperController;         //FripperControllerスクリプトの取得
        }

        tmpObj = GameObject.Find("LeftFripper") as GameObject;
        if (tmpObj)
        {
            mLFScript = tmpObj.GetComponent<FripperController>() as FripperController;          //FripperControllerスクリプトの取得
        }

        //タッチ入力に対応しているかチェック
        if (Input.touchSupported == true)
        {
            mMessage = "タッチパネルサポート";

            Input.multiTouchEnabled = true;
        }

        Input.multiTouchEnabled = true;

        mDebugText.text = mMessage;

    }
	
	// Update is called once per frame
	void Update ()
    {
        GetTouch();
        mDebugText.text = mMessage;
    }

    /*
     * 20190702 GUIを使用するUnityRemoteが正常に作動しない?
     * 
    //デバッグ用出力
    void OnGUI()
    {
        Rect rt = new Rect(0,0, 500, 300);
        GUIStyle style = new GUIStyle();

        style.fontSize = 200;

        GUI.Label(rt, mMessage, style);

    }
    */

    //タップした場所を取得する
    void GetTouch()
    {
        /*
         * 複数の指がどこを画面上のどこを触れたか確認する
         * 例えば、複数の指が画面右側を触れた場合、右側を触れた指が、
         * ①全て離れたら右フリッパが元に戻るようにする
         * ②全て画面右側から出たらフリッパが元に戻るようにする
         * ③ドラッグしたまま画面右側から左側にすべてのタッチが移動した場合、右フリッパは元に戻り、左フリッパが動く
         * 画面右側をはじめに触れた指が画面左側に移動しても右フリッパのみが動くようにする
         */


        if (Input.touchCount == 0)
        {   //画面をタッチしていない場合
            mLFScript.SetAngle(true);                 //左フリッパの角度をもとに戻す
            mRFScript.SetAngle(true);                 //右フリッパの角度をもとに戻す
        }
        else
        {
            /*
             *  画面をタッチした場合 
             */
            Touch[] touches = Input.touches;        //タッチした指の情報を取得

            float screenWidth = (float)Screen.width;         //スクリーンの幅
            float screenCenter = screenWidth / 2;    //スクリーンの中心座標 X成分


            bool isLFripperOrigine = true;
            bool isRFripperOrigine = true;
            
            foreach (Touch t in touches)
            {
                switch (t.phase)
                {
                    case TouchPhase.Began:      //タッチがスクリーンに触れた場合
                    case TouchPhase.Ended:      //タッチがスクリーンを離れる場合
                    case TouchPhase.Moved:      //タッチがスクリーン上を移動する場合
                    case TouchPhase.Stationary:
                    case TouchPhase.Canceled:
                        {
                            float touchPosX = t.position.x;
                            if(touchPosX >= screenCenter)       //タッチが画面右側にある場合
                            {
                                isRFripperOrigine = false;
                            }


                            if(touchPosX < screenCenter)
                            {
                                isLFripperOrigine = false;
                            }
                        }
                        break;
                    default:
                        break;
                }//switch
            }//foreach

            mMessage = string.Format("{0},{1}", isLFripperOrigine, isRFripperOrigine);

            mLFScript.SetAngle(isLFripperOrigine);
            mRFScript.SetAngle(isRFripperOrigine);

        }//else

    }

}
