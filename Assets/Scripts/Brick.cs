using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

	public BreakoutGame game;
	public Transform scoreAnimationPrefab;

	void OnCollisionEnter2D(Collision2D col) {
		game.onBrickDeletion ();
		this.Explode (true);
	}

	public void Explode(bool causedByBall){
		if (causedByBall) {
			Vector3 position = GetComponent<Transform> ().position;
			Transform scoreAnimation = Instantiate (scoreAnimationPrefab, position, Quaternion.identity);
			scoreAnimation.GetComponent<ScoreAnimation> ().color = GetComponent<Renderer>().material.color;
		}
	
		Destroy (gameObject);
	}
}
