using UnityEngine;
using System.Collections;

public enum InputMethod
{
	KeyboardInput,
	MouseInput,
	TouchInput
}

public class InputManager : MonoBehaviour
{
	public bool isActive;
	public InputMethod inputType;

	private void Update()
	{
		if (isActive)
		{
			if (inputType == InputMethod.KeyboardInput)
				KeyboardInput();
			else if (inputType == InputMethod.MouseInput)
				MouseInput();
			else
				TouchInput();
		}
	}

	#region KEYBOARD
	private void KeyboardInput()
	{
		if (Input.GetKeyDown(KeyCode.LeftArrow) &&
				Managers.Game.snake.MovementController.direction != DirectionType.Right)
					Managers.Game.snake.MovementController.direction = DirectionType.Left;

		else if (Input.GetKeyDown(KeyCode.RightArrow) &&
			Managers.Game.snake.MovementController.direction != DirectionType.Left)
				Managers.Game.snake.MovementController.direction = DirectionType.Right;

		else if (Input.GetKeyDown(KeyCode.UpArrow) && 
			Managers.Game.snake.MovementController.direction != DirectionType.Down)
				Managers.Game.snake.MovementController.direction = DirectionType.Up;

		else if (Input.GetKeyDown(KeyCode.DownArrow) && 
			Managers.Game.snake.MovementController.direction != DirectionType.Up)
				Managers.Game.snake.MovementController.direction = DirectionType.Down;
	}
	#endregion

	#region MOUSE
	Vector2 _startPressPosition;
	Vector2 _endPressPosition;
	Vector2 _currentSwipe;
	float _buttonDownPhaseStart;
	public float tapInterval;

	private void MouseInput()
	{
		if (Input.GetMouseButtonDown(0))
		{
			_startPressPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
			_buttonDownPhaseStart = Time.time;
		}

		if (Input.GetMouseButtonUp(0))
		{
			if (Time.time - _buttonDownPhaseStart > tapInterval)
			{
				_endPressPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
				_currentSwipe = new Vector2(_endPressPosition.x - _startPressPosition.x, _endPressPosition.y - _startPressPosition.y);
				_currentSwipe.Normalize();
				
				if (_currentSwipe.x < 0 && _currentSwipe.y > -0.5f && _currentSwipe.y < 0.5f &&
					Managers.Game.snake.MovementController.direction != DirectionType.Right)
						Managers.Game.snake.MovementController.direction = DirectionType.Left;

				if (_currentSwipe.x > 0 && _currentSwipe.y > -0.5f && _currentSwipe.y < 0.5f &&
					Managers.Game.snake.MovementController.direction != DirectionType.Left)
						Managers.Game.snake.MovementController.direction = DirectionType.Right;

				if (_currentSwipe.y < 0 && _currentSwipe.x > -0.5f && _currentSwipe.x < 0.5f &&
					Managers.Game.snake.MovementController.direction != DirectionType.Up)
						Managers.Game.snake.MovementController.direction = DirectionType.Down;
				
				if (_currentSwipe.y > 0 && _currentSwipe.x > -0.5f && _currentSwipe.x < 0.5f &&
					Managers.Game.snake.MovementController.direction != DirectionType.Down)
					Managers.Game.snake.MovementController.direction = DirectionType.Up;
			}
		}
	}
	#endregion

	#region TOUCH
	private void TouchInput()
	{
		
	}
	#endregion
}
