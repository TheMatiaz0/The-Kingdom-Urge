using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cyberevolver.Unity;
using Cyberevolver;
using UnityEngine.UI;
using System;

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

	[SerializeField]
	private Transform buildingStartX = null;

	public Transform BuildingStartX => buildingStartX;

	[SerializeField]
	private Transform buildingEndX = null;

	public Transform BuildingEndX => buildingEndX;

	public Cint BuildingPrice => buildingPrice;

	public Sprite BuildingIcon => buildingIcon;

	public string BuildingName => buildingName;

	public Cint CurrentHp { get; private set; } = 100;

	public void OnBuy()
	{
		Place();
	}

	public bool CanBuy ()
	{
		PlayerInstance player = PlayerInstance.Instance;

		if (player.CurrentMoney >= BuildingPrice)
		{
			player.CurrentMoney -= BuildingPrice;
			return true;
		}

		else
		{
			Debug.Log("No money, sry buddy.");
			return false;
		}
	}

	public virtual void OnPlace()
	{
		PlayerInstance.Instance.BuildingsList.Add(this);
	}

	public virtual void OnDamageFull()
	{
		Destroy(this.gameObject);
	}

	public void GetDamage (Cint dmgHp)
	{
		CurrentHp -= dmgHp;
		Debug.Log($"{this.gameObject.name}: {CurrentHp}");

		if (CurrentHp <= 0)
		{
			OnDamageFull();
			StopAllCoroutines();
			return;
		}

		StartCoroutine(QuickColorChange());
	}

	private IEnumerator QuickColorChange()
	{
		LeanTween.color(this.gameObject, Color.red, 0.1f);
		yield return Async.Wait(TimeSpan.FromSeconds(1));
		LeanTween.color(this.gameObject, Color.white, 2f);
	}

	public virtual void Start()
	{
		CurrentHp = startHp;
	}

	public virtual void Update ()
	{
	}
	
	private void Place() 
	{
		PlacementController.Instance.SetupPlacement(this.gameObject);
	}

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
