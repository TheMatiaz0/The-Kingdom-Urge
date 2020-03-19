using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cyberevolver.Unity;
using Cyberevolver;

public class Building : MonoBehaviour
{
	[SerializeField]
	private Cint startHp = 100;

	[SerializeField]
	private string buildingName = "Building #01";

	[SerializeField]
	private Sprite buildingIcon = null;

	[SerializeField]
	private Cint buildingPrice;

	public Cint BuildingPrice => buildingPrice;

	public Sprite BuildingIcon => buildingIcon;

	public string BuildingName => buildingName;

	public Cint CurrentHp { get; private set; } = 100;

	private void Start()
	{
		CurrentHp = startHp;
	}
}
