using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class AnimateStartButtonScript : MonoBehaviour {

	public GameObject spookyeyes1;
	public GameObject spookyeyes2;
	public GameObject spookyeyes3;
	public GameObject parent; 
	private float time; 
	// Use this for initialization
	
	void Start () {
		time += Time.deltaTime;
			spookyeyes1 = Instantiate(spookyeyes1) as GameObject;
		spookyeyes1.transform.localPosition = this.transform.position + new Vector3 (Random.Range(-.6f, .6f), Random.Range(-.6f, .6f), -.15f);
		spookyeyes1.transform.rotation = new Quaternion (Random.Range(0f, 360f),270f ,0f,270f);
		float scale1 = Random.Range (1f, 5f);
		spookyeyes1.transform.localScale = new Vector3 (.01f*scale1, .01f*scale1, .01f*scale1);

		spookyeyes2 = Instantiate(spookyeyes2) as GameObject;
		spookyeyes2.transform.localPosition = this.transform.position + new Vector3 (Random.Range(-.6f, .6f), Random.Range(-.6f, .6f), -.15f);
		spookyeyes2.transform.rotation = new Quaternion (Random.Range(0f, 360f),270f ,0f,270f);
		float scale2 = Random.Range (1f, 5f);
		spookyeyes2.transform.localScale = new Vector3 (.01f*scale2, .01f*scale2, .01f*scale2);

		spookyeyes3 = Instantiate(spookyeyes3) as GameObject;
		spookyeyes3.transform.localPosition = this.transform.position + new Vector3 (Random.Range(-.6f, .6f), Random.Range(-.6f, .6f), -.15f);
		spookyeyes3.transform.rotation = new Quaternion (Random.Range(0f, 360f),270f ,0f,270f);
		float scale3 = Random.Range (1f, 5f);
		spookyeyes3.transform.localScale = new Vector3 (.01f*scale3, .01f*scale3, .01f*scale3);

	}
	
	// Update is called once per frame
	void Update () 
	{
		time += Time.deltaTime;
		if (time > 2f) {
			time = 0f;
			updateEyes((int)Random.Range(0f, 2f));
		}


	}

	void updateEyes(int rand)
	{
		if (rand == 0) 
		{
			spookyeyes1.transform.position = this.transform.position + new Vector3 (Random.Range(-1f, 1f), Random.Range(-1f, 1f), -.15f);
			spookyeyes1.transform.rotation = new Quaternion (Random.Range(0f, 360f),270f ,Random.Range(-360f, 360f),270f);
			float scale1 = Random.Range (1f, 10f);
			spookyeyes1.transform.localScale = new Vector3 (.01f*scale1, .01f*scale1, .01f*scale1);
		}
		if (rand == 1) 
		{
			spookyeyes2.transform.position = this.transform.position + new Vector3 (Random.Range(-1f, 1f), Random.Range(-1f, 1f), -.15f);
			spookyeyes2.transform.rotation = new Quaternion (Random.Range(0f, 360f),270f ,Random.Range(-360f, 360f),270f);
			float scale2 = Random.Range (1f, 10f);
			spookyeyes2.transform.localScale = new Vector3 (.01f*scale2, .01f*scale2, .01f*scale2);
		}
		if (rand == 2) 
		{
			spookyeyes3.transform.position = this.transform.position + new Vector3 (Random.Range(-1f, 1f), Random.Range(-1f, 1f), -.15f);
			spookyeyes3.transform.rotation = new Quaternion (Random.Range(0f, 360f),270f ,Random.Range(-360f, 360f),270f);
			float scale3 = Random.Range (1f, 10f);
			spookyeyes3.transform.localScale = new Vector3 (.01f*scale3, .01f*scale3, .01f*scale3);
		}
	}









}
