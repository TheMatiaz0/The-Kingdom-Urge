﻿using System.Collections;
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
	private Cint buildingPrice = 10;

	public Cint BuildingPrice => buildingPrice;

	public Sprite BuildingIcon => buildingIcon;

	public string BuildingName => buildingName;

	public Cint CurrentHp { get; private set; } = 100;

	public void OnBuy()
	{
		PlayerInstance player = PlayerInstance.Instance;

		if (player.CurrentMoney >= BuildingPrice)
		{
			player.CurrentMoney -= BuildingPrice;
			Place();
		}

		else
		{
			Debug.Log("No money, sry buddy.");
		}
	}

	public virtual void OnPlace()
	{
		
	}

	public virtual void OnDamageFull()
	{
		Destroy(this.gameObject);
	}

	public void GetDamage (Cint dmgHp)
	{
		CurrentHp -= dmgHp;

		if (CurrentHp <= 0)
		{
			OnDamageFull();
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

	/*
	private void OnTriggerEnter2D(Collider2D collision)
	{
		switch (collision.tag)
		{
			case "Building":
				PlacementController.Instance.WrongCollision = true;
				break;
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		switch (collision.tag)
		{
			case "Building":
				PlacementController.Instance.WrongCollision = false;
				break;
		}
	}
	*/

	private void OnCollisionEnter2D(Collision2D collision)
	{
		switch (collision.gameObject.tag)
		{
			case "Grass":
				PlacementController.Instance.OnCollision();
				OnPlace();
				break;
		}
	}
}
