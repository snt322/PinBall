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
            //GameoberTextにゲームオーバを表示
            this.gameoverText.GetComponent<Text>().text = "Game Over";

            //練習：this.gameoverText.GetComponent<Text> ().text = "Game Over";の右辺の文字列を変更するとGameOvreTextの表示が変わることを確認してみましょう
 //           this.gameoverText.GetComponent<Text>().text = "Game Clear";
        }
    }
}
