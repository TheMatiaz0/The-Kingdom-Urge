using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverObject : MonoBehaviour
{
	[SerializeField]
	private Text scoreText = null;

	[SerializeField]
	private Text bestScoreText = null;

	[SerializeField]
	private Text kingName = null;


	protected void OnEnable()
	{
		scoreText.text = PlayerInstance.Instance.CurrentMoney.ToString();
	}


	public void ContinueBtn ()
	{
		SceneManager.LoadScene("MainGame");
	}
}
