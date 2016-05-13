using UnityEngine;
using System.Collections;

public class QuitGame : MonoBehaviour {

	// Use this for initialization
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey("escape")) {
			Application.Quit();
		}
	}
}
