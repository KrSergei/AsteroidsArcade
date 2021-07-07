using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private int currentScore { get; set; }
    [SerializeField]
    private int countSpawnedObject { get; set; }
    [SerializeField]
    private int startLife = 3;      //Стартовое количество жизней 
    [SerializeField]
    private int maxLife = 10;       //Max количество жизней   
    [SerializeField]
    private int currentLife { get; set; } //Текущее количество жизней
    [SerializeField]
    private int scoreForOverLife = 3000;  //Количество очков, за которые добавляют одну жизнь
  
    private int remainingPoints; //Оставшееся количество очков до получения жизни


    public GameObject uiManager; //Ссылка на UIManager
    public GameObject player; //Ссылка на player
    public GameObject soundManager; //Ссылка на soundManager

    private void Start()
    {
        //Сброс рекорда
        currentScore = 0;
        //Сброс количества сгенерированных астероидов
        countSpawnedObject = 0;
        //Установка текущего количества жизней
        currentLife = startLife;
        //Установка оставшегося количества жизней для получения дополнительной жизни
        remainingPoints = scoreForOverLife;
        //Деактивация компонента SpawnAsteroids
        GetComponent<SpawnAsteroids>().enabled = false;
        //Деактивация компонента SpawnEnemy
        GetComponent<SpawnEnemy>().enabled = false;
        //Деактивация игрока
        player.SetActive(false);
        //Вывод на экран количества жизней
        uiManager.GetComponent<ShowScore>().UpdateCurrentLife(currentLife);
        
    }

    public void StartInit()
    {
        //активация компонента SpawnAsteroids
        GetComponent<SpawnAsteroids>().enabled = true;
        //активация компонента SpawnEnemy
        GetComponent<SpawnEnemy>().enabled = true;
    }

    /// <summary>
    /// Метод для проверки оставшегося количества очков получения дополнительной жизни
    /// </summary>
    public void CheckRemainingScore(int score)
    {
        remainingPoints -= score;
        //Если оставшееся количество очков меньше либо равно 0, то добавляется одна жизнь
        if (remainingPoints <= 0)
        {
            //Инкремент количества жизней
            currentLife++;
            //Если текущее количество жизней больше чем maxLife, то currentLife = maxLife
            if (currentLife > maxLife)
                currentLife = maxLife;
            else
                uiManager.GetComponent<ShowScore>().UpdateCurrentLife(currentLife);
            //Сброс количества очков для получения новой жизни
            remainingPoints = scoreForOverLife;
        }
    }

    /// <summary>
    /// Метод, который уменьшает количество жизней
    /// </summary>
    public void CalcLife()
    {
        currentLife--;
        if (currentLife == 0)
        {
            //Проигрывание звука разрушения игрока
            soundManager.GetComponent<SoundControl>().PlayDestroPlayer();
            //Деактивация игрока
            player.SetActive(false);
            //Установка масштаба времени игры в 0
            Time.timeScale = 0f;
            uiManager.GetComponent<UIManager>().ShowGameOverMenu();
        }
        uiManager.GetComponent<ShowScore>().UpdateCurrentLife(currentLife);
    }

    /// <summary>
    /// Подсчет количества очков
    /// </summary>
    /// <param name="newScore"></param>
    public void CalculateScore(int newScore)
    {
        currentScore += newScore;
        CheckRemainingScore(newScore);
        uiManager.GetComponent<ShowScore>().UpdateScore(currentScore);
    }

    /// <summary>
    /// Инкремент количества сгенерированных объектов
    /// </summary>
    /// <param name="newSpawnedObjects"></param>
    public void InkrementSpawneObjects()
    {
        countSpawnedObject++;
        uiManager.GetComponent<ShowScore>().UpdateCountSpawnedObjects(countSpawnedObject);
    }

    /// <summary>
    /// Декремент количества сгенерированных объектов
    /// </summary>
    public void DecrementSpawnedObject()
    {
        countSpawnedObject--;
        uiManager.GetComponent<ShowScore>().UpdateCountSpawnedObjects(countSpawnedObject);
    }

    /// <summary>
    /// Получение текущего положения игрока
    /// </summary>
    /// <returns></returns>
    public Vector2 GetPlayerPosition()
    {
       return player.GetComponent<PlayerControl>().GetCurrentPosition();
    }

    public void PlayDestroyAsteriod()
    {
        soundManager.GetComponent<SoundControl>().PlayDestroyAsteroidSound();
    }

    public void PlayDestroyUFO()
    {
        soundManager.GetComponent<SoundControl>().PlayDestroUFOSound();
    }
}
