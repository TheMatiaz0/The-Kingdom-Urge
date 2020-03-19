using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cyberevolver;
using Cyberevolver.Unity;

public class PlacementController : AutoInstanceBehaviour<PlacementController>
{
	private GameObject objToPlace = null;

	public void SetupPlacement (GameObject prefab)
	{
		MenuUpdater.Instance.gameObject.SetActive(false);
		objToPlace = Instantiate(prefab, GameObject.FindGameObjectWithTag("BuildingList").transform);
	}

	protected void Update()
	{
		if (objToPlace != null)
		{
			objToPlace.transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
		}
	}
}
