using Cyberevolver;
using Cyberevolver.Unity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class PlacementController : AutoInstanceBehaviour<PlacementController>
{
	private GameObject objToPlace = null;
	private SpriteRenderer spriteRender = null;
	private Rigidbody2D rb2D = null;

	[SerializeField]
	private Transform minPoint = null;

	[SerializeField]
	private Transform maxPoint = null;

	public bool WrongCollision { get; set; }

	public void SetupPlacement(GameObject prefab)
	{
		MenuUpdater.Instance.gameObject.SetActive(false);
		objToPlace = Instantiate(prefab, GameObject.FindGameObjectWithTag("BuildingList").transform);
		spriteRender = objToPlace.GetComponent<SpriteRenderer>();
		spriteRender.color = Color.green;
		spriteRender.sortingOrder = 1;
		rb2D = objToPlace.GetComponent<Rigidbody2D>();
		rb2D.bodyType = RigidbodyType2D.Dynamic;
	}

	protected void Update()
	{
		if (objToPlace == null)
		{
			return;
		}

		else
		{
			objToPlace.transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
		}

		if (WrongCollision == true || IsInRange(minPoint.position, maxPoint.position, objToPlace.transform.position) == false)
		{
			spriteRender.color = Color.red;
			return;
		}

		else
		{
			spriteRender.color = Color.green;
		}

		if (Input.GetMouseButtonDown(0) == true)
		{
			RaycastHit2D hit = objToPlace.Ray2DWithoutThis(objToPlace.transform.position, Vector2.down, 200);
			if (hit.collider.tag != "Grass")
			{
				return;
			}

			if (spriteRender != null)
			{
				spriteRender.color = Color.white;
				spriteRender.sortingOrder = 0;
			}

			objToPlace = null;
			spriteRender = null;
		}
	}

	public void OnCollision()
	{
		if (rb2D != null)
		{
			rb2D.bodyType = RigidbodyType2D.Kinematic;
			rb2D = null;
		}
	}

	public bool IsInRange(Vector2 min, Vector2 max, Vector2 value)
	{
		return new Vector2(Math.Max(min.x, Math.Min(max.x, value.x)), Math.Max(min.y, Math.Min(max.y, value.y))) == value;
	}
}
