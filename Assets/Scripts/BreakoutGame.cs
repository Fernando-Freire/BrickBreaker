using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakoutGame : MonoBehaviour {

	public static int currentLevel;
	private int BricksInBoard = 0;
	public int Score = 0;
	public static float speed = 5;

	public static int CollisionsWithEdge = 0;
	public int HighestScore;

	public Ball Ball;
	public Transform brickPrefab;
	public Camera camera;
	public ScoreDisplay scoreDisplay;
	public ScoreDisplay highScoreDisplay;
	private float screenWidth;

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
	public void Start () {
		Screen.sleepTimeout = SleepTimeout.NeverSleep;

		DeleteAllBricks ();
		bottomLeft  = camera.ScreenToWorldPoint (new Vector3 (0, 0, 0));
		topLeft     = camera.ScreenToWorldPoint (new Vector3 (0, Screen.height, 0));
		topRight    = camera.ScreenToWorldPoint (new Vector3 (Screen.width, Screen.height, 0));
		bottomRight = camera.ScreenToWorldPoint (new Vector3 (Screen.width, 0, 0));

		screenWidth  = Vector3.Distance (bottomLeft, bottomRight);

		this.Score = 0;
		this.HighestScore = PlayerPrefs.GetInt ("highscore");

		this.scoreDisplay.setDisplayedScore (this.Score);
		this.highScoreDisplay.setDisplayedScore (this.HighestScore);

		StartGameForLevel (1);
	}

	public void DeleteAllBricks(){
		foreach (Brick brick in Object.FindObjectsOfType<Brick>()) {
			brick.Explode (false);
		}
		BricksInBoard = 0;
		currentLevel -= 1;
	}


	void StartGameForLevel(int level) {
		Debug.Log ("Starting level " + level);
		currentLevel = level;
		speed = 4 + level;

		positionBricks ();

		Ball.ResetPosition ();

		Ball.InitRandomVelocity();
	}

	void positionBricks() {
		float brickWidth = brickPrefab.lossyScale.x;
		float brickHeight = brickPrefab.localScale.y;
		float spaceBetweenBricks = brickWidth / 10;

		int bricksPerRow = (int)(this.screenWidth / (brickWidth + spaceBetweenBricks));
		float paddingSize = (screenWidth - (bricksPerRow - 1) * (brickWidth + spaceBetweenBricks) - brickWidth) / 2.0F;

		int rowCount = 0;
		float y = this.topLeft.y - (1.5F * brickHeight + spaceBetweenBricks);
		while (rowCount < 7) {
			int brickCount = 0;
			for (float x = this.bottomLeft.x + paddingSize + brickWidth / 2; 
				brickCount < bricksPerRow;
				x += brickWidth + spaceBetweenBricks) {			
				Vector3 initial_position = new Vector3 (x, y, 0);

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

	public void onMissedBall() {
		Start ();
	}

	public void onBrickDeletion() {
		this.Score += 10 * currentLevel;
		this.scoreDisplay.setDisplayedScore (this.Score);
		if (this.Score > this.HighestScore)
			this.HighestScore = this.Score;
			this.highScoreDisplay.setDisplayedScore (this.HighestScore);
			PlayerPrefs.SetInt ("highscore", HighestScore);

		this.BricksInBoard -= 1;
		if (this.BricksInBoard == 0) {
			StartGameForLevel (currentLevel + 1);
		}
	}
}
