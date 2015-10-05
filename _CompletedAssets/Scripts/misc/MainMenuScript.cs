using UnityEngine;
using System.Collections;

public class MainMenuScript : MonoBehaviour {
	public bool MainMenuToggle;

	// Use this for initialization
	void Start () {
		MainMenuToggle = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (MainMenuToggle) {
			this.audio.Play();
			AutoFade.LoadLevel("MainMenu" ,2.5f,1.5f, new Color(.37109375f,.0f, .0f));
		}
		MainMenuToggle = false;

	}
}
