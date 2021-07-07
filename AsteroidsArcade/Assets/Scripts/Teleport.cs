using UnityEngine;

public class Teleport : OutOfBorderScreen
{
    private void Start()
    {
        //�������� �� ������� ����������� �������
        onObjectOutOfBorder += ChangePos;
    }

    /// <summary>
    /// ����� ������������ ������� � ����������� �� �������� ��������� - ����������� ����������� �������
    /// </summary>
    /// <param name="direction">����������� ����������� �������</param>
    private void ChangePos(OutOfBorderDirection direction)
    {
        //����������� ����������� ����������� �������
        switch (direction)
        {
            //���� ����������� Top, �� ����������� ������� �� ��� Y �� ������� Bottom: ��������� �������� ������� ������ �� ��� Y + ������� spriteRenderer �� ��� Y
            case OutOfBorderDirection.Top:
                transform.position -= new Vector3(0, sizeBorder.y * 2 + spriteRenderer.bounds.size.y);
                break;
            //���� ����������� Bottom, �� ����������� ������� �� ��� Y �� ������� Top: ����������� �������� ������� ������ �� ��� Y + ������� spriteRenderer �� ��� Y
            case OutOfBorderDirection.Bottom:
                transform.position += new Vector3(0, sizeBorder.y * 2 + spriteRenderer.bounds.size.y);
                break;
            //���� ����������� Right, �� ����������� ������� �� ��� � �� ������� Left: ��������� �������� ������� ������ �� ��� � + ������� spriteRenderer �� ��� X
            case OutOfBorderDirection.Right:
                transform.position -= new Vector3(sizeBorder.x * 2 + spriteRenderer.bounds.size.x, 0);
                break;
            //���� ����������� Left, �� ����������� ������� �� ��� � �� ������� Right: ���������� �������� ������� ������ �� ��� � + ������� spriteRenderer �� ��� X
            case OutOfBorderDirection.Left:
                transform.position += new Vector3(sizeBorder.x * 2 + spriteRenderer.bounds.size.x, 0);
                break;
        }
    }

    /// <summary>
    /// ������� �� ��������
    /// </summary>
    private void OnDestroy()
    {
        //������� �� ������� ����������� �������
        onObjectOutOfBorder -= ChangePos;
    }
}
