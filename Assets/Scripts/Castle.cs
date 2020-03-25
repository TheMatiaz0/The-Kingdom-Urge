using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Castle : Shootable
{
	public override void OnDamageFull()
	{
		PlayerInstance.Instance.SetGameOver();
	}
}
