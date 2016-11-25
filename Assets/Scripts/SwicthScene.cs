using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SwicthScene : MonoBehaviour {

	public bool spaceActivate;//Is space used to load a level?
	public string spacelevel;//level to load when pressing space

	public void switchscene(string scenename){
		PlayerPrefs.SetInt( "previousLevel", Application.loadedLevel );
		SceneManager.LoadScene(scenename);
	}

	void Update(){
		if (Input.GetKeyDown ("escape")) {
			int previousLevel = PlayerPrefs.GetInt ("previousLevel");
			SceneManager.LoadScene(previousLevel);
		}
		if (spaceActivate && Input.GetKeyDown ("space")) {
			SceneManager.LoadScene(spacelevel);
		}
	}
}
