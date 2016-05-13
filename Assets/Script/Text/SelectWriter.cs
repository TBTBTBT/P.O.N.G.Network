using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SelectWriter : MonoBehaviour {
	Text t;
	[SerializeField]int playerNum = 0;
	string[] name = {"LEGACY","XAX","GONTA","NOG-ONE","A.N.B.S","00"};
	string[] special = {"InfinityPower","Shadow","DestroyLaser","BackStepRaw","4-Division",""};
	int[] pow = {5,5,8,6,6,4};
	int[] lng = {5,3,6,6,5,4};
	int[] spd = {5,8,3,3,4,4};
	// Use this for initialization
	void Start () {
		t = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		t.text = name[GlobalArgument.pc[playerNum-1]]+"\n\n";
		t.text += "<size=20>";
		t.text += "SPECIAL\n";
		t.text += special[GlobalArgument.pc[playerNum-1]]+"\n\n";
		t.text += "<color=red>pow  = "+pow[GlobalArgument.pc[playerNum-1]]+" + "+ GlobalArgument.pe[playerNum-1].pow+"</color>\n\n";
		t.text += "<color=green>len  = "+lng[GlobalArgument.pc[playerNum-1]]+" + "+ GlobalArgument.pe[playerNum-1].lng+"</color>\n\n";
		t.text += "<color=blue>spd  = "+spd[GlobalArgument.pc[playerNum-1]]+" + "+ GlobalArgument.pe[playerNum-1].spd+"</color>\n\n\n";
		t.text += "O K \n";
		t.text += "</size>";
	}
}
