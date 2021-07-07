using UnityEngine;
using UnityEngine.UI;

public class ShowScore : MonoBehaviour
{
    private int score;  //Значение рекода
    [SerializeField]
    Text scoreText; //Компонент Text для отображения рекода

    private int countSpawnedOblects; //Оставшее количество уничтожаемых объектов
    [SerializeField]
    Text countSpawnedObjectsText; //Компонент Text для отображения текущего коичества оставшихся объектов

    private int currentLife; //Текущее количество жизней
    [SerializeField]
    Text currentLifeText; //Компонент Text для отображения текущего коичества жизней


    public Text ScoreText { get; set; }
    public Text CountAsteroidsText { get; set; }
    public Text CurrentLifeText { get ; set; }

    /// <summary>
    /// Метод обновления значения рекода
    /// </summary>
    /// <param name="newScore"></param>
    public void UpdateScore(int newScore)
    {
        scoreText.text = newScore.ToString();
    }

    /// <summary>
    /// Метод обновления числа оставшихся объектов
    /// </summary>
    /// <param name="newCount"></param>
    public void UpdateCountSpawnedObjects(int newCount)
    {
        countSpawnedObjectsText.text = newCount.ToString();
    }

    /// <summary>
    /// Метод обновления количества жизней
    /// </summary>
    /// <param name="newCount"></param>
    public void UpdateCurrentLife(int newCount)
    {
        currentLifeText.text = newCount.ToString();
    }

}
