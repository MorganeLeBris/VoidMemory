using UnityEngine;
using System.Collections;

public class TriggerButton : MonoBehaviour {

    public Sprite newSprite;
    public Door door;
    public Door door2;
    private bool istrigger=false;

    void OnTriggerStay2D(Collider2D collider)
    {
		
        if ((collider.gameObject.tag == "Buzz" || collider.gameObject.tag == "Horcan") && Input.GetKey("space") && !istrigger)
        {
            StartCoroutine(door.OpenUp());
            if(door2)
                 StartCoroutine(door2.CloseUp());
            GetComponent<SpriteRenderer>().sprite = newSprite;
            istrigger = true;
        }
    }
    void Update()
    {
    }
}
