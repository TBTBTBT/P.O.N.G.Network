using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DamageWriter : MonoBehaviour {
	[SerializeField]int playerNum = 0;
	int time = 0;
	int minus = 0;
	Text t;
	// Use this for initialization
	void Start () {
		t = GetComponent<Text> ();
		if(playerNum == 1)EventManager.OnGoalLeft.AddListener (Begin);
		if(playerNum == 2)EventManager.OnGoalRight.AddListener (Begin);
	}
	
	// Update is called once per frame
	void Begin (int arg) {
		time = 100;
		minus = arg;
	}
	void Update(){
		if (time > 0) {
			time --;
			t.text = "-" + minus;

			if(time == 0){
				t.text = "";
			}
		}
	}
}
