using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour {

	private float timeLeft = 30.0f;
	public Text timedisplay;

	// Use this for initialization
	void Start () {
		timedisplay.text = timeLeft.ToString ();
	}
	
	// Update is called once per frame
	void Update () {

		timeLeft -= Time.deltaTime;
		timedisplay.text = timeLeft.ToString ();
		if(timeLeft < 0)
		{
			Application.Quit();
		}
	
	}
}
