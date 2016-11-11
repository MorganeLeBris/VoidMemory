using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class timer : MonoBehaviour {

    private float count;
    public Text countText;

	// Use this for initialization
	void Start () {
        count = 0;
	}
	
	// Update is called once per frame
	void Update () {
	    count += Time.deltaTime;
        countText.text = "Temps : " + (int)count;
    }
}
