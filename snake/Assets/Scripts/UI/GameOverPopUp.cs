﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameOverPopUp : MonoBehaviour
{
	public Text gameOverScore;

	private void OnEnable()
	{
		gameOverScore.text = Managers.Score.currentScore.ToString();
		Managers.UI.panel.SetActive(true);
	}

	public void BackToMainMenu()
	{
		//Managers.Grid.ClearBoard();
		Managers.Audio.PlayUIClick();
		Managers.UI.panel.SetActive(false);
		Managers.Game.SetState(typeof(MenuState));
		gameObject.SetActive(false);
	}
}