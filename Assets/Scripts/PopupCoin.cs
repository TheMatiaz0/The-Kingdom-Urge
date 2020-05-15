using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupCoin : MonoBehaviour
{
	protected void Start()
	{
		LeanTween.scale(this.gameObject, new Vector2(1.5f, 1.5f), 0.4f).setEase(LeanTweenType.easeInBounce).setOnComplete(() => LeanTween.scale(this.gameObject, new Vector2(1, 1), 0.2f));
		LeanTween.moveLocalY(this.gameObject, 100, 4);
	}
}
