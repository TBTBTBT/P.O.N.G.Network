using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour {
	static public int score1;
	static public int score2;
	// Use this for initialization
	void Start () {
		score1 = 0;
		score2 = 0;
		EventManager.OnGoalLeft.AddListener (Add2);
		EventManager.OnGoalRight.AddListener (Add1);
	}
	public void Add1(int s){
		score1 += s;
	}
	public void Add2(int s){
		score2 += s;
	}
	// Update is called once per frame
	void Update () {
	
	}
}
