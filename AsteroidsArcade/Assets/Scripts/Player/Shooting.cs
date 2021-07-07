using System.Collections;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    public GameObject bullet;           //������ ����
    public GameObject gun;              //������ ������
    public AudioSource shootSound;      //���� ��������

    public float delayTimeShooting = 0.1f;     //�������� ����� ����������
    private float startTimeShooting;     //����� �� ������ ��������

    void Update()
    {
        //�������� ������� �� ������ ��������, ���� ������� 0, �� �������� ������ �� ������ ��������, ����� ������ ������� 
        if (startTimeShooting <= 0)
        {
            if(Input.GetKey(KeyCode.Space))
            {
                //����� �������� ��������
                StartCoroutine(DoShoot());
                //����� �����������
                startTimeShooting = delayTimeShooting;
            }
        }
        else startTimeShooting -= Time.deltaTime;  //���������� ��������� ����� ����������
    }

    /// <summary>
    /// ���������� �������� 
    /// </summary>
    public IEnumerator DoShoot()
    {
        //�������� ������� ����
        Instantiate(bullet, gun.transform.position, transform.rotation).GetComponent<Bullet>();
        //������������ ����� ��������
        shootSound.Play();
        yield return null;
    }
}
