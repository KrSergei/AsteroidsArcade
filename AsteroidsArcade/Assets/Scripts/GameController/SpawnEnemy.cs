using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject enemyPrefab; //Enemy prefab
    [SerializeField]
    private float timeSpawn = 15f; //�����, ����� ������� ������������ ������ 
    [SerializeField]
    private float remainingTime; //���������� ����� �� ��������� �������
    [SerializeField]
    private float offset = 10f; //���������� �� ������
    [SerializeField]
    private int countEnemy = 1; //���������� Enemy �� �����
    private int spawnedEnemy; //���������� ��������������� ��������

    private void Start()
    {
        remainingTime = timeSpawn;
        spawnedEnemy = 0;
    }

    private void Update()
    {
        //���� ���������� ��������������� �������� ������ ���������� ����� ��������������� ��������, �� ������ ������� ��������� �������
        if (spawnedEnemy < countEnemy)
        {
            // �������� ������ �������
            if (remainingTime > 0)
                remainingTime -= Time.deltaTime;
        }
        //���� ���������� ����� ����� ��� ������ 0
        if (remainingTime <= 0)
        {
            //���������� �������� ��������� �������
            remainingTime = timeSpawn;
            //����� �������� �� ��������� �������
            StartCoroutine(SpawnObject());
        }
    }

    /// <summary>
    /// ��������� �������
    /// </summary>
    /// <returns></returns>
    IEnumerator SpawnObject()
    {
        //����������� ������� ������
        Vector2 playerPosition = GetComponent<GameController>().GetPlayerPosition();
        //��������� ������� � ������ ������� ������
        Instantiate(enemyPrefab, 
                    new Vector2(playerPosition.x * Random.Range(- offset, offset), 
                    playerPosition.y * Random.Range(-offset, offset)), 
                    Quaternion.identity);
        CalculateEnemy();
        yield return null;
    }

    /// <summary>
    /// ��������� ��������� �������� ��� �������� �������
    /// </summary>
    private void CalculateEnemy()
    {
        spawnedEnemy++;
        GetComponent<GameController>().InkrementSpawneObjects();
    }

    /// <summary>
    /// ��������� ��������������� �������� ����� �����������
    /// </summary>
    public void SubstractionSpanedOnj()
    {
        spawnedEnemy--;
        GetComponent<GameController>().DecrementSpawnedObject();
    }
}
