using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
	public float speed = 3;
	private Vector2 randomDirection;

	void Start () {
		ResetPosition ();
		InitRandomVelocity ();
	}

	public void InitRandomVelocity() {
		randomDirection = new Vector2 (
			Random.Range (-0.9f, 0.9f),
			Random.Range (0, 0.9f)
		).normalized;
			
		Debug.Log ("Random velocity with direction: " + randomDirection);

		GetComponent<Rigidbody2D> ().velocity = speed * randomDirection;
	}

	public void ResetPosition() {
		gameObject.transform.position = new Vector2 (0, -3.5F);
	}

	void OnCollisionEnter2D (Collision2D collider) {
	}
}
