using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakoutGame : MonoBehaviour {

	public static int CollisionsWithEdge = 0;
	public static int Score = 0;
	public Ball Ball;

	public Transform brick;
	public Camera camera;

	// Use this for initialization
	void Start () {
		Vector3 leftOrigin  = camera.ScreenToWorldPoint (new Vector3 (0, 0, 0));
		Vector3 rightOrigin = camera.ScreenToWorldPoint (new Vector3 (Screen.width, 0, 0));

		float screenWidth = Vector3.Distance (leftOrigin, rightOrigin);
		Debug.Log ("screenWidth: " + screenWidth);
		float brickWidth = brick.lossyScale.x;
		float spaceBetweenBricks = brickWidth / 10;

		int bricksPerRow = (int)(screenWidth / (brickWidth + spaceBetweenBricks));
		Debug.Log("Screen will fit " + bricksPerRow + " bricks per row");

		float paddingSize = (screenWidth - (bricksPerRow - 1) * (brickWidth + spaceBetweenBricks) - brickWidth) / 2.0F;
		Debug.Log ("paddingSize: " + paddingSize);

		for (float  x = leftOrigin.x + paddingSize + brickWidth / 2; 
					x <= rightOrigin.x - brickWidth / 2 - paddingSize;
					x += brickWidth + spaceBetweenBricks) {			
			Vector3 initial_position = new Vector3 (x, 1.0F, 0);
			Debug.Log ("Drawing brick at " + initial_position);
			Instantiate (brick, initial_position, Quaternion.identity);	
		}
	}

	// Update is called once per frame
	void Update () {
		
	}

	void onMissedBall() {
		Ball.ResetPosition ();
	}
}
