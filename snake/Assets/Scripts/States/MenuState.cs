using UnityEngine;
using System.Collections;

public class MenuState : _StatesBase
{
	#region implemented abstract members of GameState
	public override void OnActivate()
	{
		Managers.Audio.StopGameMusic();
		Managers.UI.ActivateUI(Menus.MAIN);
		Managers.Camera.ZoomOut();
		Managers.UI.mainMenu.MainMenuStartAnimation();
		Managers.UI.MainMenuArrange();

		if (Managers.Game.snake != null)
			Managers.Game.snake.MovementController.CancelInvoke("HeadMove");

		Managers.Spawner.CancelInvoke("FoodSpawn");
		Debug.Log("<color=green>Menu State</color> OnActive");
	}

	public override void OnDeactivate()
	{
		Debug.Log("<color=red>Menu State</color> OnDeactivate");
	}

	public override void OnUpdate()
	{
		Debug.Log("<color=yellow>Menu State</color> OnUpdate");
	}

	#endregion
}
