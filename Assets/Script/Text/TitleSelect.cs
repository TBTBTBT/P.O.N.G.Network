using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TitleSelect : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
	if (TitleManager.mode == 0) {
			GetComponent<Text>().text = ">";
		}
		if (TitleManager.mode == 1) {
			GetComponent<Text>().text = "\n>";
		}
		if (TitleManager.mode == 2) {
			GetComponent<Text>().text = "\n\n>";
		}
	}
}
