using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthScript : MonoBehaviour {
	/// <summary>
	/// Total hitpoints
	/// </summary>
	public int hp = 1;

	/// <summary>
	/// Text to display hp
	/// </summary>
	public Text hpdisplay;

	/// <summary>
	/// Enemy or player?
	/// </summary>
	public bool isEnemy = true;

	bool paused = false;

	///<summary>
	/// Use of the awake method just to display Player Hp at the beginning
	/// </summary>
	void Awake(){
		if (hpdisplay != null) {
			hpdisplay.text = hp.ToString();
		}
	}

	/// <summary>
	/// Inflicts damage and check if the object should be destroyed
	/// </summary>
	/// <param name="damageCount"></param>
	public void Damage(int damageCount)
	{
		hp -= damageCount;

		if (hp <= 0)
		{
			// Dead!
			if (!isEnemy) {
				paused = togglePause ();
				Debug.Log (paused);
			} else {
				Destroy(gameObject);
			}
		}

		if (hpdisplay != null) {
			hpdisplay.text = hp.ToString();
		}
	}

	void OnTriggerEnter2D(Collider2D otherCollider)
	{
		// Is this a shot?
		ShotScript shot = otherCollider.gameObject.GetComponent<ShotScript>();
		if (shot != null)
		{
			// Avoid friendly fire
			if (shot.isEnemyShot != isEnemy)
			{
				Damage(shot.damage);

				// Destroy the shot
				Destroy(shot.gameObject); // Remember to always target the game object, otherwise you will just remove the script
			}
		}
	}

	void OnGUI()
	{
		if(paused)
		{
			GUI.Label(new Rect(Screen.width/2-50, Screen.height/2-10, 100, 20),"Vous êtes morts!");
			if (GUI.Button (new Rect (Screen.width / 2 - 40, Screen.height / 2 + 10, 60, 20), "Quitter"))
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
