using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FripperController : MonoBehaviour {
	//HingeJoinコンポーネントを入れる
	private HingeJoint myHingeJoint;
	//初期の傾き
	private float defaultAngle=20;
	//弾いたときの動き
	private float flickAngle=-20;
	//タップID
	private int firpperID=0;


	// Use this for initialization
	void Start () {
		//HingeJointコンポーネント取得
		this.myHingeJoint= GetComponent<HingeJoint>();
		Debug.Log ("this="+this+" gameObjecy="+gameObject);

		//フリッパーの傾きを設定
		SetAngle(this.defaultAngle);
	}
	
	// Update is called once per frame
	void Update ()
	{
		//左矢印キーを押したとき、左フリッパーを動かす
		if (Input.GetKeyDown (KeyCode.LeftArrow) && tag == "LeftFripperTag") {
			SetAngle (this.flickAngle);
		}
		//右矢印キーを押したとき、右フリッパーを動かす
		if (Input.GetKeyDown (KeyCode.RightArrow) && tag == "RightFripperTag") {
			SetAngle (this.flickAngle);
		}

		//左矢印キーを離したとき、左フリッパーを元に戻す
		if (Input.GetKeyUp (KeyCode.LeftArrow) && tag == "LeftFripperTag") {
			SetAngle (this.defaultAngle);
		}
		//右矢印キーを離したとき、右フリッパーを元に戻す
		if (Input.GetKeyUp (KeyCode.RightArrow) && tag == "RightFripperTag") {
			SetAngle (this.defaultAngle);
		}

		//発展課題(マルチタッチ)提出2回目
		//Debug.Log ("id="+ t.fingerId +"pha="+t.phase+" pos="+t.position+" wid="+Screen.width/2);
		foreach (Touch t in Input.touches) {
			//画面左側をタップしたとき、左フリッパーを上げる。該当するIDのタップが離されたら下げる。
			if (tag == "LeftFripperTag") {
				if (t.phase == TouchPhase.Began && t.position.x <= (Screen.width / 2)) {
					SetAngle (this.flickAngle);
					firpperID = t.fingerId;
				} else if (t.phase == TouchPhase.Ended && firpperID == t.fingerId) {
					SetAngle (this.defaultAngle);
				}
			}

			//画面右側をタップしたとき、右フリッパーを上げる。該当するIDのタップが離されたら下げる。
			if (tag == "RightFripperTag") {
				if (t.phase == TouchPhase.Began && t.position.x > (Screen.width / 2)) {
					SetAngle (this.flickAngle);
					firpperID = t.fingerId;
				} else if (t.phase == TouchPhase.Ended && firpperID == t.fingerId) {
					SetAngle (this.defaultAngle);
				}
			}

		}
	}
		
	//フリッパーの傾きを設定
	public void SetAngle(float angle){
		JointSpring jointSpr=this.myHingeJoint.spring;
		jointSpr.targetPosition=angle;
		this.myHingeJoint.spring=jointSpr;
	}

}
