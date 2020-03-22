using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cyberevolver;
using Cyberevolver.Unity;
using System.Linq;

public class Spawner : AutoInstanceBehaviour<Spawner>
{
	public List<Enemy> SpawnedEnemies { get; private set; } = new List<Enemy>();

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

			yield return new WaitWhile(AnyEnemyisAlive);

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

	private bool AnyEnemyisAlive()
	{
		SpawnedEnemies = SpawnedEnemies.Where(e => e != null).ToList();

		return SpawnedEnemies.Count > 0;
	}

	public Enemy GetClosestEnemy(Vector2 currentPosition, float range)
	{
		Enemy bestTarget = null;
		foreach (Enemy enemy in SpawnedEnemies)
		{
			Vector2 directionToTarget = (Vector2)enemy.transform.position - currentPosition;
			float dSqrToTarget = directionToTarget.sqrMagnitude;
			if (dSqrToTarget < range)
			{
				range = dSqrToTarget;
				bestTarget = enemy;
			}
		}

		return bestTarget;
	}

	private void SpawnEnemy()
	{
		Enemy tempEnemy;
		int t = UnityEngine.Random.Range(0, enemySpawners.Length);
		TransformWithDirection obj = enemySpawners[t];
		Vector2 pos = obj.ObjectTransform.position;
		SpawnedEnemies.Add(tempEnemy = Instantiate(enemyType, pos, Quaternion.identity).GetComponent<Enemy>());
		tempEnemy.SetupEnemy(obj.MoveDirection);
	}
}
