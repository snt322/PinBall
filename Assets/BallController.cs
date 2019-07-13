using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour {

    //ボールが見える可能性のあるz軸の最大値
    private float visiblePosZ = -6.5f;

    //ゲームおオーバを表示するテキスト
    private GameObject gameoverText;


	// Use this for initialization
	void Start () {
        //シーン中のGameOverTextオブジェクトを取得
        this.gameoverText = GameObject.Find("GameOverText");
	}
	
	// Update is called once per frame
	void Update () {
		//ボールが画面外に出た場合
        if(this.transform.position.z < this.visiblePosZ)
        {
            //GameoverTextのサイズをスクリーンサイズに自動変更
            int width = Screen.width;
            int height = Screen.height;

            RectTransform rTform = this.gameoverText.GetComponent<RectTransform>() as RectTransform;
            rTform.sizeDelta = new Vector2((float)width, (float)height/5);

            this.gameoverText.GetComponent<Text>().resizeTextForBestFit = true;         //テキスト表示領域に文字サイズを自動フィットする

            //GameoverTextにゲームオーバを表示
            this.gameoverText.GetComponent<Text>().text = "Game Over";

            //練習：this.gameoverText.GetComponent<Text> ().text = "Game Over";の右辺の文字列を変更するとGameOvreTextの表示が変わることを確認してみましょう
 //           this.gameoverText.GetComponent<Text>().text = "Game Clear";
        }
    }
}
