using UnityEngine;
using System.Collections;

public class Xax : PlayerBase {
	[SerializeField]GameObject preshadow;
	GameObject shadow;
	Vector3 shadowRelPos;
	// Use this for initialization
	override protected void Setup(){
		speedX = 3;
		speedY = 8;
		length = 3;
		pow = 5;
		shadowRelPos = new Vector3 (0,0,0);
		shadow = (GameObject)Instantiate (preshadow,transform.position + shadowRelPos,Quaternion.identity);
	}
	override protected void SetupAfter(){
		shadow.transform.localScale = new Vector3 (5, length, 1);
		shadow.GetComponent<XaxShadow>().Set(playerNumber,pow);
	}
	override protected void UpdateAfter(){
		shadow.GetComponent<XaxShadow>().UpdatePreSpd(preSpd);
		MoveShadow ();
	}
	void MoveShadow(){
		if (key.right > 0) {
			if (shadowRelPos.x < 0.9f)
				shadowRelPos.x += 0.1f;
		} else {
			if (shadowRelPos.x > 0)
				shadowRelPos.x -= 0.1f;
		}

		if (key.left > 0) {
			if(shadowRelPos.x > -0.9f)shadowRelPos.x -=0.1f;
		}else {
			if (shadowRelPos.x < 0)
				shadowRelPos.x += 0.1f;
		}
		if (key.down > 0) {
			if(shadowRelPos.y > -1.5f)shadowRelPos.y -=0.3f;
		}else {
			if (shadowRelPos.y < 0)
				shadowRelPos.y += 0.1f;
		}
		if (key.up > 0) {
			if(shadowRelPos.y < 1.5f)shadowRelPos.y +=0.3f;
		}else {
			if (shadowRelPos.y > 0)
				shadowRelPos.y -= 0.1f;
		}
		if (shadowRelPos.y < 0.1f && shadowRelPos.y > -0.1f) {
			shadowRelPos.y = 0;
		}
		if (shadowRelPos.x < 0.1f && shadowRelPos.x > -0.1f) {
			shadowRelPos.x = 0;
		}
		shadow.transform.position = transform.position + shadowRelPos;
	}
	void OnDisable(){

			if(shadow!=null)Destroy(shadow.gameObject);
	}
}
