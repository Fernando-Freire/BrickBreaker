using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

	public BreakoutGame game;

	void OnCollisionEnter2D(Collision2D col) {
		game.onBrickDeletion ();
		this.Destroy ();
	}
	public void Destroy(){
		Destroy (gameObject);
	}
}
