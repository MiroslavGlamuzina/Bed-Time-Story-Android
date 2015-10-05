using UnityEngine;
using System.Collections;

public class RestartScript : MonoBehaviour {
	public bool RestartLevel;
	public InGameMenuVisibility ingamemenuvisibility; 
	// Use this for initialization
	void Start () {
		RestartLevel = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (RestartLevel) {
			this.audio.Play();
			AutoFade.LoadLevel("Level 01" ,2.5f ,1.5f, new Color(.37109375f,.0f, .0f));
		}
		RestartLevel = false;
	}
}
