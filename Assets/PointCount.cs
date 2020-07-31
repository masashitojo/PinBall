using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointCount : MonoBehaviour {
	//得点を表示するテキスト
	private GameObject pointText;
	//
	private int gamePoint=0;

	// Use this for initialization
	void Start () {
		//シーン中のPointTextオブジェクトを取得
		this.pointText = GameObject.Find("PointText");
	}
	
	// Update is called once per frame
	void Update () {

	}

	//衝突時に呼ばれる関数
	void OnCollisionEnter(Collision collision){
		if (collision.gameObject.tag == "SmallStarTag") {
			this.gamePoint += 100;
		} else if (collision.gameObject.tag == "LargeStarTag") {
			this.gamePoint += 10;
		} else if (collision.gameObject.tag == "SmallCloudTag" || collision.gameObject.tag == "LargeCloudTag") {
			this.gamePoint += 1;
		}

		//PointTextに得点を表示
		this.pointText.GetComponent<Text>().text=gamePoint.ToString();
	}
}
