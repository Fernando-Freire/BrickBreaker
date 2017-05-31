using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakoutGame : MonoBehaviour {

	public static int CollisionsWithEdge = 0;
	public static int Score = 0;
	public Ball Ball;

	public Transform brickPrefab;
	public Camera camera;

	Color32[] rowColors = {
		new Color32 (0xFF, 0x00, 0x00, 0xFF),
		new Color32 (0xFF, 0x7F, 0x00, 0xFF),
		new Color32 (0xFF, 0xFF, 0x00, 0xFF),
		new Color32 (0x00, 0xFF, 0x00, 0xFF),
		new Color32 (0x00, 0x00, 0xFF, 0xFF),
		new Color32 (0x66, 0x00, 0xFF, 0xFF),
		new Color32 (0x8B, 0x00, 0xFF, 0xFF)
	};

	// Use this for initialization
	void Start () {
		Vector3 bottomLeft  = camera.ScreenToWorldPoint (new Vector3 (0, 0, 0));
		Vector3 topLeft     = camera.ScreenToWorldPoint (new Vector3 (0, Screen.height, 0));
		Vector3 topRight    = camera.ScreenToWorldPoint (new Vector3 (Screen.width, Screen.height, 0));
		Vector3 bottomRight = camera.ScreenToWorldPoint (new Vector3 (Screen.width, 0, 0));

		float screenWidth  = Vector3.Distance (bottomLeft, bottomRight);
		float screenHeight = Vector3.Distance (bottomLeft, topLeft);

		float brickWidth = brickPrefab.lossyScale.x;
		float brickHeight = brickPrefab.localScale.y;
		float spaceBetweenBricks = brickWidth / 10;

		int bricksPerRow = (int)(screenWidth / (brickWidth + spaceBetweenBricks));
		Debug.Log("Screen will fit " + bricksPerRow + " bricks per row");

		float paddingSize = (screenWidth - (bricksPerRow - 1) * (brickWidth + spaceBetweenBricks) - brickWidth) / 2.0F;
		Debug.Log ("paddingSize: " + paddingSize);

		int rowCount = 0;
		float y = topLeft.y - (1.5F * brickHeight + spaceBetweenBricks);
		while (rowCount < 7) {
			for (float x = bottomLeft.x + paddingSize + brickWidth / 2; 
						x <= bottomRight.x - brickWidth / 2 - paddingSize;
						x += brickWidth + spaceBetweenBricks) {			
				Vector3 initial_position = new Vector3 (x, y, 0);
				Debug.Log ("Drawing brick at " + initial_position);
				Transform brick = Instantiate (brickPrefab, initial_position, Quaternion.identity);	
				Debug.Log ("Color " + rowColors[rowCount]);
				brick.GetComponent<Renderer> ().material.color = rowColors [rowCount];

			}
			y = y - (brickHeight + spaceBetweenBricks);
			rowCount += 1;
		}
	}

	// Update is called once per frame
	void Update () {
		
	}

	void onMissedBall() {
		Ball.ResetPosition ();
	}
}
