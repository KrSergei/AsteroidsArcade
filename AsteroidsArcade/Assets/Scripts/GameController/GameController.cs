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
    private int startLife = 3;      //��������� ���������� ������ 
    [SerializeField]
    private int maxLife = 10;       //Max ���������� ������   
    [SerializeField]
    private int currentLife { get; set; } //������� ���������� ������
    [SerializeField]
    private int scoreForOverLife = 3000;  //���������� �����, �� ������� ��������� ���� �����
  
    private int remainingPoints; //���������� ���������� ����� �� ��������� �����


    public GameObject uiManager; //������ �� UIManager
    public GameObject player; //������ �� player
    public GameObject soundManager; //������ �� soundManager

    private void Start()
    {
        //����� �������
        currentScore = 0;
        //����� ���������� ��������������� ����������
        countSpawnedObject = 0;
        //��������� �������� ���������� ������
        currentLife = startLife;
        //��������� ����������� ���������� ������ ��� ��������� �������������� �����
        remainingPoints = scoreForOverLife;
        //����������� ���������� SpawnAsteroids
        GetComponent<SpawnAsteroids>().enabled = false;
        //����������� ���������� SpawnEnemy
        GetComponent<SpawnEnemy>().enabled = false;
        //����������� ������
        player.SetActive(false);
        //����� �� ����� ���������� ������
        uiManager.GetComponent<ShowScore>().UpdateCurrentLife(currentLife);
        
    }

    public void StartInit()
    {
        //��������� ���������� SpawnAsteroids
        GetComponent<SpawnAsteroids>().enabled = true;
        //��������� ���������� SpawnEnemy
        GetComponent<SpawnEnemy>().enabled = true;
    }

    /// <summary>
    /// ����� ��� �������� ����������� ���������� ����� ��������� �������������� �����
    /// </summary>
    public void CheckRemainingScore(int score)
    {
        remainingPoints -= score;
        //���� ���������� ���������� ����� ������ ���� ����� 0, �� ����������� ���� �����
        if (remainingPoints <= 0)
        {
            //��������� ���������� ������
            currentLife++;
            //���� ������� ���������� ������ ������ ��� maxLife, �� currentLife = maxLife
            if (currentLife > maxLife)
                currentLife = maxLife;
            else
                uiManager.GetComponent<ShowScore>().UpdateCurrentLife(currentLife);
            //����� ���������� ����� ��� ��������� ����� �����
            remainingPoints = scoreForOverLife;
        }
    }

    /// <summary>
    /// �����, ������� ��������� ���������� ������
    /// </summary>
    public void CalcLife()
    {
        currentLife--;
        if (currentLife == 0)
        {
            //������������ ����� ���������� ������
            soundManager.GetComponent<SoundControl>().PlayDestroPlayer();
            //����������� ������
            player.SetActive(false);
            //��������� �������� ������� ���� � 0
            Time.timeScale = 0f;
            uiManager.GetComponent<UIManager>().ShowGameOverMenu();
        }
        uiManager.GetComponent<ShowScore>().UpdateCurrentLife(currentLife);
    }

    /// <summary>
    /// ������� ���������� �����
    /// </summary>
    /// <param name="newScore"></param>
    public void CalculateScore(int newScore)
    {
        currentScore += newScore;
        CheckRemainingScore(newScore);
        uiManager.GetComponent<ShowScore>().UpdateScore(currentScore);
    }

    /// <summary>
    /// ��������� ���������� ��������������� ��������
    /// </summary>
    /// <param name="newSpawnedObjects"></param>
    public void InkrementSpawneObjects()
    {
        countSpawnedObject++;
        uiManager.GetComponent<ShowScore>().UpdateCountSpawnedObjects(countSpawnedObject);
    }

    /// <summary>
    /// ��������� ���������� ��������������� ��������
    /// </summary>
    public void DecrementSpawnedObject()
    {
        countSpawnedObject--;
        uiManager.GetComponent<ShowScore>().UpdateCountSpawnedObjects(countSpawnedObject);
    }

    /// <summary>
    /// ��������� �������� ��������� ������
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
