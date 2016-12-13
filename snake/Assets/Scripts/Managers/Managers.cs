using UnityEngine;
using System.Collections;

[RequireComponent(typeof(GridManager))]
[RequireComponent(typeof(SpawnManager))]
[RequireComponent(typeof(InputManager))]
[RequireComponent(typeof(GameManager))]
[RequireComponent(typeof(ScoreManager))]
[RequireComponent(typeof(UIManager))]
[RequireComponent(typeof(AudioManager))]
[RequireComponent(typeof(CameraManager))]
public class Managers : MonoBehaviour
{
	private static GridManager _gridManager;
	public static GridManager Grid
	{
		get { return _gridManager; }
	}

	private static SpawnManager _spawnManager;
	public static SpawnManager Spawner
	{
		get { return _spawnManager; }
	}

	private static InputManager _inputManager;
	public static InputManager Input
	{
		get { return _inputManager; }
	}

	private static GameManager _gameManager;
	public static GameManager Game
	{
		get { return _gameManager; }
	}

	private static ScoreManager _scoreManager;
	public static ScoreManager Score
	{
		get { return _scoreManager; }
	}

	private static UIManager _uiManager;
	public static UIManager UI
	{
		get { return _uiManager; }
	}

	private static AudioManager _audioManager;
	public static AudioManager Audio
	{
		get { return _audioManager; }
	}

	private static CameraManager _cameraManager;
	public static CameraManager Camera
	{
		get { return _cameraManager; }
	}

	private void Awake()
	{
		_gridManager = GetComponent<GridManager>();
		_spawnManager = GetComponent<SpawnManager>();
		_inputManager = GetComponent<InputManager>();
		_gameManager = GetComponent<GameManager>();
		_scoreManager = GetComponent<ScoreManager>();
		_uiManager = GetComponent<UIManager>();
		_audioManager = GetComponent<AudioManager>();
		_cameraManager = GetComponent<CameraManager>();
	}
}
