using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreAnimation : MonoBehaviour {

	float alpha = 1.0F;
	public Color color;

	// Use this for initialization
	void Start () {
		TextMesh textMesh = GetComponent<TextMesh> ();
		textMesh.text = (BreakoutGame.currentLevel * 10).ToString();
	}
	
	// Update is called once per frame
	void Update () {
		if (alpha <= 0.0F) {
			Destroy (gameObject);
		} else {
			TextMesh textMesh = GetComponent<TextMesh> ();
			textMesh.color = this.color;
			textMesh.transform.Translate (new Vector2 (0, 1) * 2.0F * Time.deltaTime);

			alpha -= 2.0F * Time.deltaTime;
		}
	}
}
