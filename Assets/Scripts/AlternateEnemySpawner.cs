using UnityEngine;
using System.Collections;

public class AlternateEnemySpawner : MonoBehaviour {
	float spawnCooldown = 2f;
	float spawnCooldownLeft = 2f;
	public GameObject enemyPrefab;
	void Update () {
		spawnCooldownLeft -= Time.deltaTime;
		if (spawnCooldownLeft <= 0) {
			Instantiate (enemyPrefab, this.transform.position, Quaternion.identity);
			spawnCooldownLeft = spawnCooldown;
		}
	}
}
