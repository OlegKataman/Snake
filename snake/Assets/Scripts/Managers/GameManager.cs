using UnityEngine;

public class GameManager : MonoBehaviour
{
	public bool isGameActive;
	public PlayerStats stats;
	public SnakeTail snake;
	public Transform snakeHolder;
	public Transform foodHolder;

	private void Awake()
	{
		isGameActive = false;
	}

	private _StatesBase currentState;
	public _StatesBase State
	{
		get { return currentState; }
	}

	public void SetState(System.Type newStateType)
	{
		if (currentState != null)
		{
			currentState.OnDeactivate();
		}

		currentState = GetComponentInChildren(newStateType) as _StatesBase;
		if (currentState != null)
		{
			currentState.OnActivate();
		}
	}

	private void Update()
	{
		if (currentState != null)
		{
			currentState.OnUpdate();
		}
	}

	private void Start()
	{
		SetState(typeof(MenuState));
	}
}
