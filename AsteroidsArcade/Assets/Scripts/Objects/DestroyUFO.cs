using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyUFO : MonoBehaviour
{
    [SerializeField]
    private int scoreValue = 1000; //���� �� ����������� �������

    private GameController gameController;

    private void Start()
    {
        //��������� ������� GameController
        gameController = FindObjectOfType<GameController>();
        //���� ������ ������ GameController
        if (gameController != null)
        {
            //��������� ���������� GameController
            gameController = gameController.GetComponent<GameController>();

        }
        else
            Debug.Log("GameController don't find");
    }

    /// <summary>
    /// ����� ����������� �������
    /// </summary>
    public void StartDestroy()
    {
        gameController.PlayDestroyUFO();
        //��������� ���������� ��������
        gameController.GetComponent<SpawnEnemy>().SubstractionSpanedOnj();
        //������� ����� �� ������������ ��������
        gameController.CalculateScore(scoreValue);
        //����������� �������
        Destroy(gameObject);
    }
}
