using System;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class OutOfBorderScreen : MonoBehaviour
{
    protected Vector2 sizeBorder;   //������ �������

    protected SpriteRenderer spriteRenderer; //��������� ��� ����������� �������� ���������

    public Action<OutOfBorderDirection> onObjectOutOfBorder; //������� ����������� �������

    void Awake()
    {
        //��������� ���������� SpriteRenderer
        spriteRenderer = GetComponent<SpriteRenderer>();
        //����������� ������� �������. ���������  ��������� ������� �� ������� ������
        sizeBorder = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
    }

    void Update()
    {
        //���� �������� ������� spriteRenderer ������� �� ��� � ������, ��� ���������� ������� �� ��� �, ��� ����������� ����������� ������������ ������
        if (transform.position.x - spriteRenderer.bounds.size.x / 2 > sizeBorder.x)
            onObjectOutOfBorder(OutOfBorderDirection.Right);
        //���� �������� ������� spriteRenderer ������� �� ��� � ������, ���  ������������� ���������� ������� �� ��� �, ��� ����������� ����������� ������������ �����
        else if (transform.position.x + spriteRenderer.bounds.size.x / 2 < -sizeBorder.x)
            onObjectOutOfBorder(OutOfBorderDirection.Left);
        //���� �������� ������� spriteRenderer ������� �� ��� Y ������, ���  ���������� ������� �� ��� Y, ��� ����������� ����������� ������������ �����
        else if (transform.position.y - spriteRenderer.bounds.size.y / 2 > sizeBorder.y)
            onObjectOutOfBorder(OutOfBorderDirection.Top);
        //���� �������� ������� spriteRenderer ������� �� ��� Y ������, ���  ������������� ���������� ������� �� ��� Y, ��� ����������� ����������� ������������ ����
        else if (transform.position.y + spriteRenderer.bounds.size.y / 2 < -sizeBorder.y)
            onObjectOutOfBorder(OutOfBorderDirection.Bottom);
    }

    /// <summary>
    /// ����������� ������ ��� ����������� �������
    /// </summary>
    public enum OutOfBorderDirection
    {
        Top, Bottom, Left, Right
    }
}
