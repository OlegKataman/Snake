using UnityEngine;
using System.Collections;
using DG.Tweening;

public class CameraManager : MonoBehaviour
{
	public Camera main;

	private float _mainMenuSize = 18f;
	private float _inGameSize = 15.5f;

	[HideInInspector]
	public CameraShake shaker;

	private void Awake()
	{
		shaker = main.gameObject.GetComponent<CameraShake>();
	}

	public void ZoomIn()
	{
		if (main.orthographicSize != _inGameSize)
		{
			main.DOOrthoSize(_inGameSize, 1f).SetEase(Ease.OutCubic).OnComplete(() =>
			{
				StartCoroutine(StartGamePlay());
			});
		}
		else
		{
			Managers.Spawner.HeadSpawn();
			Managers.Game.isGameActive = true;
		}
	}

	public void ZoomOut()
	{
		if (main.orthographicSize != _mainMenuSize)
			main.DOOrthoSize(_mainMenuSize, 1f).SetEase(Ease.OutCubic);
	}

	private IEnumerator StartGamePlay()
	{
		yield return new WaitForEndOfFrame();

		if (!Managers.Game.isGameActive)
		{
			Managers.Spawner.HeadSpawn();
			Managers.Game.isGameActive = true;
		}

		yield break;
	}
}
