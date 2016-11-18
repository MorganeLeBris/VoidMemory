using UnityEngine;
using System.Collections;

public class SwitchPlayer : MonoBehaviour {

	[SerializeField] protected Camera cameraBuzz;
	[SerializeField] protected Camera cameraHorcan;

	// Use this for initialization
	void Start () {
		cameraBuzz.enabled = true;
		cameraHorcan.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Tab))
		{
			cameraBuzz.enabled = !cameraBuzz.enabled;
			cameraHorcan.enabled = !cameraHorcan.enabled;
		}
	}
}
