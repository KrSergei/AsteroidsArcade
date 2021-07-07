
using System.Collections;
using UnityEngine;

public class MovementAsteroid : MonoBehaviour
{
    public float force; //���� �����������
    Rigidbody2D rb; //��������� Rigidbody2D
    
    void Start()
    {
        //��������� ��������� Rigidbody2D
        rb = GetComponent<Rigidbody2D>();
        //������ �������� ��� �������� ���������
        StartCoroutine(Movement());
    }

    /// <summary>
    /// ������� �������� ���������
    /// </summary>
    /// <returns></returns>
    IEnumerator Movement()
    {
        //�������� �������� ��������� ��������� �� ���������� ������� �����������
        rb.AddRelativeForce(new Vector2(RandomValue(), RandomValue()) * force, ForceMode2D.Impulse);
        yield return null;
    }

    /// <summary>
    /// ����������� � ������� ���������� ����� ��� ���������� ������� �� -1 �� 1
    /// </summary>
    /// <returns></returns>
    private float RandomValue()
    {
        return Random.Range(-1f, 1f);
    }
}
