using System.Collections;
using UnityEngine;

public class SpawnAsteroids : MonoBehaviour
{
    public int minSpawnedAsteroids = 4; //Стартовое количество генерируемых астероидов 
    public GameObject asteroids; //Префаб генерируемого астероида 

    [SerializeField]
    private float spawnX = 11f; //Расстояние от центра до зоны генерации по оси X
    [SerializeField]
    private float spawnY = 5f; //Расстояние от центра до зоны генерации оси Y
    [SerializeField]
    private byte maxCountOverLimit = 4; //Максимальный коэффициент увеличения генерируемых дополнительных объектов для каждой стороны
    private byte currentOverCount = 0;  //Текущий коэффицент увеличения генерируемых дополнительных объектов для каждой стороны
    [SerializeField]
    private float delayBeetwenWave = 1.5f; //Задержка перед генерацией астероидов

    private int spawnedObject; //Количество сгенерированных объектов

    public int SpawnedObject { get ; set ; }

    private void Start()
    {
        SpawnedObject = 0;
        StartSpawn();
    }

    /// <summary>
    /// Запуск корутины по генерации астероидов
    /// </summary>
    /// <param name="addAsteroids">Добавочное количество астероидов при запуске новой волны</param>
    public void StartSpawn(int addAsteroids = 0)
    {
 
        for (int i = 0; i < minSpawnedAsteroids + addAsteroids; i++)
        {
            StartCoroutine(SpawnOBjects());
        }
    }

    IEnumerator SpawnOBjects()
    {
        yield return new WaitForSeconds(delayBeetwenWave);
        //Получение текущей позиции игрока
        Vector2 playerPosition = GetComponent<GameController>().GetPlayerPosition();
        //Генерация астероида слева с учетом позиции игрока
        Instantiate(asteroids, new Vector2(-spawnX, GetRandomValue(spawnY)) + playerPosition, Quaternion.identity);
        //Инкремент сгенерированных объектов с учетом позиции игрока
        CalculateSpawnedObjects();
        //Генерация астероида справа с учетом позиции игрока
        Instantiate(asteroids, new Vector2(spawnX, GetRandomValue(spawnY)) + playerPosition, Quaternion.identity);
        //Инкремент сгенерированных объектов 
        CalculateSpawnedObjects();
        //Генерация астероида сверху с учетом позиции игрока
        Instantiate(asteroids, new Vector2(GetRandomValue(spawnX), spawnY) + playerPosition, Quaternion.identity);
        //Инкремент сгенерированных объектов 
        CalculateSpawnedObjects();
        //Генерация астероида снизу с учетом позиции игрока
        Instantiate(asteroids, new Vector2(GetRandomValue(spawnX), -spawnY) + playerPosition, Quaternion.identity);
        //Инкремент сгенерированных объектов
        CalculateSpawnedObjects();
        yield return null;
    }
    
    //Инкремент сгенерированных объектов, включая сгенерированные объекты после уничтожения объекта
    public void CalculateSpawnedObjects()
    {
        //Инкремент текущего количества астероидов
        SpawnedObject++;
        //Вызов метода для показа текущего количества астероидов
        GetComponent<GameController>().InkrementSpawneObjects();
    }

    public void SubstractionSpanedOnj()
    {
        //Декремент текущего количества астероидов
        SpawnedObject--;
        //Вызов метода для показа текущего количества астероидов
        GetComponent<GameController>().DecrementSpawnedObject();
        //Запуск новой волны  генерации астероидов с добавление количества астероидов  для каждой новой волны
        if (SpawnedObject == 0)
        {
            //Если текущий коэффициент меньше максимального коэффициента увеличения, то инкремент текущего показателя коэффициента
            if (currentOverCount < maxCountOverLimit)
            {
                currentOverCount++;
            }
            //Вызов метода генерации волн с указанием текущего показателя коэффициента
            StartSpawn(currentOverCount);
        }
    }

    /// <summary>
    /// Определение случайного числа в диапазоне от 0 до принимаемого значения в параметре value
    /// </summary>
    /// <param name="value">Принимаемый параметр</param>
    /// <returns></returns>
    private float GetRandomValue(float value)
    {
        return Random.Range(-value, value);
    }
}
