using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementUFO : MonoBehaviour
{

    public float force = 15f; //���� �����������
    public float minTimeForce = 2f; //����������� ����� �������� ����
    public float maxTimeForce = 5f; //������������ ����� �������� ����
    Rigidbody2D rb; //��������� Rigidbody2D

    private float currentTimeForce;  //������� ����� �������� ����
    private Vector2 sizeBorder; //������� ������
    private Vector2 direction;  //������ ��������

    void Awake()
    {
        //����������� ������� �������
        sizeBorder = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
    }

    private void Start()
    {
        //��������� ����������  Rigidbody2D
        rb = GetComponent<Rigidbody2D>();
        //����������� ������� �������� �
        GetTimeForce();
        direction = GetDirection();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        //���� ������� ����� ����������� ���� ������ 0, ����� �������� �������� � ��������� ������� ����������� ����
        if (currentTimeForce > 0)
        {
            StartCoroutine(Movement(direction));
            currentTimeForce -= Time.deltaTime;
        }
        //���� ������� ����� ����������� ���� ������  ����� 0, ����������� ������ ������� ����������� � ������ ������� �����������
        if (currentTimeForce <= 0)
        {
            GetTimeForce();
            direction = GetDirection();
        }

    }

    /// <summary>
    /// �������� �������� � �������� ��������
    /// </summary>
    /// <param name="currentDirection"></param>
    /// <returns></returns>
    IEnumerator Movement(Vector2 currentDirection)
    {
        //�������� ��������� � ����������� �� ���������� ������� �����������
        rb.AddRelativeForce(currentDirection * force * Time.deltaTime);
        yield return null;
    }

    /// <summary>
    /// ��������� ���������� ������� �������� ����
    /// </summary>
    private void GetTimeForce()
    {
        currentTimeForce = Random.Range(minTimeForce, maxTimeForce);
    }

    /// <summary>
    /// ����������� ������ ������� ����������� ��������
    /// </summary>
    /// <returns></returns>
    private Vector2 GetDirection()
    {
        //��������� �������� �������
        direction = Vector2.zero;
        //����������� ����� ������� ��������
        direction = new Vector2(GetRandomValue(sizeBorder.x), GetRandomValue(sizeBorder.y));
        return direction;
    }

    /// <summary>
    /// ����������� ���������� ��������
    /// </summary>
    /// <param name="minValue"></param>
    /// <param name="maxValue"></param>
    /// <returns></returns>
    private float GetRandomValue(float value)
    {
        return Random.Range(-value, value);
    }
}
