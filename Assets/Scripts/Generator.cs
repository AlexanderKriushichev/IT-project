using UnityEngine;
using System.Collections;

public class Generator : MonoBehaviour
{
	public Vector3 spawnPos;
	public GameObject[] enemies;
	public float enemyCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;


	void Start()
	{
		StartCoroutine(SpawnEnemies());
	}

	void Update()
	{

	}

	IEnumerator SpawnEnemies()
	{
		yield return new WaitForSeconds(startWait);
		while (true)
		{
			GameObject ememy = enemies[Random.Range(0, enemies.Length)];
			Vector3 spawnPosition = new Vector3(spawnPos.x, Random.Range(-spawnPos.y, spawnPos.y), spawnPos.z);
			Quaternion spawnRotation = ememy.CompareTag("Rocket") ? Quaternion.Euler(0, 0, 90) : Quaternion.identity;
			Instantiate(ememy, spawnPosition, spawnRotation);
			yield return new WaitForSeconds(Random.Range(spawnWait / 5, spawnWait));
		}
	}
}


