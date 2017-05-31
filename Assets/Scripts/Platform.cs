using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour {

	void FixedUpdate() {
		float v = Input.GetAxisRaw ("Horizontal");
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (v, 0) * 1.2F * BreakoutGame.speed;
	}
}
