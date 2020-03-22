using Cyberevolver.Unity;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TransformWithDirection
{
	[SerializeField]
	private Transform objectTransform = null;

	public Transform ObjectTransform => objectTransform;

	[SerializeField]
	private Direction moveDirection = Direction.Right;

	public Direction MoveDirection => moveDirection;
}
