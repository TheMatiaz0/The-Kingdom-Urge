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
	private Vector2 moveDirection = Vector2.right;

	public Vector2 MoveDirection => moveDirection;
}
