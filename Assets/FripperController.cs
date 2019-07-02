using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 「発展課題：スマートフォンでも動かせるようにマルチタッチに対応しましょう」のために
 * public SetAngle(bool isOrigine)を追加 isOrigine==trueでSetAngle(this.defaultAngle)を呼び出す
 */

public class FripperController : MonoBehaviour {
    //HingeJointコンポーネント
    private HingeJoint myHingeJoint;

    //初期の傾き
    private float defaultAngle = 20.0f;
    //弾いた時の傾き
    private float flickAngle = -20.0f;


	// Use this for initialization
	void Start () {
        //HingeJointコンポーネント取得
        this.myHingeJoint = GetComponent<HingeJoint>();

        //フリッパーの傾きを設定
        SetAngle(this.defaultAngle);

	}
	
	// Update is called once per frame
	void Update () {
		
        //左矢印キーを押した時左フリッパーを動かす
        if(Input.GetKeyDown(KeyCode.LeftArrow) && this.tag == "LeftFripperTag")
        {
            SetAngle(this.flickAngle);
        }
        //右矢印キーを押した時右フリッパーを動かす
        if(Input.GetKeyDown(KeyCode.RightArrow) && this.tag == "RightFripperTag")
        {
            SetAngle(this.flickAngle);
        }

        //矢印キー離されたときフリッパーを元に戻す
        if (Input.GetKeyUp(KeyCode.LeftArrow) && this.tag == "LeftFripperTag")
        {
            SetAngle(this.defaultAngle);
        }
        if (Input.GetKeyUp(KeyCode.RightArrow) && this.tag == "RightFripperTag")
        {
            SetAngle(this.defaultAngle);
        }


    }

    //フリッパーの傾きを設定
    public void SetAngle(float angle)
    {
        //spring、damperは丸ごとコピー
        JointSpring jointSpr = this.myHingeJoint.spring;
        jointSpr.targetPosition = angle;
        this.myHingeJoint.spring = jointSpr;
    }

    //20190702追加
    //発展課題用
    public void SetAngle(bool isOrigine)
    {
        float angle = (isOrigine == true ? this.defaultAngle : this.flickAngle);
        SetAngle(angle);
    }

}
