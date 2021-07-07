using System.Collections;
using UnityEngine;

public class DestroyAsteroid : MonoBehaviour
{
    public GameObject[] asteriodsType; //������  GameObject ����� ����������

    public Transform[] spawnPos; //������ ����� ��������� ����������

    public int countSpawAsteroids; //���������� ������������ ����������

    public int scoreValue = 100; //���������� ����������� ����� �� ����������� ���������

    private GameController gameController;
    private SpawnAsteroids spawnAsteroids;

    private void Start()
    {
        //��������� ������� GameController
        gameController = FindObjectOfType<GameController>();
        //���� ������ ������ GameController
        if (gameController != null)
        {
            //��������� ���������� GameController
            gameController = gameController.GetComponent<GameController>();
            //��������� ���������� SpawnAsteroids
            spawnAsteroids = gameController.GetComponent<SpawnAsteroids>();
        }
        else
            Debug.Log("GameController don't find");
    }

    /// <summary>
    /// ����� ��� ����������� �������� ��������� � ��������� ����� ���������� � ����������� �� ������� ���������
    /// ��� ��������� ������������  ���������� ����� ������� � ����������
    /// </summary>
    /// <param name="calculateScore">���� ���������, ��� ����� ������� ��������� ������������� ����������</param>
    public void StartDestroyAndSpawn(bool calculateScore = true)
    {
        //���� �������� �������� �������, ����� ������ ��������� ���������� c ��������� ����� �������� ����������
        if (gameObject.name.Contains("BigAsteroid"))
        {
            StartCoroutine(SpawnAsteroids(calculateScore));
        }

        ////���� �������� �������� �������, ����� ������ ��������� ����������, � ��������� �����, ��� ��� ������� �������� � ����� �������� ����������
        if (gameObject.name.Contains("MiddleAsteroid"))
        {
            StartCoroutine(SpawnAsteroids(calculateScore, true));
        }

        ////���� �������� �������� �������, ����� ������ ����������� �������
        if (gameObject.name.Contains("SmallAsteroid"))
        {
            //����� ������ ����������� �������
            DestroyObj(calculateScore);
        }
    }

    /// <summary>
    /// �������� �� ��������� ���������� �� ����� ������������� ���������, ��� ������������� ��������� ������� �� �������� ��������� isMiddleAsteroid
    /// ���� isMiddleAsteroid = false, �� ������������ ��������� �������� � ���������� ������, 
    /// ���� isMiddleAsteroid = true, �� ������������ ��������� ������ ���������� �������
    /// </summary>
    /// <param name="isMiddleAsteroid">��� ������������� ���������</param>
    /// <returns></returns>
    IEnumerator SpawnAsteroids(bool calculateValue,bool isMiddleAsteroid = false)
    {
        //��������� ���������� ���� ����������, ������ countSpawAsteroids � ��������� ���������� �������� ��������� � �������� �������� ��������� 
        for (int i = 0; i < countSpawAsteroids; i++)
        {
            //����������� ������� ������������� ���������
            if (isMiddleAsteroid)
            {
                //��������� ���������� ���������� ���� � ��������� �� ��������� � ��������� ���������� �������� ��������� � �������� �������� ��������� 
                Instantiate(asteriodsType[0], spawnPos[i].position, Quaternion.identity).GetComponent<MovementAsteroid>().force += RandomValue();
            } 
            else
            {   
                //��������� ���������� �������� ��� ������ ������� � ��������� ���������� �������� ��������� � �������� �������� ��������� 
                Instantiate(asteriodsType[RandomValue()], spawnPos[i].position, Quaternion.identity).GetComponent<MovementAsteroid>().force += RandomValue();
            }
            //��������� ���������� ��������������� ��������
            spawnAsteroids.CalculateSpawnedObjects();
        }
        //����� ������ ����������� �������
        DestroyObj(calculateValue);
        yield return null;
    }

    /// <summary>
    /// ����� ����������� ���������� �������� �� 0 �� ����� ������� ���������� ����� ���������
    /// </summary>
    /// <returns></returns>
    private int RandomValue()
    {
        //������� ���������� ��������
        return Random.Range(0, Mathf.FloorToInt(asteriodsType.Length));
    }

    /// <summary>
    /// ����������� �������
    /// </summary>
    private void DestroyObj(bool calculateScore = true)
    {
        gameController.PlayDestroyAsteriod();
        //������� �����
        if (calculateScore)
        {
            //������� ����� �� ������������ ��������
            gameController.CalculateScore(scoreValue);
        }
        //��������� ���������� ��������������� ��������
        spawnAsteroids.SubstractionSpanedOnj();
        //����������� �������
        Destroy(gameObject);
    }
}
