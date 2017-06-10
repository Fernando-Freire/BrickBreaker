using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
	private Vector2 randomDirection;

	void Start () {
		ResetPosition ();
		InitRandomVelocity ();
	}

	void Update() {
		Vector2 velocity = GetComponent<Rigidbody2D> ().velocity;
		if (Mathf.Abs(velocity.x) < 1.0F) {
			GetComponent<Rigidbody2D> ().velocity = velocity + new Vector2(1.0F, 0);
		}
		if (Mathf.Abs(velocity.y) < 1.0F) {
			GetComponent<Rigidbody2D> ().velocity = velocity + new Vector2(0, 1.0F);
		}
	}

	public void InitRandomVelocity() {
		randomDirection = new Vector2 (
			Random.Range (-0.5f, 0.5f),
			Random.Range (0, 0.9f)
		).normalized;
			
		Debug.Log ("Random velocity with direction: " + randomDirection);


		GetComponent<Rigidbody2D> ().velocity = BreakoutGame.speed * randomDirection;
	}

	public void ResetPosition() {
		gameObject.transform.position = new Vector2 (0, -3.5F);
	}

	void OnCollisionEnter2D (Collision2D collider) {
		AudioSource audio = GetComponent<AudioSource> ();
		audio.Play ();
	}
}
