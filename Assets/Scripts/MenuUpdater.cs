using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cyberevolver;
using Cyberevolver.Unity;

public class MenuUpdater : AutoInstanceBehaviour<MenuUpdater>
{
	[SerializeField]
	private Text goldInfo = null;

	public bool IsPaused { get; private set; } = true;

	protected void OnEnable()
	{
		IsPaused = true;
	}

	protected void Start()
	{
		PlayerInstance.Instance.OnMoneyChanged += UpdateGoldText;
	}

	protected void OnDisable()
	{
		PlayerInstance.Instance.OnMoneyChanged -= UpdateGoldText;
		IsPaused = false;
	}

	public void UpdateGoldText (object s, Cint v)
	{
		goldInfo.text = $"{v} gold";
	}
}
