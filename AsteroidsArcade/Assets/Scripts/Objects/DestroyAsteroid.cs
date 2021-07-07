using System.Collections;
using UnityEngine;

public class DestroyAsteroid : MonoBehaviour
{
    public GameObject[] asteriodsType; //Массив  GameObject типов астероидов

    public Transform[] spawnPos; //Массив точек генерации астероидов

    public int countSpawAsteroids; //Количество генерируемых астероидов

    public int scoreValue = 100; //Количество начисляемых очков за уничтожение астероида

    private GameController gameController;
    private SpawnAsteroids spawnAsteroids;

    private void Start()
    {
        //Получение объекта GameController
        gameController = FindObjectOfType<GameController>();
        //Если найден объект GameController
        if (gameController != null)
        {
            //Получение компонента GameController
            gameController = gameController.GetComponent<GameController>();
            //Получение компонента SpawnAsteroids
            spawnAsteroids = gameController.GetComponent<SpawnAsteroids>();
        }
        else
            Debug.Log("GameController don't find");
    }

    /// <summary>
    /// Метод для уничтожения текущего астероида и генерации новых астероидов в зависимости от размера астероида
    /// ТИп астероида определяется  сравнением имени префаба с константым
    /// </summary>
    /// <param name="calculateScore">Флаг указатель, что нужно считать результат уничтоженныхх астероидов</param>
    public void StartDestroyAndSpawn(bool calculateScore = true)
    {
        //Если астероид большого размера, вызов метода генерации астероидов c указанием флага подсчета результата
        if (gameObject.name.Contains("BigAsteroid"))
        {
            StartCoroutine(SpawnAsteroids(calculateScore));
        }

        ////Если астероид среднего размера, вызов метода генерации астероидов, с указанием флага, что это средний астероид и флага подсчета результата
        if (gameObject.name.Contains("MiddleAsteroid"))
        {
            StartCoroutine(SpawnAsteroids(calculateScore, true));
        }

        ////Если астероид маленьго размера, вызов метода уничтожения объекта
        if (gameObject.name.Contains("SmallAsteroid"))
        {
            //вызов метода уничтожения объекта
            DestroyObj(calculateScore);
        }
    }

    /// <summary>
    /// Корутина по генерации астероидов на месте уничтожаемого астероида, тип генерируемого астероида зависит от входного параметра isMiddleAsteroid
    /// если isMiddleAsteroid = false, то генерируются астероиды среднего и маленького размер, 
    /// если isMiddleAsteroid = true, то генерируются астероиды только маленького размера
    /// </summary>
    /// <param name="isMiddleAsteroid">Тип уничтожаемого астероида</param>
    /// <returns></returns>
    IEnumerator SpawnAsteroids(bool calculateValue,bool isMiddleAsteroid = false)
    {
        //Генерация случайного типа астероидов, равное countSpawAsteroids с приданием случайного значения ускорения к базовому значению ускорения 
        for (int i = 0; i < countSpawAsteroids; i++)
        {
            //Определение размера уничтожаемого астероида
            if (isMiddleAsteroid)
            {
                //Генерация астероидов маленького типа и приданием им ускорения с приданием случайного значения ускорения к базовому значению ускорения 
                Instantiate(asteriodsType[0], spawnPos[i].position, Quaternion.identity).GetComponent<MovementAsteroid>().force += RandomValue();
            } 
            else
            {   
                //Генерация астероидов среднего или малого размера с приданием случайного значения ускорения к базовому значению ускорения 
                Instantiate(asteriodsType[RandomValue()], spawnPos[i].position, Quaternion.identity).GetComponent<MovementAsteroid>().force += RandomValue();
            }
            //Инкремент количества сгенерированных объектов
            spawnAsteroids.CalculateSpawnedObjects();
        }
        //вызов метода уничтожения объекта
        DestroyObj(calculateValue);
        yield return null;
    }

    /// <summary>
    /// Метод определения случайниго значения от 0 до длины массива количества типов астероида
    /// </summary>
    /// <returns></returns>
    private int RandomValue()
    {
        //Возврат случайного значения
        return Random.Range(0, Mathf.FloorToInt(asteriodsType.Length));
    }

    /// <summary>
    /// Уничтожение объекта
    /// </summary>
    private void DestroyObj(bool calculateScore = true)
    {
        gameController.PlayDestroyAsteriod();
        //Подсчет очков
        if (calculateScore)
        {
            //Подсчет очков за уничтоженный астероид
            gameController.CalculateScore(scoreValue);
        }
        //Декремент количества сгенерированных объектов
        spawnAsteroids.SubstractionSpanedOnj();
        //Уничтожение объекта
        Destroy(gameObject);
    }
}
