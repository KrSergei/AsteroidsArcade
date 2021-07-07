using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyUFO : MonoBehaviour
{
    [SerializeField]
    private int scoreValue = 1000; //Очки за уничтожение объекта

    private GameController gameController;

    private void Start()
    {
        //Получение объекта GameController
        gameController = FindObjectOfType<GameController>();
        //Если найден объект GameController
        if (gameController != null)
        {
            //Получение компонента GameController
            gameController = gameController.GetComponent<GameController>();

        }
        else
            Debug.Log("GameController don't find");
    }

    /// <summary>
    /// Метод уничтожения объекта
    /// </summary>
    public void StartDestroy()
    {
        gameController.PlayDestroyUFO();
        //Декремент количества объектов
        gameController.GetComponent<SpawnEnemy>().SubstractionSpanedOnj();
        //Подсчет очков за уничтоженный астероид
        gameController.CalculateScore(scoreValue);
        //Уничтожение объекта
        Destroy(gameObject);
    }
}
