using Cyberevolver;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	public Vector2 TargetPosition { get; set; }

	public float BulletSpeed { get; set; }

	public Cint BulletDamage { get; set; }

	[SerializeField]
	private Rigidbody2D rb2D = null;

	protected void Start()
	{
		Vector2 moveDirection = (TargetPosition - (Vector2)transform.position).normalized;

		rb2D.AddForce(moveDirection * BulletSpeed, ForceMode2D.Impulse);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Building"))
		{
			return;
		}

		Enemy enemy;
		if (enemy = collision.GetComponent<Enemy>())
		{
			enemy.GetDamage(BulletDamage);
		}

		Destroy(this.gameObject);
	}
}
