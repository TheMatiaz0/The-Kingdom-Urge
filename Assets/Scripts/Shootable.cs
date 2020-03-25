using Cyberevolver;
using Cyberevolver.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shootable : Building
{
	[SerializeField]
	private float range = 40f;

	[SerializeField]
	private SerializeTimeSpan shootTimerMax;

	[SerializeField]
	private Transform shootPoint = null;

	[SerializeField]
	private GameObject bulletPrefab = null;

	[SerializeField]
	private float bulletSpeed = 40;

	[SerializeField]
	private Cint bulletDamage = 2;

	public override void OnPlace()
	{
		base.OnPlace();

		// StartCoroutine(ShootWithDelay());
	}

	private IEnumerator ShootWithDelay()
	{
		while (true)
		{
			Enemy enemy = Spawner.Instance.GetClosestEnemy(shootPoint.transform.position, range);
			if (enemy != null)
			{
				GameObject bulletObj = Instantiate(bulletPrefab, shootPoint.transform.position, Quaternion.identity);
				Bullet bullet = bulletObj.GetComponent<Bullet>();
				bullet.TargetPosition = enemy.transform.position;
				bullet.BulletSpeed = bulletSpeed;
				bullet.BulletDamage = bulletDamage;
			}

			yield return Async.Wait(shootTimerMax.TimeSpan);
		}
	}

	public override void Start()
	{
		base.Start();
		StartCoroutine(ShootWithDelay());
	}
}
