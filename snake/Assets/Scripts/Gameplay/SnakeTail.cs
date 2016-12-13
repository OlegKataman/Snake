using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SnakeTail : MonoBehaviour
{
	[HideInInspector]
	public SnakeMovementController MovementController;
	public int countTails = 0;
	public List<Transform> tails = new List<Transform>(); 

	private void Awake()
	{
		MovementController = GetComponent<SnakeMovementController>();
	}

	private void Start()
	{
		if (!Managers.Grid.IsValidGridPosition(this.transform))
		{
			Managers.Game.SetState(typeof(GameOverState));
		}
		else
		{
			AddTail();
		}
	}

	public void AddTail()
	{
		countTails++;

		//if (MovementController.speed != 0.1f)
		MovementController.NewSpeed(0.025f);

		for (int i = tails.Count; i < countTails + 1; ++i)
		{
			Managers.Spawner.TailSpawn();
		}
	}
}
