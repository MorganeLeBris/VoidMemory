using UnityEngine;
using System.Collections;

public class SpawnPlanets : MonoBehaviour {

	public Transform[] parents;
	public Transform[] PlanetsPrefabs;
	public float SpawnRate = 2.0f;

	private float deltaSpawn;
	private SpriteRenderer[] sr;
	private int planetRand;
	private int layerRand;

	// Use this for initialization
	void Start () {
		deltaSpawn = SpawnRate;
		sr = new SpriteRenderer[PlanetsPrefabs.Length];
		for (int i = 0; i < PlanetsPrefabs.Length; i++) {
			sr[i] = PlanetsPrefabs[i].GetComponent<SpriteRenderer> ();
		}
	}
	
	// Update is called once per frame
	void Update () {

		if (deltaSpawn > 0) {
			deltaSpawn -= Time.deltaTime;
		} else {

			// Calculating camera boundaries
			//var dist = (transform.position - Camera.main.transform.position).z;

			var rightBorder = Camera.main.ViewportToWorldPoint(
				new Vector3(1, 0, 0)
			).x;

			var topBorder = Camera.main.ViewportToWorldPoint(
				new Vector3(0, 0, 0)
			).y;

			var bottomBorder = Camera.main.ViewportToWorldPoint(
				new Vector3(0, 1, 0)
			).y;

			planetRand = Random.Range (0,PlanetsPrefabs.Length);
			layerRand = Random.Range (0,parents.Length);

			Vector3 position = new Vector3(rightBorder+sr[planetRand].bounds.size.x,Random.Range(bottomBorder-sr[planetRand].bounds.size.y/2,topBorder+sr[planetRand].bounds.size.y/2),0.0f);
			Instantiate (PlanetsPrefabs[planetRand],position,PlanetsPrefabs[planetRand].transform.rotation,parents[layerRand]);
			deltaSpawn = SpawnRate;
		}
	}
}