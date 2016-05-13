using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SelectPointWriter : MonoBehaviour {
	Text t;
	[SerializeField]int playerNum = 0;
	string[] sentence = {"\n\n\n\n<size=20>\n\n","\n\n","\n\n","\n\n\n</size>","\n"};
	// Use this for initialization
	void Start () {
		t = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		string br = "";
		t.text = "";
		for (int i=0; i<sentence.Length; i++) {
			if(i==SelectManager.index[playerNum-1])t.text +="<size=20><                             ></size>";
			t.text+=sentence[i];
		}
	}
}
