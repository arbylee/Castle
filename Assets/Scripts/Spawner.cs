using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
	public Transform spawnPoint;
	public GameObject enemyPrefab; 
	private float spawnCD = 2f;
	private float spawnTimeLeft = 2f;

	void Start () {
	
	}

	void Update () {
		spawnTimeLeft -= Time.deltaTime;
		if (spawnTimeLeft <= 0) {
			Instantiate (enemyPrefab, spawnPoint.position, Quaternion.identity);
			spawnTimeLeft = spawnCD;
		}
	}
}
