using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPlayer : MonoBehaviour
{
    public float timeBeetwenBlink = 0.5f; //Время между бликами

    public int countBlink = 5; //Количество бликов игрока после столкновения с объектов

    private GameController gameController;

    [SerializeField]
    private bool isAllive = true; //Флаг, что игрок жив

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


    private void OnTriggerEnter2D(Collider2D col)
    {
        //Проверка состояния игрока
        if(isAllive)
            //Если есть столкновение с объектом Enemy
            if (col.CompareTag("Enemy") || col.CompareTag("UFO"))
            {
                isAllive = false;
                StartCoroutine(BlinkBody());
                gameController.CalcLife();
            }
    }

    /// <summary>
    /// Корутина имитации мигания при столкновении
    /// </summary>
    /// <returns></returns>
    IEnumerator BlinkBody()
    {
        for (int i = 0; i < countBlink; i++)
        {
            //Отключения компонента SpriteRenderer
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            //Пауза
            yield return new WaitForSeconds(timeBeetwenBlink);
            //Включения компонента SpriteRenderer
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            //Пауза
            yield return new WaitForSeconds(timeBeetwenBlink);
        }
        //Сброс флага
        isAllive = true;
    }
}
