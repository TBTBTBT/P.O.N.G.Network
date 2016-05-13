using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	[SerializeField]GameObject[] charactorList;
	[SerializeField]GameObject preBall;
	GameObject p1;
	GameObject p2;
	GameObject ball;
	bool start;
	int win = 0;
	int wintime = 0;
	// Use this for initialization
	void Start(){
		win = 0;
		ball = (GameObject)Instantiate (preBall, new Vector3 (0, 0, 0), Quaternion.identity);
		if(GlobalArgument.mode == 0)GameStart (GlobalArgument.pc[0], GlobalArgument.pc[1],false,true);
		if(GlobalArgument.mode == 1)GameStart (GlobalArgument.pc[0], GlobalArgument.pc[1],false,false);
		if(GlobalArgument.mode == 2)GameStart (GlobalArgument.pc[0], GlobalArgument.pc[1],true,true);
		start = false;
	}
	void GameStart (int p1c,int p2c,bool p1cp,bool p2cp) {
		if (charactorList.Length > p1c && charactorList.Length > p2c) {
			p1 = (GameObject)Instantiate (charactorList [p1c], new Vector3 (-2, 0, 0), Quaternion.identity);
			p2 = (GameObject)Instantiate (charactorList [p2c], new Vector3 (2, 0, 0), Quaternion.identity);
			p1.GetComponent<PlayerBase> ().SetPlayerNumber (1,GlobalArgument.pe[0]);
			p2.GetComponent<PlayerBase> ().SetPlayerNumber (2,GlobalArgument.pe[1]);
			if(p1cp == true){
				p1.GetComponent<PlayerBase> ().SetCPU();
			}
			if(p2cp == true){
				p2.GetComponent<PlayerBase> ().SetCPU();
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (start == false) {
			start = true;
			EventManager.Invoke(ref EventManager.OnStartGame);
		}
		if (ScoreManager.score1 >= 10) {
			if(p1!=null)Destroy(p2.gameObject);
			win = 1;
			if(ball!=null)Destroy(ball.gameObject);
			EventManager.InvokeIntArg(ref EventManager.OnFinish,win);

		}
		if (ScoreManager.score2 >= 10) {
			if(p2!=null)Destroy(p1.gameObject);
			win = 2;
			if(ball!=null)Destroy(ball.gameObject);
			EventManager.InvokeIntArg(ref EventManager.OnFinish,win);
		}
		if (win > 0) {
			wintime++;
			if(wintime > 180){
				Application.LoadLevel("Select");
			}
		}
	}
}
