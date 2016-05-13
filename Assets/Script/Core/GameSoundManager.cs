using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameSoundManager : MonoBehaviour {
	AudioSource audioSource; 
	AudioSource audioSourceLoop; 
	public AudioClip bgm;
	public AudioClip bumper;
	public AudioClip damage;
	public AudioClip shot;
	public AudioClip gontaShot;
	// Use this for initialization
	void Start () {
		audioSource = gameObject.AddComponent<AudioSource>();
		audioSourceLoop = gameObject.AddComponent<AudioSource>();
		audioSourceLoop.loop = true;
		audioSourceLoop.clip = bgm;
		audioSource.spatialBlend = 0;
		audioSourceLoop.spatialBlend = 0;
		StartBGM ();
		EventManager.OnHitBumper.AddListener (Bumper);
		EventManager.OnFinish.AddListener (StopBGM);
		EventManager.OnGoal.AddListener (Damage);
		EventManager.OnShot.AddListener (Shot);
		EventManager.GontaShot.AddListener (GontaShot);
	}
	
	// Update is called once per frame
	void StartBGM () {
		audioSourceLoop.Play();
	}
	void StopBGM (int arg) {
		audioSourceLoop.Stop();
	}
	void Damage () {
		audioSource.volume = 1f;
		audioSource.PlayOneShot(damage);
	}
	void Bumper () {
		audioSource.volume = 0.3f;
		audioSource.PlayOneShot(bumper);
	}
	void Shot() {
		audioSource.volume = 0.3f;
		audioSource.PlayOneShot(shot);
	}
	void GontaShot() {
		audioSource.volume = 0.3f;
		audioSource.PlayOneShot(gontaShot);
	}
}
