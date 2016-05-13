using UnityEngine;
using System.Collections;

public class SelectManager : MonoBehaviour {
	static public int[] index = {0,0};
	int[] enc = {5,5};
	bool[] decide = {false,false};
	// Use this for initialization
	void Start () {
		GlobalArgument.ResetSelet ();
	}
	
	// Update is called once per frame
	void Update () {
		if (GlobalArgument.mode == 0) {
			if (decide [0] == false)
				Select (0);
			if (decide [1] == false)
				RandomSelect (1);
		}
		if (GlobalArgument.mode == 1) {
			if (decide [0] == false)
				Select (0);
			if (decide [1] == false)
				Select (1);
		}
		if (GlobalArgument.mode == 2) {
			if (decide [0] == false)
				RandomSelect (0);
			if (decide [1] == false)
				RandomSelect (1);
		}
		if(decide[0] ==true && decide[1] == true){
			Application.LoadLevel("Untitled");
		}

	}
	void Select(int pl){
		KeyInput k = KeyManager.GetKeyInputDown (pl+1);
		if (k.down > 0 && index[pl] < 4) {
			index[pl]++;
		}
		if (k.up > 0 && index[pl] > 0) {
			index[pl]--;
		}
		if (k.right > 0) {
			if(index[pl] == 0){
				if(GlobalArgument.pc[pl]<5)GlobalArgument.pc[pl] ++;
			}
			if(index[pl] == 1){
				if(enc[pl] > 0){
					GlobalArgument.pe[pl].pow ++;
					enc[pl]--;
				}

			}
			if(index[pl] == 2){
				if(enc[pl] > 0){
					GlobalArgument.pe[pl].lng ++;
					enc[pl]--;
				}
			}
			if(index[pl] == 3){
				if(enc[pl] > 0){
					GlobalArgument.pe[pl].spd ++;
					enc[pl]--;
				}
			}
			if(index[pl] == 4){
				decide[pl] = true;
			}
		}
		if (k.left > 0) {
			if(index[pl] == 0){
				if(GlobalArgument.pc[pl]>0)GlobalArgument.pc[pl] --;
			}
			if(index[pl] == 1){
				if(GlobalArgument.pe[pl].pow > 0){
					GlobalArgument.pe[pl].pow --;
					enc[pl]++;
				}

			}
			if(index[pl] == 2){
				if(GlobalArgument.pe[pl].lng > 0){
					GlobalArgument.pe[pl].lng --;
					enc[pl]++;
				}
			}
			if(index[pl] == 3){
				if(GlobalArgument.pe[pl].spd > 0){
					GlobalArgument.pe[pl].spd --;
					enc[pl]++;
				}
			}
		}
	}
	void RandomSelect(int pl){
		GlobalArgument.pc [pl] = Random.Range (0,6);
		for (int i=0; i<5; i++) {
			int r = Random.Range(0,3);
			if(r == 0){
				GlobalArgument.pe[pl].pow ++;
			}
			if(r == 1){
				GlobalArgument.pe[pl].lng ++;
			}
			if(r == 2){
				GlobalArgument.pe[pl].spd ++;
			}
		}
		decide [pl] = true;
	}
}
