using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour
{
	public GameObject HeadPrefab;
	public GameObject TailPrefab;
	public GameObject FoodPrefab;

	public void HeadSpawn()
	{
		GameObject temp = (GameObject)Instantiate(HeadPrefab, new Vector2(17, 10), Quaternion.identity);
		temp.transform.SetParent(Managers.Game.snakeHolder);
		temp.gameObject.name = "Head";
		Managers.Game.snake = temp.GetComponent <SnakeTail>();
		Managers.Game.snake.tails.Add(temp.transform);
		Managers.Input.isActive = true;
	}

	public void TailSpawn()
	{
		if (Managers.Game.snake != null)
		{
			GameObject temp = (GameObject)Instantiate(TailPrefab, Managers.Game.snake.tails[0].position, Quaternion.identity);
			temp.transform.SetParent(Managers.Game.snakeHolder);
			Managers.Game.snake.tails.Add(temp.transform);
		}
	}
	
	public void FoodSpawn()
	{
		if (Managers.Game.foodHolder.parent == null)
		{
			GameObject temp = (GameObject)Instantiate(FoodPrefab, new Vector2(Random.Range(2, 29), Random.Range(2, 14)), Quaternion.identity);
			temp.transform.SetParent(Managers.Game.foodHolder);

			if (Managers.Grid.IsValidGridPosition(this.transform))
				Managers.Grid.UpdateGrid(this.transform);
			else
				Destroy(temp);

			Destroy(temp, 10f);
		}
	}
}
