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
	private float speed;

	[SerializeField]
	private Direction targetDirection;

	[SerializeField]
	private Cint takeDmg;

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
