using UnityEngine;
using System.Collections;

public class ScalingScript : MonoBehaviour {

    public Camera maincamera;

	// Use this for initialization
	void Start () {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        transform.localScale = maincamera.scalingFactor;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
