using Cyberevolver;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBuyable
{
	Cint BuildingPrice { get; }

	void OnBuy();
}
