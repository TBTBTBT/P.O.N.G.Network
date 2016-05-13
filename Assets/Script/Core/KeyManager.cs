using UnityEngine;
using System;
using System.Collections;
public struct KeyInput {
	public int up;
	public int right;
	public int left;
	public int down;
	public int action;
	public KeyInput(int u ,int r,int l, int d,int a){
		up = u;
		right = r;
		left = l;
		down = d;
		action = a;
	}
}
public class KeyManager : MonoBehaviour {
	static KeyInput key1;
	static KeyInput key2;
	static KeyInput key1d;
	static KeyInput key2d;
	// Use this for initialization
	void Start () {
		key1 = new KeyInput(0,0,0,0,0);
		key2 = new KeyInput(0,0,0,0,0);
		key1d = new KeyInput(0,0,0,0,0);
		key2d = new KeyInput(0,0,0,0,0);
	}
	void InputUpdate(ref KeyInput k,ref KeyInput k2,string u,string r,string l,string d){
		k.up = Convert.ToInt32(Input.GetKey (u));
		k.right = Convert.ToInt32(Input.GetKey (r));
		k.left = Convert.ToInt32(Input.GetKey (l));
		k.down = Convert.ToInt32(Input.GetKey (d));
		k2.up = Convert.ToInt32(Input.GetKeyDown (u));
		k2.right = Convert.ToInt32(Input.GetKeyDown (r));
		k2.left = Convert.ToInt32(Input.GetKeyDown (l));
		k2.down = Convert.ToInt32(Input.GetKeyDown (d));
	}
	// Update is called once per frame
	void Update () {
		if (GlobalArgument.mode == 0) {
			InputUpdate (ref key1,ref key1d, "up", "right", "left", "down");
			InputUpdate (ref key2,ref key2d, "s", "c", "z", "x");
		} else {
			InputUpdate (ref key2,ref key2d, "up", "right", "left", "down");
			InputUpdate (ref key1,ref key1d, "s", "c", "z", "x");
		}
	}
	static public KeyInput GetKeyInput(int pl){
		if (pl == 1)return key1;
		if (pl == 2)return key2;
		return new KeyInput (0, 0, 0, 0, 0);
	}
	static public KeyInput GetKeyInputDown(int pl){
		if (pl == 1)return key1d;
		if (pl == 2)return key2d;
		return new KeyInput (0, 0, 0, 0, 0);
	}
}
