using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour {

	public void setDisplayedScore(int score) {
		gameObject.GetComponent<Text> ().text = score.ToString();
	}
}
