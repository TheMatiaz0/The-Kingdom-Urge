using Cyberevolver;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Market : Building
{
	[SerializeField]
	private double moneyPerSecond = 1;

	private bool onlyOnce = false;

	public override void OnPlace()
	{
		base.OnPlace();

		if (onlyOnce == false)
		{
			PlayerInstance.Instance.MoneyPerSecond += moneyPerSecond;
			onlyOnce = true;
		}
	}
}
