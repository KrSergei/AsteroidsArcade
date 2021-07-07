using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPlayer : MonoBehaviour
{
    public float timeBeetwenBlink = 0.5f; //����� ����� �������

    public int countBlink = 5; //���������� ������ ������ ����� ������������ � ��������

    private GameController gameController;

    [SerializeField]
    private bool isAllive = true; //����, ��� ����� ���

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


    private void OnTriggerEnter2D(Collider2D col)
    {
        //�������� ��������� ������
        if(isAllive)
            //���� ���� ������������ � �������� Enemy
            if (col.CompareTag("Enemy") || col.CompareTag("UFO"))
            {
                isAllive = false;
                StartCoroutine(BlinkBody());
                gameController.CalcLife();
            }
    }

    /// <summary>
    /// �������� �������� ������� ��� ������������
    /// </summary>
    /// <returns></returns>
    IEnumerator BlinkBody()
    {
        for (int i = 0; i < countBlink; i++)
        {
            //���������� ���������� SpriteRenderer
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            //�����
            yield return new WaitForSeconds(timeBeetwenBlink);
            //��������� ���������� SpriteRenderer
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            //�����
            yield return new WaitForSeconds(timeBeetwenBlink);
        }
        //����� �����
        isAllive = true;
    }
}
