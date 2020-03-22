﻿using Cyberevolver;
using Cyberevolver.Unity;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MenuUpdater : AutoInstanceBehaviour<MenuUpdater>
{
	[SerializeField]
	private Text goldInfo = null;

	[SerializeField]
	private Text perSecondInfo = null;

	[SerializeField]
	private LeanTweenType easeType;

	[SerializeField]
	private GameObject coinButton = null;

	public bool IsPaused { get; private set; } = true;

	protected void OnEnable()
	{
		IsPaused = true;
	}

	public void UpdatePerSecondText(object s, double v)
	{
		perSecondInfo.text = $"Per second: {Math.Round(v)}";
	}

	public void GatherMoneyBtn()
	{
		PlayerInstance player = PlayerInstance.Instance;
		player.CurrentMoney += player.MoneyPerClick;
	}

	protected void OnDisable()
	{
		IsPaused = false;
	}

	public void UpdateMoneyText(object s, double v)
	{
		goldInfo.text = $"{Math.Round(v)} gold";
	}

	public void OnCoinPointerEnter ()
	{
		LeanTween.scale(coinButton, new Vector2(2, 2), 5).setEase(easeType);
	}
}
