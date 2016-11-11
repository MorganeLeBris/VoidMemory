using UnityEngine;
using System.Collections;

public class TriggerButton : MonoBehaviour {


    public Door door;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player" && Input.GetKeyDown("space"))
            StartCoroutine(door.OpenUp());
    }
    void Update()
    {
        if (Input.GetKeyDown("space")){
            StartCoroutine(door.OpenUp());
        }
    }
}
