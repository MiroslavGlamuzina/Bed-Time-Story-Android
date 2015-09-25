using UnityEngine;
using System.Collections;

public class CrossHairSwayScript : MonoBehaviour
{
	Vector3 sway;
	public float swaySpeed;
	private bool horizontal;
	private bool vertical;
	public float swayAmount; 

	// Use this for initialization
	void Start ()
	{
		sway = this.transform.localPosition;
		horizontal = false;
		vertical = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		//horizontal sway
		if (!horizontal) {
			if (sway.x > -1f *swayAmount) {
				sway.x -= Time.deltaTime * swaySpeed; 
			} else {
				horizontal = true;
			}
		}
		if (horizontal) {
			if (sway.x < swayAmount) {
				sway.x += Time.deltaTime * swaySpeed; 
			} else {
				horizontal = false;
			}
		}

		//vertica sway
		if (!vertical) {
			if (sway.y > -1*swayAmount/2) {
				sway.y -= Time.deltaTime * swaySpeed; 
			} else {
				vertical = true;
			}
		}
		if (vertical) {
			if (sway.y < swayAmount/2) {
				sway.y += Time.deltaTime * swaySpeed; 
			} else {
				vertical = false;
			}
		}

		this.transform.localPosition = sway;
	}
}
