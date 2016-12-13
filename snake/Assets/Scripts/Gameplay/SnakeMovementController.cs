using UnityEngine;
using System.Collections;

public enum DirectionType
{
	Up,
	Down,
	Left,
	Right
}

public class SnakeMovementController : MonoBehaviour
{
	[HideInInspector]
	public DirectionType direction = DirectionType.Left;
	public float speed;

	private void Awake()
	{
		InvokeRepeating("HeadMove", 1f, speed);
	}

	public void HeadMove()
	{
		if (Managers.Game.snake.tails.Count > 1)
			TailsMove();

		switch (direction)
		{
			case DirectionType.Up:
				MoveVertical(Vector2.up);
				break;

			case DirectionType.Down:
				MoveVertical(Vector2.down);
				break;

			case DirectionType.Left:
				MoveHorizontal(Vector2.left);
				break;

			case DirectionType.Right:
				MoveHorizontal(Vector2.right);
				break;
		}
	}

	public void TailsMove()
	{
		for (int i = Managers.Game.snake.countTails; i > 0; --i)
		{
			Managers.Game.snake.tails[i].transform.position = Managers.Game.snake.tails[i - 1].transform.position;
		}
	}

	public void MoveHorizontal(Vector2 dir)
	{
		float deltaMovement = (dir.Equals(Vector2.right)) ? 1.0f : -1.0f;

		transform.rotation = Quaternion.AngleAxis(deltaMovement * 90f, Vector3.forward);
		transform.position += new Vector3(deltaMovement, 0, 0);
		Managers.Audio.PlayDropSound();

		if (Managers.Grid.IsValidGridPosition(this.transform))
		{
			Managers.Grid.UpdateGrid(this.transform);
		}
		else
		{
			transform.position = new Vector3(-deltaMovement, 0, 0);
			enabled = false;
			Managers.Game.SetState(typeof(GameOverState));
		}
	}

	public void MoveVertical(Vector2 dir)
	{
		float deltaMovement = (dir.Equals(Vector2.up)) ? 1.0f : -1.0f;

		if (deltaMovement == 1.0f)
			transform.rotation = Quaternion.AngleAxis(deltaMovement * 180f, Vector3.forward);
		else
			transform.rotation = Quaternion.AngleAxis(deltaMovement * 360f, Vector3.forward);

		transform.Rotate(dir, Time.deltaTime, Space.World);
		transform.position += new Vector3(0, deltaMovement, 0);
		Managers.Audio.PlayDropSound();

		if (Managers.Grid.IsValidGridPosition(this.transform))
		{
			Managers.Grid.UpdateGrid(this.transform);
		}
		else
		{
			transform.position = new Vector3(0, -deltaMovement, 0);
			enabled = false;
			Managers.Game.SetState(typeof(GameOverState));
		}
	}

	public void NewSpeed(float speedIncreaseAmount)
	{
		speed -= speedIncreaseAmount;

		if (speed < 0.1f)
			speed = 0.1f;

		CancelInvoke("HeadMove");
		InvokeRepeating("HeadMove", 1f, speed);
	}
}
