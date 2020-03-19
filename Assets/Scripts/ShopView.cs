using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cyberevolver;
using Cyberevolver.Unity;

public class ShopView : MonoBehaviour
{
	[SerializeField] private Building[] allBuildings;

	[SerializeField] private Transform parentSpawner = null;

	[SerializeField] private GameObject shopItem = null;

	protected void Start()
	{
		parentSpawner.KillAllChild();

		foreach (Building b in allBuildings)
		{
			GameObject newObject = Instantiate(shopItem, parentSpawner);
			ItemShop newItemShop = newObject.GetComponent<ItemShop>();
			newItemShop.ItemName.text = b.BuildingName;
			newItemShop.ItemIcon.sprite = b.BuildingIcon;
			newItemShop.ItemPrice.text = b.BuildingPrice.ToString();		
		}
	}
}
