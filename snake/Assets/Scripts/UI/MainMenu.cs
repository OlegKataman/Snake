using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;

public class MainMenu : MonoBehaviour
{
	public GameObject menuButtons;
	public GameObject restartButton;

	public HorizontalLayoutGroup layout;

	void Awake()
	{
		layout = GetComponent<HorizontalLayoutGroup>();
	}

	void OnEnable()
	{
		menuButtons.SetActive(true);
	}

	void OnDisable()
	{
		menuButtons.SetActive(false);
	}

	public void DisableMenuButtons()
	{
		menuButtons.SetActive(false);
	}

	public void MainMenuStartAnimation()
	{
		menuButtons.GetComponent<RectTransform>().DOAnchorPosY(470, 1, true);
	}
	
	public void MainMenuEndAnimation()
	{
		menuButtons.GetComponent<RectTransform>().DOAnchorPosY(650, 0.3f, true);
	}
}

