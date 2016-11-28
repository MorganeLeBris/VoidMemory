using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour
{
	private int score;
	// Use this for initialization
	void Start()
    {
    }
	
	// Update is called once per frame
	void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Horcan") || other.gameObject.CompareTag("Buzz"))
        {
			GameObject.Find("Score").GetComponent<Score>().score += 30;
            gameObject.SetActive(false);
        }
    }

  
}