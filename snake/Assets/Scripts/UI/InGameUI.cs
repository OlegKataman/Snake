using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;

public class InGameUI : MonoBehaviour
{
	public Text score;
	public Text highScore;
	public GameObject gameButtons;

	public GameObject gameOverPopUp;

	public void UpdateScoreUI()
	{
		score.text = Managers.Score.currentScore.ToString();
		highScore.text = Managers.Score.highScore.ToString();
	}

	public void InGameUIStartAnimation()
	{
		gameButtons.GetComponent<RectTransform>().DOAnchorPosY(45, 1, true);
	}
	
	public void InGameUIEndAnimation()
	{
		gameButtons.GetComponent<RectTransform>().DOAnchorPosY(90, 1, true);
	}
}