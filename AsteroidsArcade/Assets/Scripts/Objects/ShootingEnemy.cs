using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : MonoBehaviour
{
    public GameObject bullet;           //������ ����
    public GameObject gun;              //������ ������

    public AudioSource shootSound;  //���� ��������

    public float delayTimeShooting = 1f;     //�������� ����� ����������
    private float startTimeShooting;     //����� �� ������ ��������

    void Update()
    {
        //�������� ������� �� ������ ��������, ���� ������� 0, �� �������� ������ �� ������ ��������, ����� ������ ������� 
        if (startTimeShooting <= 0)
        {
            //����� �������� ��������
            StartCoroutine(DoShoot());
            //����� �����������
            startTimeShooting = delayTimeShooting;
        }
        else startTimeShooting -= Time.deltaTime;  //���������� ��������� ����� ����������
    }

    /// <summary>
    /// ���������� �������� 
    /// </summary>
    public IEnumerator DoShoot()
    {
        //�������� ������� ����
        Instantiate(bullet, gun.transform.position, transform.rotation).GetComponent<BulletEnemy>();
        //������������ ����� ��������
        shootSound.Play();
        yield return null;
    }
}
