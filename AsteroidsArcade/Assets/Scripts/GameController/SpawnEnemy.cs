using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject enemyPrefab; //Enemy prefab
    [SerializeField]
    private float timeSpawn = 15f; //Время, через которое генерируется объект 
    [SerializeField]
    private float remainingTime; //Оставшееся время до генерации объекта
    [SerializeField]
    private float offset = 10f; //Расстояние до игрока
    [SerializeField]
    private int countEnemy = 1; //Количество Enemy на сцене
    private int spawnedEnemy; //Количество сгенерированных объектов

    private void Start()
    {
        remainingTime = timeSpawn;
        spawnedEnemy = 0;
    }

    private void Update()
    {
        //если количество сгенерированных объектов меньше количества всего сгенерированных объектов, то запуск отсчета обратного времени
        if (spawnedEnemy < countEnemy)
        {
            // Обратный отсчет времени
            if (remainingTime > 0)
                remainingTime -= Time.deltaTime;
        }
        //Если оставшееся время равно или меньше 0
        if (remainingTime <= 0)
        {
            //Обновление счетчика обратного времени
            remainingTime = timeSpawn;
            //вызов корутины по генерации объекта
            StartCoroutine(SpawnObject());
        }
    }

    /// <summary>
    /// Генерация объекта
    /// </summary>
    /// <returns></returns>
    IEnumerator SpawnObject()
    {
        //Определение позиции игрока
        Vector2 playerPosition = GetComponent<GameController>().GetPlayerPosition();
        //Генерация объекта с учетом позиции игрока
        Instantiate(enemyPrefab, 
                    new Vector2(playerPosition.x * Random.Range(- offset, offset), 
                    playerPosition.y * Random.Range(-offset, offset)), 
                    Quaternion.identity);
        CalculateEnemy();
        yield return null;
    }

    /// <summary>
    /// Инкремент созданных объектов при создании объекта
    /// </summary>
    private void CalculateEnemy()
    {
        spawnedEnemy++;
        GetComponent<GameController>().InkrementSpawneObjects();
    }

    /// <summary>
    /// Декремент сгенерированных объектов после уничтожения
    /// </summary>
    public void SubstractionSpanedOnj()
    {
        spawnedEnemy--;
        GetComponent<GameController>().DecrementSpawnedObject();
    }
}
