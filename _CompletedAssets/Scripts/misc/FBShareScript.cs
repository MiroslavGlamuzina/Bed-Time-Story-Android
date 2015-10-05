using UnityEngine;
using System.Collections;

public class FBShareScript : MonoBehaviour {
	public bool fbshare;
	private bool openURL;
	private bool check;
	public AudioMenuToggle audiomenutogglescript;
	// Use this for initialization
	void Start () {
		openURL = false;
		check = false;
	}
	
	// Update is called once per frame
	void Update () {
	if (fbshare)
		{
			audio.Play();
			check = true;
			audiomenutogglescript.audio.volume = .3f;
		}
		fbshare = false;

		if (check == true)
		{
			if(!audio.isPlaying)
			{
			openURL = true;
			}
		}
		if (openURL == true) {
			audiomenutogglescript.audio.volume = 1f;
			openURL = false;
			check = false;
			Application.OpenURL("https://www.facebook.com/bedtimestoryvr?ref=aymt_homepage_panel");
		}
	}
}
//code "_"