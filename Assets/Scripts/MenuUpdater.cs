using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cyberevolver;
using Cyberevolver.Unity;

public class MenuUpdater : MonoBehaviour
{
	[SerializeField]
	private Text goldInfo = null;

	protected void Start()
	{
		PlayerInstance.Instance.OnMoneyChanged += UpdateGoldText;
	}

	protected void OnDisable()
	{
		PlayerInstance.Instance.OnMoneyChanged -= UpdateGoldText;
	}

	public void UpdateGoldText (object s, Cint v)
	{
		goldInfo.text = $"{v} gold";
	}
}
