using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AImanager : MonoBehaviour {
	
	// Use this for initialization
	void Start () {

		getHand();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("space")) {				// CHANGE TO GET UI BUTTON PRESSED EVENT....
			
			getHand ();
		}
	}
	public void getHand(){
		GameObject hand = GameObject.Find ("Hand");
		//if null

		foreach (object obj in hand.transform) {
			//GameObject child=(GameObject)obj;

			//Debug.Log ("Children is" + child);
		}

	}
}
