using UnityEngine;
using System.Collections;

public class Particle : MonoBehaviour {

	[SerializeField] bool move=true;
	[SerializeField] bool scaleX=true;
	[SerializeField] bool scaleY=false;
	[SerializeField] int max = 15;
	[SerializeField] float normalScale = 3;
	[SerializeField] bool color = false;
	[SerializeField] float alpha = 0.9f;
	float ang=0;
	float ext=1;
	float ct=0;
	float sx = 3;
	float sy = 3;
	//float alpha = 1;
	SpriteRenderer sr;
	void Start () {
		sx = normalScale;
		sy = normalScale;
		transform.localScale = new Vector3 (sx, sy, 1);
			ext = Random.Range(0.28F,0.45F);
			ang =transform.localEulerAngles.z;
		if (color == true && GetComponent<SpriteRenderer> () != null) {
			sr = GetComponent<SpriteRenderer> ();
			sr.color = new Color(1,1,1,(1 - ct / max)*alpha);
		}
	}
	
	// Update is called once per frame
	void Update () {
		ct++;
		/*if(GetComponent<Renderer>().material.color.a >= 0){
			GetComponent<Renderer>().material.color -= alpha;
		}*/
		if (color = true && sr!=null) {
			sr.color = new Color(1,1,1,(1 - ct / max)*alpha);
		}
		if(move==true)transform.position += new Vector3 ((1 - ct/max)*Mathf.Cos (ang*Mathf.PI/180),(1 - ct/max)*Mathf.Sin (ang*Mathf.PI/180),0)*ext;
		if (scaleX == true)sx = normalScale * (1 - ct / max);
		if(scaleY==true)sy = normalScale * (1 - ct / max);
			transform.localScale = new Vector3 (sx,sy,1);
		//transform.position += mov;
		if(ct>=max){
			Destroy(gameObject);
		}
		
	}

}
