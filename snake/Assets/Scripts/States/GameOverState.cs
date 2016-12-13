using UnityEngine;
using System.Collections;

public class GameOverState : _StatesBase
{
	#region implemented abstract members of GameState

	public override void OnActivate()
	{
		Managers.Game.isGameActive = false;
		Managers.Game.snake.MovementController.CancelInvoke("HeadMove");
		Managers.Spawner.CancelInvoke("FoodSpawn");
		Managers.Game.stats.highScore = Managers.Score.currentScore;
		Managers.Game.stats.numberOfGames++;
		Managers.UI.popUps.ActivateGameOverPopUp();
		Managers.Audio.PlayLoseSound();
		Managers.Grid.ClearBoard();
		Debug.Log("<color=green>Game Over State</color> OnActive");
	}

	public override void OnDeactivate()
	{
		Debug.Log("<color=red>Game Over State</color> OnDeactivate");
	}

	public override void OnUpdate()
	{
		Debug.Log("<color=yellow>Game Over State</color> OnUpdate");
	}

	#endregion
}
