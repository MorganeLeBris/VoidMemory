using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Health : MonoBehaviour {

	public int maxLifePoints = 3;
	private int lifePoints;
	public bool isInvincible = false;
	public Sprite fullHeart;
	public Sprite emptyHeart;
	public Image heart1;
	public Image heart2;
	public Image heart3;

	// Use this for initialization
	void Start () {
		lifePoints = maxLifePoints;
		heart1.sprite = fullHeart;
		heart2.sprite = fullHeart;
		heart3.sprite = fullHeart;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public IEnumerator restartLevel()
	{
		int scene = SceneManager.GetActiveScene().buildIndex;
		float fadeTime = GameObject.Find("FadingBetweenScenesObject").GetComponent<Fading>().BeginFade(1);
		yield return new WaitForSeconds(fadeTime);
		SceneManager.LoadScene(scene, LoadSceneMode.Single);
	}

	public void increaseHealth()
	{
		lifePoints++;
		if (heart2.sprite == emptyHeart)
			heart2.sprite = fullHeart;
		if (heart3.sprite == emptyHeart)
			heart3.sprite = fullHeart;
		if (lifePoints > maxLifePoints)
			lifePoints = maxLifePoints;

	}

	public void decreaseHealth()
	{
		if (!isInvincible)
		{
			lifePoints--;
			if (heart1.sprite == fullHeart && heart2.sprite == emptyHeart)
				heart1.sprite = emptyHeart;
			if (heart2.sprite == fullHeart && heart3.sprite == emptyHeart)
				heart2.sprite = emptyHeart;
			if (heart3.sprite == fullHeart)
				heart3.sprite = emptyHeart;
			if (lifePoints <= 0f)
			{
				StartCoroutine(restartLevel());
			}
		}
	}

}
