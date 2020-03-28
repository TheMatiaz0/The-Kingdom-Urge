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
	public GameObject ObjToPlace => objToPlace;
	private SpriteRenderer spriteRender = null;
	private Rigidbody2D rb2D = null;

	[SerializeField]
	private Transform minPoint = null;

	[SerializeField]
	private Transform maxPoint = null;

	private Building b = null;

	public bool WrongCollision { get; set; }

	private RaycastHit2D hitLeft;
	private RaycastHit2D hitRight;

	public void SetupPlacement(GameObject prefab)
	{
		MenuUpdater.Instance.ChangeViewToActive();
		objToPlace = Instantiate(prefab, GameObject.FindGameObjectWithTag("BuildingList").transform);
		spriteRender = objToPlace.GetComponent<SpriteRenderer>();
		spriteRender.color = Color.green;
		spriteRender.sortingOrder = 1;
		rb2D = objToPlace.GetComponent<Rigidbody2D>();
		rb2D.bodyType = RigidbodyType2D.Dynamic;
		b = objToPlace.GetComponent<Building>();
	}

	protected void FixedUpdate()
	{
		if (objToPlace == null)
			return;

		hitLeft = objToPlace.Ray2DWithoutThis(b.BuildingStartX.position, Vector2.down, 200);
		hitRight = objToPlace.Ray2DWithoutThis(b.BuildingEndX.position, Vector2.down, 200);
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

		if (hitLeft.transform?.tag != "Grass" || hitRight.transform?.tag != "Grass" || WrongCollision == true || IsInRange(minPoint.position, maxPoint.position, objToPlace.transform.position) == false)
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
			if (b.CanBuy() == false)
			{
				return;
			}

			if (spriteRender != null)
			{
				spriteRender.color = Color.white;
				spriteRender.sortingOrder = 0;
				spriteRender = null;
			}

			objToPlace = null;
		}
	}

	public void OnCollision()
	{
		if (objToPlace != null)
		{
			return;
		}

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
