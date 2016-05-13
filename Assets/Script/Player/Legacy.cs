using UnityEngine;
using System.Collections;

public class Legacy : PlayerBase {
	bool Awake= false;
	// Use this for initialization
	override protected void Setup(){
		speedX = 3;
		speedY = 5;
		length = 5;
		pow = 5;
	}
	override protected void UpdateAfter(){
		if(playerNumber == 1){
		if(ScoreManager.score2 >=6 && Awake == false){
				speedX+=1;
				int r = Random.Range(0,3);
				if(r == 0){
					speedY+=3;
				}
				if(r == 1){
					length+=3;
					transform.localScale = new Vector3(5,length,1);
				}
				if(r == 2){
					pow+=3;
				}
				Awake = true;
			}
		}
		if(playerNumber == 2){
			if(ScoreManager.score1 >=6 && Awake == false){
				speedX+=1;
				int r = Random.Range(0,3);
				if(r == 0){
					speedY+=3;
				}
				if(r == 1){
					length+=3;
					transform.localScale = new Vector3(5,length,1);
				}
				if(r == 2){
					pow+=3;
				}
				Awake = true;
			}
		}
	}
}
