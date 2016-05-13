using UnityEngine;
using System.Collections;


[RequireComponent (typeof(Rigidbody2D))]
public class PlayerBase : MonoBehaviour {
	protected Rigidbody2D rg;
	private Camera cam;
	protected float speedY = 0;
	protected float speedX = 0;
	protected int length = 0;
	protected int pow = 0;
	protected int damage = 0;
	protected int playerNumber = 0;
	[SerializeField]protected int prePlayerNumber= 1;
	protected KeyInput key;
	[SerializeField]protected bool isPlayer = false;
	protected Vector2 bottomLeft;
	protected Vector2 topRight;
	protected Vector2 preSpd;
	protected int point = 1;
	// Use this for initialization

	void Awake () {
		key = new KeyInput (0,0,0,0,0);
		rg = GetComponent<Rigidbody2D> ();
		cam = GameObject.Find ("Main Camera").GetComponent<Camera>();
		bottomLeft = cam.ScreenToWorldPoint (new Vector3(0,0,0));
		topRight = cam.ScreenToWorldPoint (new Vector3(Screen.width, Screen.height, 0.0f));
		Setup ();
		transform.localScale = new Vector3 (5, length, 1);
	}
	public void SetPlayerNumber(int number,Enchant e){
		playerNumber = number;
		if (playerNumber == 1) {
			topRight = new Vector2(-1,topRight.y);
		}
		if (playerNumber == 2) {
			bottomLeft = new Vector2(1,bottomLeft.y);
		}
		speedY += e.spd;
		pow += e.pow;
		length += e.lng;
		transform.localScale = new Vector3 (5, length, 1);
		SetupAfter();
	}
	public void SetCPU(){
		isPlayer = false;
	}
	public void InputKeys(int up,int right,int left, int down){
		key.up = up;
		key.down = down;
		key.right = right;
		key.left = left;
	}
	// Update is called once per frame
	void FixedUpdate(){


	}
	void Move(){

		preSpd = Vector2.zero;
		if (key.up > 0 && key.down == 0) {
			preSpd = new Vector2(preSpd.x,1);
		}
		if (key.down > 0 && key.up == 0) {
			preSpd = new Vector2(preSpd.x,-1);
		}
		if (key.right > 0 && key.left == 0) {
			preSpd = new Vector2(1,preSpd.y);
		}
		if (key.left > 0 && key.right == 0) {
			preSpd = new Vector2(-1,preSpd.y);
		}
		transform.position += (Vector3)new Vector2 (preSpd.x * speedX /30, preSpd.y * speedY / 30);

	}
	void FixPos(){
		if (transform.position.x > topRight.x) {
			transform.position = new Vector3(topRight.x,transform.position.y,transform.position.z);
		}
		if (transform.position.x < bottomLeft.x) {
			transform.position = new Vector3(bottomLeft.x,transform.position.y,transform.position.z);
		}
		if (transform.position.y < bottomLeft.y + length * 0.3f / 2) {
			transform.position = new Vector3(transform.position.x,bottomLeft.y + length * 0.3f / 2,transform.position.z);
		}
		if (transform.position.y > topRight.y - length  * 0.3f / 2) {
			transform.position = new Vector3(transform.position.x,topRight.y-length * 0.3f/ 2,transform.position.z);
		}

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
					if(Mathf.Abs(transform.position.y - c.transform.position.y)>0.2f+length*0.02f){
					if(transform.position.y<=c.transform.position.y){
						direction.y = 0.5f;
					}
					if(transform.position.y>=c.transform.position.y){
						direction.y = -0.5f;
					}
				}
			}
			b.SpeedAndDirection(fixPow,direction);
			b.PointChange(point);
			HitBallEnter(b);
				EventManager.Invoke(ref EventManager.OnShot);
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
			b.PointChange(point);
			HitBallStay(b);
			}
		}
	}
	void PlayerInput(){
		key = KeyManager.GetKeyInput (playerNumber);
	}
	int cpAtD =0; 
	void CPU(){
		int u = 0, d = 0,l = 0,r = 0;
		GameObject ballObj = GameObject.FindGameObjectWithTag ("Ball");
		if (ballObj != null) {
			Vector3 ball = ballObj.transform.position;
			if (playerNumber == 1) {
				if (ball.x < -2) {
					if (ball.y > transform.position.y + length * 0.1 / 2) {
						u = 1;
					}
					if (ball.y < transform.position.y - length * 0.1 / 2) {
						d = 1;
					}
					if (ball.x >= transform.position.x && ball.y < transform.position.y + length * 0.3 / 2 && ball.y > transform.position.y - length * 0.3 / 2) {
						r = 1;
						if (Mathf.Abs (ball.x - transform.position.x) < 0.5f) {
							if (cpAtD == 1)
								u = 1;
							if (cpAtD == 2)
								d = 1;
						}
					} else if (ball.x < transform.position.x) {
						l = 1;
					}
			
				} else {
					cpAtD = Random.Range (0, 3);
					if (transform.position.x > -5.5f) {
						l = 1;
					}
				}
			}
			if (playerNumber == 2) {
				if (ball.x > 2) {
					if (ball.y > transform.position.y + length * 0.1 / 2) {
						u = 1;
					}
					if (ball.y < transform.position.y - length * 0.1 / 2) {
						d = 1;
					}
					if (ball.x <= transform.position.x && ball.y < transform.position.y + length * 0.3 / 2 && ball.y > transform.position.y - length * 0.3 / 2) {
						l = 1;
						if (Mathf.Abs (ball.x - transform.position.x) < 0.5f) {
							if (cpAtD == 1)
								u = 1;
							if (cpAtD == 2)
								d = 1;
						}
					} else if (ball.x > transform.position.x) {
						r = 1;
					}
				
				} else {
					cpAtD = Random.Range (0, 3);
					if (transform.position.x < 5.5f) {
						r = 1;
					}
				}
			}
		}
		InputKeys (u,r,l,d);
	}
	void Update () {
		if (isPlayer == true) {
			PlayerInput();
		} else {
			CPU ();
		}
		Move ();
		UpdateAfter ();
		FixPos ();
	}
	virtual protected void Setup(){}
	virtual protected void SetupAfter(){}
	virtual protected void UpdateAfter(){}
	virtual protected void HitBallEnter(Ball b){}
	virtual protected void HitBallStay(Ball b){}
}
