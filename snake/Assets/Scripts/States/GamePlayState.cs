using UnityEngine;
using System.Collections;

public class GamePlayState : _StatesBase
{
	private float gamePlayDuration;

	#region implemented abstract members of GameState
	public override void OnActivate()
	{
		Managers.Audio.PlayGameMusic();
		Managers.UI.panel.SetActive(false);
		Managers.UI.ActivateUI(Menus.INGAME);
		gamePlayDuration = Time.time;
		Managers.Camera.ZoomIn();

		if (Managers.Game.snake != null)
			Managers.Game.snake.MovementController.InvokeRepeating("HeadMove", 1f, Managers.Game.snake.MovementController.speed);

		Managers.Spawner.InvokeRepeating("FoodSpawn", 1f, 10.5f);

		Debug.Log("<color=green>Gameplay State</color> OnActive");
	}

	public override void OnDeactivate()
	{
		Managers.Game.stats.timeSpent += Time.time - gamePlayDuration;
		Debug.Log("<color=red>Gameplay State</color> OnDeactivate");
	}

	public override void OnUpdate()
	{
		Debug.Log("<color=yellow>Gameplay State</color> OnUpdate");
	}

	#endregion
}
