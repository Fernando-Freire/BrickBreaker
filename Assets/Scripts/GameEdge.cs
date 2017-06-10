using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEdge : MonoBehaviour {

	public Camera camera; 
	public EdgeCollider2D edge;
	public BreakoutGame game;

	void Start () {
		UpdateEdgePoints ();
	}

	void UpdateEdgePoints() {
		Vector3 bottomLeft  = camera.ScreenToWorldPoint (new Vector3 (0, 0, 0));
		Vector3 topLeft     = camera.ScreenToWorldPoint (new Vector3 (0, Screen.height, 0));
		Vector3 topRight    = camera.ScreenToWorldPoint (new Vector3 (Screen.width, Screen.height, 0));
		Vector3 bottomRight = camera.ScreenToWorldPoint (new Vector3 (Screen.width, 0, 0));

		edge.points = new Vector2[5] {
			bottomLeft, topLeft, topRight, bottomRight, bottomLeft
		};
	}

	void OnCollisionEnter2D (Collision2D collider) {
		if (collider.contacts [0].normal.y < 0) {
			BreakoutGame.CollisionsWithEdge += 1;
			Debug.Log (BreakoutGame.CollisionsWithEdge);
			game.Score = 0;
			BreakoutGame.currentLevel = 1;
			game.Start ();
		}
	}
}
