using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
	bool paused = false;
	public GUIStyle style;

	void Update()
	{
		if(Input.GetKeyDown("escape"))
			paused = togglePause();
	}

	void OnGUI()
	{
		if(paused)
		{
			GUI.Label(new Rect(Screen.width/2-135, Screen.height/2-20, 100, 40),"Jeu en pause!",style);
			if (GUI.Button (new Rect (Screen.width/2+10, Screen.height/2+30, 100, 20), "Quitter"))
				Application.Quit ();
			if (GUI.Button (new Rect (Screen.width/2-110, Screen.height/2+30, 100, 20), "Menu principal"))
				SceneManager.LoadScene("mainMenu");
		}
	}

	bool togglePause()
	{
		if(Time.timeScale == 0f)
		{
			Time.timeScale = 1f;
			return(false);
		}
		else
		{
			Time.timeScale = 0f;
			return(true);    
		}
	}
}