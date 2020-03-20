using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Market : Building
{
	public override void OnPlace()
	{
		PlayerInstance.Instance.MoneyPerSecond += 1;
	}
}
