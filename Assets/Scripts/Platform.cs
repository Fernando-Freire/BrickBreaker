using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour {

	public int speed = 5;

	void FixedUpdate() {
		float v = Input.GetAxisRaw ("Horizontal");
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (v, 0) * speed;
	}
}
