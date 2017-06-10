using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour {

	public void FixedUpdate() {
		float v = Input.acceleration.x;
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (v, 0) * 5.0F * BreakoutGame.speed;
	}
}
