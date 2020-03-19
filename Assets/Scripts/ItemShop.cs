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

	[SerializeField]
	private UnityAction itemBuyEvent = null;

	[SerializeField]
	private Button buyBtn = null;

	public Image ItemIcon => itemIcon;

	public Text ItemName => itemName;

	public Text ItemPrice => price;

	public UnityAction ItemBuyEvent => itemBuyEvent;

	public Button BuyBtn => buyBtn;

	public void OnBtnClick ()
	{
		BuyBtn.onClick.AddListener(ItemBuyEvent);
	}
}
