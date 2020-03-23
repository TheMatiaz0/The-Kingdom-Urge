using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveUI : MonoBehaviour
{
	public void GoMenuUpdater ()
	{
		MenuUpdater.Instance.gameObject.SetActive(true);
		this.gameObject.SetActive(false);
	}
}
