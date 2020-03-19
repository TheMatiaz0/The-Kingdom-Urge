using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ItemShop : MonoBehaviour
{
	[SerializeField]
	private Image itemIcon = null;

	[SerializeField]
	private Text itemName = null;

	[SerializeField]
	private Text price = null;

	public Image ItemIcon => itemIcon;

	public Text ItemName => itemName;

	public Text ItemPrice => price;

	public UnityAction itemBuyAction = null;

	public void OnBtnClick ()
	{
		itemBuyAction.Invoke();
	}
}
