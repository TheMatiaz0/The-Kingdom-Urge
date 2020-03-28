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

	public string Nickname { get; set; } = "...";

	public Cint MoneyPerClick { get; private set; } = 1;

	public bool IsGameOver { get; private set; }

	[SerializeField]
	private FreezeMenu gameOverManager = null;

	public List<Building> BuildingList { get; private set; } = new List<Building>();

	protected void Start()
	{
		MenuUpdater.Instance.NicknameText.text = $"{Nickname}'s Kingdom";
	}

	protected void Update()
	{
		if (IsGameOver)
		{
			return;
		}

		UpdateMoneyPerSecond();

		if (Input.GetKeyDown(KeyCode.V))
		{
			Spawner.Instance.StartSpawn();
		}

		if (Input.GetKeyDown(KeyCode.F1))
		{
			List<BuildingData> buildingsConverted = new List<BuildingData>();

			foreach (Building item in BuildingList)
			{
				buildingsConverted.Add(new BuildingData(item.CurrentHp, (Vector2)item.transform.position, item.BuildingName));
			}

			Kingdom save = new Kingdom(buildingsConverted, Nickname, CurrentMoney);


			SaveControl.SaveObject(save, "save#01");
		}

		if (Input.GetKeyDown(KeyCode.F2))
		{
			Kingdom save = SaveControl.TryLoad<Kingdom>("save#01");
			Nickname = save.Nickname;
			CurrentMoney = save.CurrentMoney;
			foreach (BuildingData item in save.BuildingList)
			{
				GameObject prefab = Instantiate(Resources.Load<GameObject>($"Prefab/{item.Name}"), item.Position.Vector2, Quaternion.identity, GameObject.FindGameObjectWithTag("BuildingList").transform);
				Building building = prefab.GetComponent<Building>();
				building.CurrentHp = item.CurrentHp;
				building.OnPlace();
			}
		}
	}

	private void UpdateMoneyPerSecond ()
	{
		CurrentMoney += Time.deltaTime * MoneyPerSecond;
	}

	public void SetGameOver ()
	{
		IsGameOver = true;
		MenuUpdater.Instance?.gameObject?.SetActive(false);
		gameOverManager.EnableMenuWithPause(true);
	}
}
