using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
	private Vector2 randomDirection;

	private bool boosted = false;
	private bool delayed = false;
	private int remainingBoostedFrames = 0;

	void Start () {
		ResetPosition ();
		InitRandomVelocity ();
	}

	void Update() {
		if (boosted || delayed) {
			this.remainingBoostedFrames -= 1;
			if (remainingBoostedFrames == 0) {
				if (boosted) {
					boosted = false;
					GetComponent<Rigidbody2D> ().velocity *= 0.5F;
				}
				if (delayed) {					
					delayed = false;
					GetComponent<Rigidbody2D> ().velocity *= 2.0F;
				}
			}
		}

		Vector2 velocity = GetComponent<Rigidbody2D> ().velocity;
		if (Mathf.Abs(velocity.x) < 1.0F) {
			GetComponent<Rigidbody2D> ().velocity = velocity + new Vector2(1.0F, 0);
		}
		if (Mathf.Abs(velocity.y) < 1.0F) {
			GetComponent<Rigidbody2D> ().velocity = velocity + new Vector2(0, 1.0F);
		}
	}

	public void InitRandomVelocity() {
		boosted = false;

		randomDirection = new Vector2 (
			Random.Range (-0.5f, 0.5f),
			Random.Range (0, 0.9f)
		).normalized;
			
		GetComponent<Rigidbody2D> ().velocity = BreakoutGame.speed * randomDirection;
	}

	public void ResetPosition() {
		gameObject.transform.position = new Vector2 (0, -3.5F);
	}

	void OnCollisionEnter2D (Collision2D collider) {		
		AudioSource audio = GetComponent<AudioSource> ();
		audio.Play ();
	}

	void OnTriggerExit2D(Collider2D other) {
		if (!boosted && !delayed) {			
			if (other.name == "Booster") {
				GetComponent<Rigidbody2D> ().velocity *= 2.0F;
				boosted = true;
			} else if (other.name == "BlackHole") {
				GetComponent<Rigidbody2D> ().velocity *= 0.5F;
				delayed = true;
			}
		}
		remainingBoostedFrames = 120;
	}
}
