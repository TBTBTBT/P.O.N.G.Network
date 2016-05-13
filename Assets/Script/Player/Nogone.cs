using UnityEngine;
using System.Collections;

public class Nogone : PlayerBase {
	[SerializeField]GameObject preFire;
	GameObject fireUp;
	GameObject fireDown;
	// Use this for initialization
	override protected void Setup(){
		speedX = 5;
		speedY = 3;
		length = 6;
		pow = 6;
		//fireUp = (GameObject)Instantiate(preFire,new Vector3(transform.position.x,transform.position.y + 1,0),Quaternion.identity);
	}
	protected override void UpdateAfter ()
	{
		if(playerNumber == 1 ){
		if ((key.up > 0 || key.down > 0) && key.left > 0) {
			transform.position += (Vector3)new Vector2 ( 0 ,preSpd.y * speedY / 25);

		}
		}
		if(playerNumber == 2 ){
			if ((key.up > 0 || key.down > 0) && key.right > 0) {
				transform.position += (Vector3)new Vector2 ( 0 ,preSpd.y * speedY / 25);
			}
		}

	}
}
