﻿using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
	public int currentScore = 0;
	public int highScore;

	private void Awake()
	{
		if (Managers.Game.stats.highScore != 0)
		{
			highScore = Managers.Game.stats.highScore;
			Managers.UI.inGameUI.UpdateScoreUI();
		}
		else
		{
			highScore = 0;
			Managers.UI.inGameUI.UpdateScoreUI();
		}
	}

	public void OnScore(int scoreIncreaseAmount)
	{
		currentScore += scoreIncreaseAmount;
		CheckHighScore();
		Managers.UI.inGameUI.UpdateScoreUI();
		Managers.Game.stats.totalScore += scoreIncreaseAmount;
	}

	public void CheckHighScore()
	{
		if (highScore < currentScore)
		{
			highScore = currentScore;
			Managers.Game.stats.highScore = highScore;
			Managers.UI.inGameUI.UpdateScoreUI();
		}
	}
	
	public void ResetScore()
	{
		currentScore = 0;
		highScore = Managers.Game.stats.highScore;
		Managers.UI.inGameUI.UpdateScoreUI();
	}
}
