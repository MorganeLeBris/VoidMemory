using UnityEngine;
using System.Collections;

public class rotate : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(0, 70 * Time.deltaTime, 0);
    }
}
