using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Castle : Building
{
	public override void OnPlace()
	{

	}

	public override void OnDamageFull()
	{
		Debug.Log("You lose, mate.");
	}
}
