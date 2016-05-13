using UnityEngine;
using System.Collections;

public class Gonta: PlayerBase {

	// Use this for initialization
	override protected void Setup(){
		speedX = 4;
		speedY = 3;
		length = 6;
		pow = 8;
	}
	override protected void HitBallEnter(Ball b){
		if (b.RetDir().y == 0) {
			b.PointChange(5);
			EventManager.Invoke(ref EventManager.GontaShot);
		} 
	}
	override protected void HitBallStay(Ball b){
		if (b.RetDir().y == 0) {
			b.PointChange(5);
		} 
	}
}
