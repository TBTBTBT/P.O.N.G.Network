using UnityEngine;
using System.Collections;
[RequireComponent (typeof(Rigidbody2D))]
public class Ball : MonoBehaviour {
	[SerializeField] GameObject particle;
	[SerializeField] GameObject powerLing;
	[SerializeField] GameObject shadow;
	protected Rigidbody2D rg;
	private Camera cam;
	Vector2 bottomLeft;
	Vector2 topRight;
	float speed = 1;
	int radius = 5;
	int point = 1;
	Vector2 direction ;
	float angle = 0 ;
	int powerLingTime = 0;
	int shadowTime = 0;
	// Use this for initialization
	void Start () {
		do {
			direction = new Vector2 (Random.Range (-1, 2), Random.Range (-1, 2));
		} while(direction.x == 0);
		rg = GetComponent<Rigidbody2D> ();
		cam = GameObject.Find ("Main Camera").GetComponent<Camera>();
		bottomLeft = cam.ScreenToWorldPoint (new Vector3(0,0,0));
		topRight = cam.ScreenToWorldPoint (new Vector3(Screen.width, Screen.height, 0.0f));
		EventManager.OnShot.AddListener (Flare);

	}
	void Move(){
		Shadow ();
		if(point>=5)PowerLing ();
		transform.position += (Vector3)direction * speed / 25;
	}
	float GetRadTrue(Vector2 len){
		float angle = Mathf.Atan2(len.y, len.x) * Mathf.Rad2Deg;
		//if (angle > 0) {
			return angle;
	//	} 
	//	else {
	//		return 360.0f+angle;
	//	}
	}
	void Flare(){
		angle = GetRadTrue (direction); 

		Instantiate (particle, transform.position, Quaternion.AngleAxis (angle + 30, new Vector3 (0, 0, 1)));
		Instantiate (particle, transform.position, Quaternion.AngleAxis (angle - 30, new Vector3 (0, 0, 1)));
		Instantiate (particle, transform.position, Quaternion.AngleAxis (angle + 40, new Vector3 (0, 0, 1)));
		Instantiate (particle, transform.position, Quaternion.AngleAxis (angle - 40, new Vector3 (0, 0, 1)));

	}
	void PowerLing(){
		angle = GetRadTrue (direction); 
		powerLingTime++;

		if (powerLingTime >= 6) {
			Instantiate(powerLing,transform.position,Quaternion.AngleAxis (angle, new Vector3 (0, 0, 1)));
			powerLingTime =0;
		}
	}
	void Shadow(){
		 
		if ((direction * speed).magnitude >= 8) {
			angle = GetRadTrue (direction);
				Instantiate (shadow, transform.position, Quaternion.AngleAxis (angle, new Vector3 (0, 0, 1)));

		}

	}
	// Update is called once per frame
	void Update () {
		Move ();
		Reflect ();
		FixPos();
	}
	void Reflect(){
		if (transform.position.x < bottomLeft.x) {
			
			if(direction.x < 0){
				direction  = new Vector2(-direction .x,direction .y);
				direction = direction.normalized;
				speed = 2;
				EventManager.InvokeIntArg(ref EventManager.OnGoalLeft,point);
				EventManager.Invoke(ref EventManager.OnGoal);
				point = 1;

			}
			
		}
		if (transform.position.x > topRight.x) {
			if(direction.x > 0){
				direction  = new Vector2(-direction .x,direction .y);
				direction = direction.normalized;
				speed = 2;
				EventManager.InvokeIntArg(ref EventManager.OnGoalRight,point);
				EventManager.Invoke(ref EventManager.OnGoal);
				point = 1;
			}
			
		}
		if (transform.position.y< bottomLeft.y) {
			
			if(direction.y < 0){
				direction  = new Vector2(direction .x,-direction .y);
				
			}
			
		}
		if (transform.position.y > topRight.y) {
			if(direction.y > 0){
				direction  = new Vector2(direction .x,-direction .y);
			}
			
		}
	}
	void ReflectBumper(float bumperPosY){
		if (transform.position.y< bumperPosY) {
			if(direction.y < 0){
				//Flare ();
				direction  = new Vector2(direction .x,-direction .y);
				
			}
			
		}
		if (transform.position.y > bumperPosY) {
			if(direction.y > 0){
				//Flare ();
				direction  = new Vector2(direction .x,-direction .y);
			}
			
		}
	}
	void FixPos(){
		if (transform.position.x > topRight.x) {
			transform.position = new Vector3(topRight.x,transform.position.y,transform.position.z);
		}
		if (transform.position.x < bottomLeft.x) {
			transform.position = new Vector3(bottomLeft.x,transform.position.y,transform.position.z);
		}
		if (transform.position.y < bottomLeft.y ) {
			transform.position = new Vector3(transform.position.x,bottomLeft.y,transform.position.z);
		}
		if (transform.position.y > topRight.y) {
			transform.position = new Vector3(transform.position.x,topRight.y,transform.position.z);
		}
		
	}
	void OnTriggerStay2D(Collider2D c){
		if (c.tag == "Bumper") {
			ReflectBumper(c.transform.position.y);
		}
	}


	public Vector2 RetDir(){
		return direction;
	}
	public void SpeedAndDirection(float spd,Vector2 dir){

		direction = dir;
		speed = spd;

	}
	public void PointChange(int p){
		point = p;
	}
}
