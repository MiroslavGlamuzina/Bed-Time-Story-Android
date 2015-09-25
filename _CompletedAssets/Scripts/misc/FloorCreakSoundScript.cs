using UnityEngine;
using System.Collections;

public class FloorCreakSoundScript : MonoBehaviour {
	float time ;
	float check;
	// Use this for initialization
	void Start () {
		check = Random.Range (8f, 12f);
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		if (time > check) {
			time = 0f;
			check = Random.Range (8f, 12f);
			this.audio.Play();
		}
	}
}
