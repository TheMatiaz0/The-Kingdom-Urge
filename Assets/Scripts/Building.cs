using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cyberevolver.Unity;
using Cyberevolver;
using UnityEngine.UI;

public class Building : MonoBehaviour, IBuyable
{
	[SerializeField]
	private Cint startHp = 100;

	[SerializeField]
	private string buildingName = "Building #01";

	[SerializeField]
	private Sprite buildingIcon = null;

	[SerializeField]
	private Cint buildingPrice;

	public Cint BuildingPrice => buildingPrice;

	public Sprite BuildingIcon => buildingIcon;

	public string BuildingName => buildingName;

	public Cint CurrentHp { get; private set; } = 100;

	public void OnBuy()
	{
		if (PlayerInstance.Instance.CurrentMoney >= BuildingPrice)
		{
			PlayerInstance.Instance.CurrentMoney -= BuildingPrice;
			Place();
		}

		else
		{
			Debug.Log("No money, sry buddy.");
		}
	}

	private void Start()
	{
		CurrentHp = startHp;
	}
	
	private void Place() 
	{
		PlacementController.Instance.SetupPlacement(this.gameObject);
	}
}
