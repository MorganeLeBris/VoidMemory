using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour {
    public PlatformController plat;
    public Sprite newSprite;
  

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player" && Input.GetKeyDown("space"))
        {
            plat.Moove();
            GetComponent<SpriteRenderer>().sprite = newSprite;
        }
           

    }
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            plat.Moove();
            GetComponent<SpriteRenderer>().sprite = newSprite;
        }
    }
}
