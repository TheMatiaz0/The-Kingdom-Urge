using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cyberevolver;
using Cyberevolver.Unity;
using UnityEngine.UI;
using System;

public class PlayerInstance : AutoInstanceBehaviour<PlayerInstance>
{
	public EventHandler<Cint> OnMoneyChanged = delegate { };

	public Cint CurrentMoney { get { return _CurrentMoney; } set { _CurrentMoney = value; OnMoneyChanged.Invoke(this, _CurrentMoney); } }
	private Cint _CurrentMoney;

	public Cint MoneyPerSecond { get; set; } = 20;

	public Cint MoneyPerClick { get; private set; } = 1;

	public List<Building> BuildingsList { get; private set; } = new List<Building>();

	public void GatherMoneyBtn ()
	{
		CurrentMoney += MoneyPerClick;
	}

	protected void Start()
	{
		InvokeRepeating((m) => StartCoroutine(AddMoneyPerSecond()), TimeSpan.FromSeconds(1));
	}


	public IEnumerator AddMoneyPerSecond()
	{
		Cint i = 1;

		while (i < MoneyPerSecond)
		{
			CurrentMoney += 1;
			i++;

			yield return Async.Wait(TimeSpan.FromMilliseconds(900));
		}
	}

	protected void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			MenuUpdater.Instance.gameObject.SetActive(true);
		}
	}
}
