using Cyberevolver;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cyberevolver.Unity;
using System;

[Serializable]
public class BuildingData
{
	public Cint CurrentHp { get; }
	public SerializeVector2 Position { get; }
	public string Name { get; }

	public BuildingData()
	{

	}

	public BuildingData(Cint currentHp, SerializeVector2 position, string name)
	{
		CurrentHp = currentHp;
		Position = position;
		Name = name;
	}
}
