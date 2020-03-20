using Cyberevolver.Unity;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class GameObjectExtension
{
    public static RaycastHit2D Ray2DWithoutThis(this GameObject g, Vector2 from, Direction dir, float distance)
    {
        return Physics2D.RaycastAll(from, dir, distance)
            .FirstOrDefault(item => item.collider != null && item.collider.gameObject != g);
    }
}
