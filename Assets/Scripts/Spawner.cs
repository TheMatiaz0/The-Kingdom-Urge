using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cyberevolver;
using Cyberevolver.Unity;
using System.Linq;

public class Spawner : AutoInstanceBehaviour<Spawner>
{
	public List<GameObject> spawnedEnemies = new List<GameObject>();

	public enum SpawnState { SPAWNING, WAITING, COUNTING };

	public SpawnState state = SpawnState.SPAWNING;

	[SerializeField]
	private TransformWithDirection[] enemySpawners = null;

	[SerializeField]
	private SerializeTimeSpan timeInterval;

	[SerializeField]
	private SerializeTimeSpan timeBetweenWaves;

	[SerializeField]
	private GameObject enemyType = null;

	private uint waveIndex = 0;

	public void StartSpawn ()
	{
		StartCoroutine(StartWave());
	}

	private IEnumerator StartWave ()
	{
		while(true)
		{
			state = SpawnState.SPAWNING;

			yield return SpawnWave();

			state = SpawnState.WAITING;

			yield return new WaitWhile(EnemyisAlive);

			state = SpawnState.COUNTING;

			yield return Async.Wait(timeBetweenWaves.TimeSpan);
		}
	}

	private IEnumerator SpawnWave()
	{
		waveIndex++;
		for (int i = 0; i < waveIndex; i++)
		{
			SpawnEnemy();
			yield return Async.Wait(timeInterval.TimeSpan);
		}
	}

	private bool EnemyisAlive()
	{
		spawnedEnemies = spawnedEnemies.Where(e => e != null).ToList();

		return spawnedEnemies.Count > 0;
	}

	private void SpawnEnemy()
	{
		GameObject tempEnemy;
		int t = UnityEngine.Random.Range(0, enemySpawners.Length);
		TransformWithDirection obj = enemySpawners[t];
		Vector2 pos = obj.ObjectTransform.position;
		spawnedEnemies.Add(tempEnemy = Instantiate(enemyType, pos, Quaternion.identity));
		tempEnemy.GetComponent<Enemy>().SetupEnemy(obj.MoveDirection);
	}
}
