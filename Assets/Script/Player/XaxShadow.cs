using UnityEngine;
using System.Collections;
[RequireComponent (typeof(Rigidbody2D))]
public class XaxShadow : MonoBehaviour {
	int playerNumber;
	int pow;
	Vector2 preSpd;
	// Use this for initialization
	public void Set (int pn,int p) {
		playerNumber = pn;
		pow = p;
	}
	public void UpdatePreSpd (Vector2 ps){
		preSpd = ps;
	}
	void OnTriggerEnter2D(Collider2D c){
		
		if (c.tag == "Ball") {
			Ball b = c.transform.GetComponent<Ball>();
			if (b != null) {
				Vector2 direction = new Vector2(0,preSpd.y);
				float fixPow = pow;
				if(playerNumber == 2){
					direction.x = -1;
					if(preSpd.x >= 0){
						direction.x = -0.2f;
					}
				}
				if(playerNumber == 1){
					direction = new Vector2(1,preSpd.y);
					if(preSpd.x <= 0){
						direction.x = 0.2f;
					}
					
				}
				if(preSpd.y==0){
					if(Mathf.Abs(transform.position.y - c.transform.position.y)>0.2f){
						if(transform.position.y<=c.transform.position.y){
							direction.y = 0.5f;
						}
						if(transform.position.y>=c.transform.position.y){
							direction.y = -0.5f;
						}
					}
				}
				b.SpeedAndDirection(fixPow,direction);
				b.PointChange(1);
			}
		}
	}
	void OnTriggerStay2D(Collider2D c){
		if (c.tag == "Ball") {
			Ball b = c.transform.GetComponent<Ball>();
			if (b != null) {
				Vector2 direction = b.RetDir();
				float fixPow = pow;
				if(playerNumber == 2){
					if(preSpd.x < 0 ){
						direction = new Vector2(-1,b.RetDir().y);
					}
				}
				if(playerNumber == 1){
					if(preSpd.x > 0 ){
						direction = new Vector2(1,b.RetDir().y);
					}
					
				}
				b.SpeedAndDirection(fixPow,direction);
				b.PointChange(1);
			}
		}
	}
}
