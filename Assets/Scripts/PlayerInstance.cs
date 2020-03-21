using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cyberevolver;
using Cyberevolver.Unity;
using UnityEngine.UI;
using System;

public class PlayerInstance : AutoInstanceBehaviour<PlayerInstance>
{
	public event EventHandler<double> OnMoneyChanged = delegate { };
	public event EventHandler<double> OnMoneyPerSecondChanged = delegate { };

	public double CurrentMoney { get { return _CurrentMoney; } set { if (_CurrentMoney != value) { _CurrentMoney = value; } OnMoneyChanged.Invoke(this, _CurrentMoney); } }
	private double _CurrentMoney;

	public double MoneyPerSecond { get { return _MoneyPerSecond; } set { if (_MoneyPerSecond != value) { _MoneyPerSecond = value; } OnMoneyPerSecondChanged.Invoke(this, _MoneyPerSecond); } }
	private double _MoneyPerSecond;

	public Cint MoneyPerClick { get; private set; } = 1;

	public List<Building> BuildingsList { get; private set; } = new List<Building>();

	protected void Start()
	{
		MoneyPerSecond = 1;
	}

	protected void Update()
	{
		CurrentMoney += Time.deltaTime * MoneyPerSecond;

		if (Input.GetKeyDown(KeyCode.Escape))
		{
			MenuUpdater.Instance.gameObject.SetActive(true);
		}
	}
}
