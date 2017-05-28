using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakoutGame : MonoBehaviour {

	public static int CollisionsWithEdge = 0;
	public Ball Ball;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void onMissedBall() {
		Ball.ResetPosition ();
	}
}
