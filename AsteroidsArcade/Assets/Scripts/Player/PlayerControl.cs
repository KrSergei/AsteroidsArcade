using System.Collections;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    /* ���������� �������� ������. 
     * ���������� ����� ��������� �������� � ����������� �� ��������� ������� ������ W, S, A, D
     * ������� ������� ����������� �������� W, S, ������� �������� �������� A, D
     * ��� ������, ��������� ���������� Rigidbody2D � ������
     * ������ FixedUpdate:
     *      ��������� �������� �� ������� ������  W, S, A, D
     *      ����� �������� ��� �������� ������ � ���������� �� ��������� ������ ������� A, D
     *      ����� �������� ��� ������������ ������ � ���������� �� ��������� ������ ������� W, S
     */

    public float force = 10f; //���������

    public float speedRotate = 1f; //�������� ��������

    Rigidbody2D rb; //��������� Rigidbody2D ������

    
    void Start()
    {
        //��������� ���������� Rigidbody2D
        rb = GetComponent<Rigidbody2D>();
    }


    void FixedUpdate()
    {
        //����������� ����������� �������� �� ����������� 
        float directionSide = Input.GetAxisRaw("Horizontal");
        //����������� ����������� �������� �� ���������
        float directionForward = Input.GetAxisRaw("Vertical");
        //������ �������� ��������
        StartCoroutine(Rotate(directionSide, directionForward));
        //������ �������� ������������
        StartCoroutine(Movement(directionSide, directionForward));

    }

    /// <summary>
    /// ������� � ���������� �� �������� �������� ����������
    /// </summary>
    /// <param name="directionSide">�������� �� ��� �</param>
    /// <param name="directionForward">�������� �� ��� Y</param>
    /// <returns></returns>
    IEnumerator Rotate(float directionSide, float directionForward)
    {
        //������� � �������� �����������
        rb.AddTorque(- directionSide * speedRotate * Time.deltaTime, 0f);
        yield return null;
    }

    /// <summary>
    /// ������������ � ���������� �� �������� �������� ����������
    /// </summary>
    /// <param name="directionSide">�������� �� ��� �</param>
    /// <param name="directionForward">>�������� �� ��� Y</param>
    /// <returns></returns>
    IEnumerator Movement(float directionSide, float directionForward)
    {
        //�������� ��������� ������
        rb.AddRelativeForce(new Vector2(directionSide, directionForward) * force * Time.deltaTime);
        yield return null;
    }

    /// <summary>
    /// �����, ������������ ������� ��������� ������
    /// </summary>
    /// <returns></returns>
    public Vector2 GetCurrentPosition()
    {
        return transform.position;
    }
}
