using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour {
    public PlatformController plat;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player" && Input.GetKeyDown("space"))
           plat.Moove();

    }
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            plat.Moove();
        }
    }
}
