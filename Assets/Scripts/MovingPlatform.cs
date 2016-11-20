using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour {
    public PlatformController plat;
    public Sprite newSprite;
  

    void OnTriggerStay2D(Collider2D collider)
    {
        if ((collider.gameObject.tag == "Buzz" || collider.gameObject.tag == "Horcan") && Input.GetKeyDown("space"))
        {
            plat.Moove();
            GetComponent<SpriteRenderer>().sprite = newSprite;
        }
           

    }
    void Update()
    {
    }
}
