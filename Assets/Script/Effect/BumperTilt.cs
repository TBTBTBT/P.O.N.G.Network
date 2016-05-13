using UnityEngine;
using System.Collections;

public class BumperTilt : MonoBehaviour {
	Vector3 normal;
	float tilt;
	Transform child;
	int dir;
	// Use this for initialization
	void Start(){
		child = transform.GetChild (0);
		tilt = 0;
		dir = 0;
		normal = child.position;
	}
	void Update(){
		if (tilt > 0) {
			tilt -= 0.01f;
			switch (dir) {
			case 1:
				dir = -1;
				break;
			case -1:
				dir = 1;
				break;
			}
			child.position = new Vector3 (normal.x, normal.y + tilt * dir, normal.z);
		} else {
			child.position = normal;
		}
	}
	void OnTriggerEnter2D(Collider2D c){
		
		if (c.tag == "Ball") {
			EventManager.Invoke(ref EventManager.OnHitBumper);
			if(c.transform.position.y < transform.position.y){
				tilt = 0.1f;
				dir = 1;
			}else{
				tilt = 0.1f;
				dir = -1;

			}
		}
	}
}