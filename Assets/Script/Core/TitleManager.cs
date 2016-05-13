using UnityEngine;
using System.Collections;

public class TitleManager : MonoBehaviour {
	static public int mode = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	if (Input.GetKeyDown ("up")) {
			if(mode>0){
			GlobalArgument.mode--;
			mode --;
			}
		}
		if (Input.GetKeyDown ("down")) {
			if(mode<2){
			GlobalArgument.mode++;
			mode ++;
			}
		}

		if (Input.GetKey ("right")) {
			Application.LoadLevel("Select");
		}
	}
}
