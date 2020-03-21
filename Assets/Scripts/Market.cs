using Cyberevolver;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Market : Building
{
	[SerializeField]
	private double moneyPerSecond = 1;

	public override void OnPlace()
	{
		PlayerInstance.Instance.MoneyPerSecond += moneyPerSecond;
	}
}
