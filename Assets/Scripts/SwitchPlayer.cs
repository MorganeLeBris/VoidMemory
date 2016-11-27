using UnityEngine;

public class SwitchPlayer : MonoBehaviour {

	[SerializeField] protected Camera cameraBuzz;
	[SerializeField] protected Camera cameraHorcan;

	// Use this for initialization
	void Start () {
		cameraBuzz.enabled = true;
		cameraHorcan.enabled = false;
		cameraHorcan.GetComponent<AudioListener>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Tab))
		{

			cameraBuzz.enabled = !cameraBuzz.enabled;
			cameraBuzz.GetComponent<AudioListener>().enabled = !cameraBuzz.GetComponent<AudioListener>().enabled;
			cameraHorcan.GetComponent<AudioListener>().enabled = !cameraHorcan.GetComponent<AudioListener>().enabled;
			cameraHorcan.enabled = !cameraHorcan.enabled;
		}
	}
}
