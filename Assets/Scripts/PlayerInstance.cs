using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cyberevolver;
using Cyberevolver.Unity;
using UnityEngine.UI;
using System;

public class PlayerInstance : AutoInstanceBehaviour<PlayerInstance>
{
	public double CurrentMoney { get { return _CurrentMoney; } set { if (_CurrentMoney != value) { _CurrentMoney = value; } MenuUpdater.Instance.UpdateMoneyText(this, _CurrentMoney); } }
	private double _CurrentMoney;

	public double MoneyPerSecond { get { return _MoneyPerSecond; } set { if (_MoneyPerSecond != value) { _MoneyPerSecond = value; } MenuUpdater.Instance.UpdatePerSecondText(this, _MoneyPerSecond); } }
	private double _MoneyPerSecond;

	public Cint MoneyPerClick { get; private set; } = 1;

	public List<Building> BuildingsList { get; private set; } = new List<Building>();

	protected void Start()
	{
		// MoneyPerSecond = 1;
	}

	protected void Update()
	{
		UpdateMoneyPerSecond();

		if (Input.GetKeyDown(KeyCode.Escape))
		{
			MenuUpdater.Instance.gameObject.SetActive(true);
		}

		if (Input.GetKeyDown(KeyCode.V))
		{
			Spawner.Instance.StartSpawn();
		}
	}

	private void UpdateMoneyPerSecond ()
	{
		CurrentMoney += Time.deltaTime * MoneyPerSecond;
	}
}
