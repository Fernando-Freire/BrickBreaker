using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

	public Canvas mainCanvas;

	void Awake () {
		mainCanvas.enabled = true;
	}

	public void LoadGame () {
		SceneManager.LoadScene ("Game");
	}
}
