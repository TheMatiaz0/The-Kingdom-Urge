using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cyberevolver.Unity;
using Cyberevolver;
using System;

[Serializable]
public class Kingdom
{
	public List<BuildingData> BuildingList { get; } = new List<BuildingData>();
	public string Nickname { get; }
	public double CurrentMoney { get; }


	public Kingdom(List<BuildingData> buildingList, string nickname, double currentMoney)
	{
		BuildingList = buildingList;
		Nickname = nickname;
		CurrentMoney = currentMoney;
	}

	public Kingdom()
	{

	}
}
