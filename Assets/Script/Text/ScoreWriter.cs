using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreWriter : MonoBehaviour {
	[SerializeField]int playerNum = 0;
	// Use this for initialization
	void Start () {
			EventManager.OnGoal.AddListener(Write);

	}
	
	// Update is called once per frame
	void Write() {
		string hp = "";
		if (playerNum == 1) {

			for(int i = 0; i < 10 - ScoreManager.score2; i++){
				hp+="=";
			}

		}
		if (playerNum == 2) {
			for(int i = 0; i < 10 - ScoreManager.score1; i++){
				hp+="=";
			}
		}
		GetComponent<Text> ().text = hp;
		if (hp.Length < 5) {
			GetComponent<Text> ().color =Color.red;
		}

	}
}
