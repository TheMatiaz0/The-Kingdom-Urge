using Cyberevolver.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cyberevolver;

public class Enemy : MonoBehaviour
{
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

	protected void FixedUpdate()
	{
		rb2D.MovePosition((Vector2)transform.position + targetDirection * speed * Time.deltaTime);
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		Building building;

		if (building = collision.gameObject.GetComponent<Building>())
		{
			MakeDamage(building);
		}
	}

	private void MakeDamage (Building b)
	{
		b.GetDamage(takeDmg);
	}
}
