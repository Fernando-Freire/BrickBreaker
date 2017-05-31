using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakoutGame : MonoBehaviour {

	public static int currentLevel;
	private int BricksInBoard = 0;
	public int Score = 0;
	public static float speed = 5;

	public static int CollisionsWithEdge = 0;

	public Ball Ball;
	public Transform brickPrefab;
	public Camera camera;
	private float screenWidth;

	public bool loading = true;
	private Vector3 bottomLeft, topLeft, topRight, bottomRight;

	Color[] rowColors = {
		new Color (1.0F, 0, 0, 1.0F),
		new Color (1.0F, 0.5F, 0, 1.0F),
		new Color (1.0F, 1.0F, 0, 1.0F),
		new Color (0, 1.0F, 0, 1.0F),
		new Color (0, 0, 1.0F, 1.0F),
		new Color (.4F, 0, 1.0F, 1.0F),
		new Color (.6F, 0, 1.0F, 1.0F)
	};

	// Use this for initialization
	void Start () {
		loading = true;
		bottomLeft  = camera.ScreenToWorldPoint (new Vector3 (0, 0, 0));
		topLeft     = camera.ScreenToWorldPoint (new Vector3 (0, Screen.height, 0));
		topRight    = camera.ScreenToWorldPoint (new Vector3 (Screen.width, Screen.height, 0));
		bottomRight = camera.ScreenToWorldPoint (new Vector3 (Screen.width, 0, 0));

		screenWidth  = Vector3.Distance (bottomLeft, bottomRight);
		StartGameForLevel (1);
	}

	void StartGameForLevel(int level) {
		loading = true;
		Debug.Log ("Starting level " + level);
		currentLevel = level;
		speed = 4 + level;

		positionBricks ();
		Ball.ResetPosition ();

		loading = false;	
	}

	void positionBricks() {
		float brickWidth = brickPrefab.lossyScale.x;
		float brickHeight = brickPrefab.localScale.y;
		float spaceBetweenBricks = brickWidth / 10;

		int bricksPerRow = (int)(this.screenWidth / (brickWidth + spaceBetweenBricks));
		Debug.Log ("Each row will fit " + bricksPerRow + " bricks");
		float paddingSize = (screenWidth - (bricksPerRow - 1) * (brickWidth + spaceBetweenBricks) - brickWidth) / 2.0F;

		int rowCount = 0;
		float y = this.topLeft.y - (1.5F * brickHeight + spaceBetweenBricks);
		while (rowCount < 7) {
			int brickCount = 0;
			Debug.Log ("Positioning new brick row...");
			for (float x = this.bottomLeft.x + paddingSize + brickWidth / 2; 
				brickCount < bricksPerRow;
				x += brickWidth + spaceBetweenBricks) {			
				Vector3 initial_position = new Vector3 (x, y, 0);

				Debug.Log ("Positioning new brick...");
				Transform brick = Instantiate (brickPrefab, initial_position, Quaternion.identity);	
				brick.GetComponent<Renderer> ().material.color = rowColors [rowCount];
				brick.GetComponent<Brick> ().game = this;

				brickCount += 1;
				this.BricksInBoard += 1;
			}
			y = y - (brickHeight + spaceBetweenBricks);
			rowCount += 1;
		}
	}

	void onMissedBall() {
		Ball.ResetPosition ();
	}

	public void onBrickDeletion() {
		this.Score += 10 * currentLevel;
		this.BricksInBoard -= 1;
		if (this.BricksInBoard == 0) {
			StartGameForLevel (currentLevel + 1);
		}
	}
}
