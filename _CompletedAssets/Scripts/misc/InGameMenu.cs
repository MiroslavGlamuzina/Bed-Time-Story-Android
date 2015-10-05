using UnityEngine;
using System.Collections;

public class InGameMenu : MonoBehaviour {
	//scale
	public Vector3 menuscale = new Vector3(0f,0f,0f);
	public bool expand; 
	public InGameMenuVisibility ingamemenuVisibility;
	// Use this for initialization
	void Start () {
		Debug.Log ("InGameMenu Start()");
		menuscale = this.transform.localScale;
		expand = false;
		ingamemenuVisibility.renderer.enabled = true;

	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log ("InGameMenu Update()");
		this.transform.localScale = menuscale;
		if (expand) 
		{
			expandMenu();
		}
		if (!expand) 
		{
			shrinkMenu();
		}
	}

	void expandMenu(){
		ingamemenuVisibility.renderer.enabled = false;
		if (menuscale.z < 1.35f) {	
				//menuscale.x += 0.00f;
				menuscale.z += 0.05f;
				menuscale.y += 0.013f;
				Debug.Log ("MENU EXPANDING");
		}
	}

	void shrinkMenu(){
		if (menuscale.z > 0.2f) {
			//menuscale.x -= 0.00f;
			menuscale.z -= 0.05f;
			menuscale.y -= 0.013f;
			Debug.Log ("MENU SHRINKING");
				}
		ingamemenuVisibility.renderer.enabled = true;

	}

	void onCollisionEnter (Collision other)
	{
		
	}
}
