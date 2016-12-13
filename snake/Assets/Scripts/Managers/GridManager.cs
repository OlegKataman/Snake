using UnityEngine;
using System.Collections;

[System.Serializable]
public class Column
{
	public Transform[] row = new Transform[27];
}

public class GridManager : MonoBehaviour
{
	public Column[] gameGridcol = new Column[49];
	
	public GameObject blockPrefab;
	
	public bool InsideBorder(Vector2 pos)
	{
		return ((int)pos.x >= 0 && (int)pos.x <= 49 && (int)pos.y >= 0 && (int)pos.y <= 27);
	}

	public bool IsValidGridPosition(Transform obj)
	{
		Vector2 v = Vector2Extension.roundVec2(obj.position);

		if (!InsideBorder(v))
			return false;

		if (gameGridcol[(int) v.x].row[(int) v.y] != null)
		{
			if (obj.gameObject.tag.Equals("Snake"))
			{
				if (gameGridcol[(int) v.x].row[(int) v.y].gameObject.tag.Equals("Food"))
				{
					Managers.Audio.PlayEatSound();
					Managers.Game.snake.AddTail();
					Managers.Score.OnScore(1);
					Destroy(gameGridcol[(int)v.x].row[(int)v.y].gameObject);
				}
				else
				{
					return false;
				}
			}
			else
			{
				return false;
			}
		}

		return true;
	}

	public void UpdateGrid(Transform obj)
	{
		for (int y = 0; y < 27; ++y)
		{
			for (int x = 0; x < 49; ++x)
			{
				if (gameGridcol[x].row[y] != null)
				{
					gameGridcol[x].row[y] = null;
				}
			}
		}

		foreach (Transform child in Managers.Game.snakeHolder)
		{
			Vector2 v = Vector2Extension.roundVec2(child.position);
			gameGridcol[(int)v.x].row[(int)v.y] = child;
		}
		
		foreach (Transform child in Managers.Game.foodHolder)
		{
			Vector2 v = Vector2Extension.roundVec2(child.position);
			gameGridcol[(int)v.x].row[(int)v.y] = child;
		}
	}

	public void ClearBoard()
	{
		for (int y = 0; y < 27; ++y)
		{
			for (int x = 0; x < 49; ++x)
			{
				if (gameGridcol[x].row[y] != null)
				{
					Destroy(gameGridcol[x].row[y].gameObject);
					gameGridcol[x].row[y] = null;
				}
			}
		}
	}
	
	private void Start()
	{
		PaintBoard();
	}
	
	public void PaintBoard()
	{
		for (int y = 0; y < 27; ++y)
		{
			for (int x = 0; x < 49; ++x)
			{
				Instantiate(blockPrefab, new Vector2(x, y), Quaternion.identity);
			}
		}
	}
}
