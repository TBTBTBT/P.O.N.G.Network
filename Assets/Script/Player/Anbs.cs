using UnityEngine;
using System.Collections;

public class Anbs: PlayerBase {
	[SerializeField]GameObject preSvt;
	GameObject[] svt = new GameObject[4];
	Vector3[] svtPos = new Vector3[4];
	Vector3[] svtRelPos = new Vector3[4];
	// Use this for initialization
	override protected void Setup(){
		speedX = 6;
		speedY = 4;
		length = 5;
		pow = 6;
		svtRelPos [0] = new Vector3 (-0.15f,0.5f,0);
		svtRelPos [1] = new Vector3 (0.15f,0.5f,0);
		svtRelPos [2] = new Vector3 (-0.15f,-0.5f,0);
		svtRelPos [3] = new Vector3 (0.15f,-0.5f,0);
		for (int i=0; i<4; i++) {
			if(preSvt!=null){
				svt[i] = (GameObject)Instantiate(preSvt,transform.position + svtRelPos[i],Quaternion.identity);
			}
		}

	}
	override protected void SetupAfter(){
		for (int i=0; i<4; i++) {
			if(preSvt!=null){
				svt[i].transform.localScale = new Vector3 (5, length*1.5f, 1);
				svt[i].GetComponent<AnbsSvt>().Set(playerNumber,pow);
			}
		}
		
	}
	override protected void UpdateAfter(){
		MoveSvt ();
		FixPosSvt ();
		for (int i=0; i<4; i++) {
			if(preSvt!=null){
				svt[i].GetComponent<AnbsSvt>().UpdatePreSpd(preSpd);
			}
		}
	}
	void MoveSvt(){
		for (int i=0; i<4; i++) {
			if (i >= 2){
				if (key.up == 0 &&key.down == 0) {
					svt[i].transform.position += new Vector3(0,0.1f,0);
			}
				if(key.down >0 ){
					svt[i].transform.position += new Vector3(0,preSpd.y * speedY / 30,0);
				}

		}
			if (i < 2){
				if (key.up == 0 &&key.down == 0) {
					svt[i].transform.position += new Vector3(0,-0.1f,0);
				}
				if(key.up >0 ){
					svt[i].transform.position += new Vector3(0,preSpd.y * speedY / 30,0);
				}
				
		}
		if (i % 2 == 0) {
				if (key.right == 0&&key.left == 0) {
				svt[i].transform.position += new Vector3(0.1f,0,0);
			}
				if(key.left >0 ){
					svt[i].transform.position += new Vector3(preSpd.x * speedX / 30,0,0);
				}

		}
		if (i % 2 == 1) {
				if (key.left == 0&&key.right == 0) {
					svt[i].transform.position += new Vector3(-0.1f,0,0);
				}
				if(key.right >0 ){
					svt[i].transform.position += new Vector3(preSpd.x * speedX / 30,0,0);
				}
		}
		}
		/*
		for (int i=0; i<2; i++) {
		if (key.up > 0) {
				if(svt[i].transform.position.y < topRight.y - length * 0.3f / 2)svtPos [i].y+=0.1f;
		} else {
				if(svtPos [i].y>0.5f)svtPos [i].y-=0.1f;
		}
		}
		for (int i=2; i<4; i++) {
		if (key.down > 0) {
				if(svt[i].transform.position.y > bottomLeft.y + length * 0.3f / 2)svtPos [i].y-=0.1f;
		} else {
				if(svtPos [i].y<-0.5f)svtPos [i].y+=0.1f;
		}
		}
		for (int i=0; i<4; i++) {
			if (i % 2 == 1) {
				if (key.left > 0) {
					svtPos [i].x+=0.15f;
				}else{
					if(svtPos [i].x>0.15f)svtPos [i].x-=0.1f;
				}
			}
		}
		for (int i=0; i<4; i++) {
			if(svt[i]!=null)svt[i].transform.position = svtPos[i];
		}*/
	}
	void FixPosSvt(){
		for (int i=0; i<4; i++) {
		
			if(i%2==0){
				if(svt[i].transform.position.x>transform.position.x + svtRelPos[i].x){
					svt[i].transform.position = new Vector3 (transform.position.x + svtRelPos[i].x, svt[i].transform.position.y, svt[i].transform.position.z);
				}
			}
			if(i%2==1){
				if(svt[i].transform.position.x<transform.position.x + svtRelPos[i].x){
					svt[i].transform.position = new Vector3 (transform.position.x + svtRelPos[i].x, svt[i].transform.position.y, svt[i].transform.position.z);
				}
			}
			if(i<2){
				if (svt[i].transform.position.y < transform.position.y +svtRelPos[i].y) {
					svt[i].transform.position = new Vector3 (svt[i].transform.position.x,transform.position.y +svtRelPos[i].y, svt[i].transform.position.z);
				}
			}
			if(i>=2){
				if (svt[i].transform.position.y > transform.position.y +svtRelPos[i].y) {
					svt[i].transform.position = new Vector3 (svt[i].transform.position.x,transform.position.y +svtRelPos[i].y, svt[i].transform.position.z);
				}
			}
			if (svt[i].transform.position.x > topRight.x) {
				svt[i].transform.position = new Vector3 (topRight.x, svt[i].transform.position.y, svt[i].transform.position.z);
			}
			if (svt[i].transform.position.x < bottomLeft.x) {
				svt[i].transform.position = new Vector3 (bottomLeft.x, svt[i].transform.position.y, svt[i].transform.position.z);
			}
			if (svt[i].transform.position.y < bottomLeft.y + length * 0.3f / 2) {
				svt[i].transform.position = new Vector3 (svt[i].transform.position.x, bottomLeft.y + length * 0.3f / 2, svt[i].transform.position.z);
			}
			if (svt[i].transform.position.y > topRight.y - length * 0.3f / 2) {
				svt[i].transform.position = new Vector3 (svt[i].transform.position.x, topRight.y - length * 0.3f / 2, svt[i].transform.position.z);
			}
		}
		
	}
	void OnDisable(){
		for (int i=0; i<4; i++) {
			if(svt[i]!=null)Destroy(svt[i].gameObject);
		}
	}
}
