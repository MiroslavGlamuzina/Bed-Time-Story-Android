using UnityEngine;
using System.Collections;
using UnityEngine.UI;
//#if UNITY_EDITOR
//using UnityEditor;
//#endif

public class PauseScript : MonoBehaviour {
	public bool pausegame ;
	public int timer;
	void Start()
	{
		pausegame = false;
		timer = 0;
	}
	
	void Update()
	{
		if (timer < 200) {
			timer++;

		}
	}
	
	public void Pause()
	{
		Time.timeScale = 0;
		timer = 0;
		pausegame = false;
	}

	public void UnPause()
	{
		Time.timeScale = 1;
		timer = 0;
		pausegame = false;
	}
	public void Quit()
	{
		//#if UNITY_EDITOR 
		//		EditorApplication.isPlaying = false;
		//#else 
		//		Application.Quit();
		//#endif
	}
}
