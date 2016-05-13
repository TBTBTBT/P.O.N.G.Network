using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WinWriter : MonoBehaviour {

	// Use this for initialization
	void Start () {
		EventManager.OnFinish.AddListener (Write);
	}
	
	void Write(int winner) {
		GetComponent<Text> ().text = winner + "P WINS";
		
	}
}
