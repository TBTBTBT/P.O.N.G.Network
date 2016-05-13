using UnityEngine;
using System.Collections;

public class ParticleNoMove : MonoBehaviour {

	//[SerializeField] bool loc=false;
	//[SerializeField] Vector3 mov = new Vector3(0,0,0);
	//float ang=0;
	//float ext=1;
	float ct=0;
	//Color alpha = new Color(0, 0, 0, 0.01f);
	void Start () {
			//Vector3 ax;
			//ext = Random.Range(0.08F,0.25F);
			//transform.rotation.ToAngleAxis(out ang,out ax);

	}
	
	// Update is called once per frame
	void Update () {
		ct++;
		/*if(GetComponent<Renderer>().material.color.a >= 0){
			GetComponent<Renderer>().material.color -= alpha;
		}*/
		//if(loc==false)transform.position += new Vector3 ((1 - ct/20)*Mathf.Cos (ang*Mathf.PI/180),(1 - ct/20)*Mathf.Sin (ang*Mathf.PI/180),0)*ext;
		//transform.localScale = new Vector3 (3 *(1 -  ct / 20),1.5f,1);
		//transform.position += mov;
		if(ct>=20){
			Destroy(gameObject);
		}
		
	}

}
