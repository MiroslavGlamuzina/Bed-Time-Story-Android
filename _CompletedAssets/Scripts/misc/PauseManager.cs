using UnityEngine;
using System.Collections;
using UnityEngine.UI;
//#if UNITY_EDITOR
//using UnityEditor;
//#endif

public class PauseManager : MonoBehaviour {
	public bool pausegame ;

	void Start()
	{
		pausegame = false;
	}

	void Update()
	{
		if (pausegame)
		{
			Pause ();
		}
	}

	public void Pause()
	{
		Time.timeScale = Time.timeScale == 0 ? 1 : 0;
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
