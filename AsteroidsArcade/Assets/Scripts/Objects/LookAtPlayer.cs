using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    private Transform player;           //������ �����
    public float offsetGun;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void Update()
    {
        StartCoroutine(RotationToTarget());
    }

    /// <summary>
    /// ����� ��� �������� � ������� ����
    /// </summary>
    IEnumerator RotationToTarget()
    {
        //��������� �������� ��������� ����
        Vector2 currentTargetPos = player.position - transform.position;
        //���������� ���� �������� �� ��� Z
        float rotateZ = Mathf.Atan2(currentTargetPos.y, currentTargetPos.x) * Mathf.Rad2Deg;
        //������� � ���� �� �������� ���� �� ��� Z � ����������� ���� ��������
        transform.rotation = Quaternion.Euler(0f, 0f, rotateZ + offsetGun);
        yield return null;
    }
}
