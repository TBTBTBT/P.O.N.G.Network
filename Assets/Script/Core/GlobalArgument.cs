using UnityEngine;
using System.Collections;
public struct Enchant{
	public int spd;
	public int pow;
	public int lng;
	public Enchant(int s ,int p , int l){
		spd = s;
		pow = p;
		lng = l;
	}
}
public class GlobalArgument : MonoBehaviour {
	static public int mode = 0;
	static public int[] pc = {0,0};
	static public Enchant[] pe = new Enchant[2];
	// Use this for initialization
	static public void Reset () {
		mode = 0;
		pc[0] = 0;
		pc[1] = 0;
		pe[0] = new Enchant (0, 0, 0);
		pe[1] = new Enchant (0, 0, 0);
	}
	static public void ResetSelet () {
		pc[0] = 0;
		pc[1] = 0;
		pe[0] = new Enchant (0, 0, 0);
		pe[1] = new Enchant (0, 0, 0);
	}
	// Update is called once per frame
	void Update () {
	
	}
}
