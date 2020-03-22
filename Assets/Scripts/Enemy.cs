using Cyberevolver.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cyberevolver;
using System;

public class Enemy : MonoBehaviour
{
	[SerializeField]
	private Cint startHp = 10;

	public Cint CurrentHp { get; private set; }

	[SerializeField]
	private Rigidbody2D rb2D = null;

	[SerializeField]
	private float speed = 10;

	[SerializeField]
	private Direction targetDirection = Direction.Right;

	[SerializeField]
	private Cint takeDmg = 10;

	public void SetupEnemy (Direction dir)
	{
		targetDirection = dir;
	}

	protected void Start()
	{
		CurrentHp = startHp;
	}

	protected void FixedUpdate()
	{
		rb2D.MovePosition((Vector2)transform.position + targetDirection * speed * Time.deltaTime);
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		Building building;

		if (building = collision.gameObject.GetComponent<Building>())
		{
			StartCoroutine(MakeDamage(building));
		}
	}

	private void OnCollisionExit2D(Collision2D collision)
	{
		if (collision.gameObject.GetComponent<Building>())
		{
			StopAllCoroutines();
		}
	}

	private IEnumerator MakeDamage (Building b)
	{
		while (b != null)
		{
			b.GetDamage(takeDmg);
			yield return Async.Wait(TimeSpan.FromSeconds(3));
		}
	}

	public void GetDamage (Cint dmgValue)
	{
		CurrentHp -= dmgValue;

		if (CurrentHp <= 0)
		{
			Destroy(this.gameObject);
		}
	}
}
