using System.Collections;
using UnityEngine;

public class SpawnAsteroids : MonoBehaviour
{
    public int minSpawnedAsteroids = 4; //��������� ���������� ������������ ���������� 
    public GameObject asteroids; //������ ������������� ��������� 

    [SerializeField]
    private float spawnX = 11f; //���������� �� ������ �� ���� ��������� �� ��� X
    [SerializeField]
    private float spawnY = 5f; //���������� �� ������ �� ���� ��������� ��� Y
    [SerializeField]
    private byte maxCountOverLimit = 4; //������������ ����������� ���������� ������������ �������������� �������� ��� ������ �������
    private byte currentOverCount = 0;  //������� ���������� ���������� ������������ �������������� �������� ��� ������ �������
    [SerializeField]
    private float delayBeetwenWave = 1.5f; //�������� ����� ���������� ����������

    private int spawnedObject; //���������� ��������������� ��������

    public int SpawnedObject { get ; set ; }

    private void Start()
    {
        SpawnedObject = 0;
        StartSpawn();
    }

    /// <summary>
    /// ������ �������� �� ��������� ����������
    /// </summary>
    /// <param name="addAsteroids">���������� ���������� ���������� ��� ������� ����� �����</param>
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
        //��������� ������� ������� ������
        Vector2 playerPosition = GetComponent<GameController>().GetPlayerPosition();
        //��������� ��������� ����� � ������ ������� ������
        Instantiate(asteroids, new Vector2(-spawnX, GetRandomValue(spawnY)) + playerPosition, Quaternion.identity);
        //��������� ��������������� �������� � ������ ������� ������
        CalculateSpawnedObjects();
        //��������� ��������� ������ � ������ ������� ������
        Instantiate(asteroids, new Vector2(spawnX, GetRandomValue(spawnY)) + playerPosition, Quaternion.identity);
        //��������� ��������������� �������� 
        CalculateSpawnedObjects();
        //��������� ��������� ������ � ������ ������� ������
        Instantiate(asteroids, new Vector2(GetRandomValue(spawnX), spawnY) + playerPosition, Quaternion.identity);
        //��������� ��������������� �������� 
        CalculateSpawnedObjects();
        //��������� ��������� ����� � ������ ������� ������
        Instantiate(asteroids, new Vector2(GetRandomValue(spawnX), -spawnY) + playerPosition, Quaternion.identity);
        //��������� ��������������� ��������
        CalculateSpawnedObjects();
        yield return null;
    }
    
    //��������� ��������������� ��������, ������� ��������������� ������� ����� ����������� �������
    public void CalculateSpawnedObjects()
    {
        //��������� �������� ���������� ����������
        SpawnedObject++;
        //����� ������ ��� ������ �������� ���������� ����������
        GetComponent<GameController>().InkrementSpawneObjects();
    }

    public void SubstractionSpanedOnj()
    {
        //��������� �������� ���������� ����������
        SpawnedObject--;
        //����� ������ ��� ������ �������� ���������� ����������
        GetComponent<GameController>().DecrementSpawnedObject();
        //������ ����� �����  ��������� ���������� � ���������� ���������� ����������  ��� ������ ����� �����
        if (SpawnedObject == 0)
        {
            //���� ������� ����������� ������ ������������� ������������ ����������, �� ��������� �������� ���������� ������������
            if (currentOverCount < maxCountOverLimit)
            {
                currentOverCount++;
            }
            //����� ������ ��������� ���� � ��������� �������� ���������� ������������
            StartSpawn(currentOverCount);
        }
    }

    /// <summary>
    /// ����������� ���������� ����� � ��������� �� 0 �� ������������ �������� � ��������� value
    /// </summary>
    /// <param name="value">����������� ��������</param>
    /// <returns></returns>
    private float GetRandomValue(float value)
    {
        return Random.Range(-value, value);
    }
}
