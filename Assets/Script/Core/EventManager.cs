using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class UnityEventIntArg : UnityEvent <int>{}
public class EventManager : MonoBehaviour {
	static public UnityEvent OnGoal;
	static public UnityEvent OnStartGame;
	static public UnityEvent OnHitBumper;
	static public UnityEventIntArg OnGoalRight;
	static public UnityEventIntArg OnGoalLeft;
	static public UnityEventIntArg OnFinish;
	static public UnityEvent LegacyPowerUp;
	static public UnityEvent GontaShot;
	static public UnityEvent NogMove;
	static public UnityEvent OnShot;
	// Use this for initialization
	void Awake() {
		SetEvent (ref OnGoal);
		SetEvent (ref OnStartGame);
		SetEvent (ref OnHitBumper);
		SetEventIntArg (ref OnGoalRight);
		SetEventIntArg (ref OnGoalLeft);
		SetEventIntArg (ref OnFinish);
		SetEvent (ref LegacyPowerUp);
		SetEvent (ref GontaShot);
		SetEvent (ref NogMove);
		SetEvent (ref OnShot);
	}
	void SetEvent(ref UnityEvent u ){
		if (u == null) {
			u = new UnityEvent ();
		}
	}
	void SetEventIntArg(ref UnityEventIntArg u ){
		if (u == null) {
			u = new UnityEventIntArg ();
		}
	}
	static public void Invoke(ref UnityEvent u ){
		if (u != null) {
			u.Invoke();
		}
	}
	static public void InvokeIntArg(ref UnityEventIntArg u ,int a){
		if (u != null) {
			u.Invoke(a);
		}
	}
	// Update is called once per frame
}
