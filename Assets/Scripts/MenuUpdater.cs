using Cyberevolver;
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
	private LeanTweenType easeTypeIn;

	[SerializeField]
	private LeanTweenType easeTypeOut;

	[SerializeField]
	private float animationSpeed = 1;

	[SerializeField]
	private GameObject coinButton = null;

	[SerializeField]
	private Vector2 scale;

	[SerializeField]
	private GameObject activeUI = null;

	[SerializeField]
	private Text nicknameText = null;

	public Text NicknameText => nicknameText;

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
		LeanTween.scale(coinButton, scale, animationSpeed).setEase(easeTypeIn).setOnComplete(() => LeanTween.scale(coinButton, new Vector2(1, 1), animationSpeed / 2).setEase(easeTypeOut));
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
		// LeanTween.scale(coinButton, scale, animationSpeed).setEase(easeTypeIn);
	}

	public void OnCoinPointerExit ()
	{
		// LeanTween.scale(coinButton, new Vector2(1, 1), animationSpeed).setEase(easeTypeOut);
	}

	public void ChangeViewToActive ()
	{
		activeUI.SetActive(true);
		this.gameObject.SetActive(false);
	}
}
