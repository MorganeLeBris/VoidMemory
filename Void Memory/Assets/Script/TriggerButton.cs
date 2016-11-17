using UnityEngine;
using System.Collections;

public class TriggerButton : MonoBehaviour {

    public Sprite newSprite;
    public Door door;
    public Door door2;
    private bool istrigger=false;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player" && Input.GetKeyDown("space") && !istrigger)
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
        if (Input.GetKeyDown("space") && !istrigger){
            StartCoroutine(door.OpenUp());
            if (door2)
                StartCoroutine(door2.CloseUp());
            GetComponent<SpriteRenderer>().sprite = newSprite;
            istrigger = true;
        }

    }
}
