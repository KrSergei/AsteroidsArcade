using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
    public float speed;             //�������� ������ ����
    public float lifeTime;          //����� ������������� ����
    public float distance;          //��������� �� ������� ������������ ������������ � ������� �����

    public LayerMask whatIsSolid;   //����� ����������� �������� ����

    private void Start()
    {
        StartCoroutine(LifeRoutine());
    }

    private void Update()
    {
        //����������� ������������ � ������� �����
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);

        //������� �������� ����
        StartCoroutine(Movement());

        //���� ���� ������������ � �����������
        if (hitInfo.collider != null)
        {
            //�������� ���������� �� ���� enemy
            if (hitInfo.collider.CompareTag("Player"))
            {
                 //����������� ����
                 Deactivate();
            }

            //�������� ���������� �� ���� enemy
            if (hitInfo.collider.CompareTag("Enemy"))
            {
                //��������� ���������� DestroyAndSpawnAsteroids � ������ ������ ��� ����������� � ��������� ���������� c ��������� ����� ������ �������� ����������
                hitInfo.collider.GetComponent<DestroyAsteroid>().StartDestroyAndSpawn(false);
            }

            //����������� ����
            Deactivate();
        }
    }

    /// <summary>
    /// ������� ����������� � ������������ ����
    /// </summary>
    /// <returns></returns>
    IEnumerator Movement()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
        yield return null;
    }

    private IEnumerator LifeRoutine()
    {
        yield return new WaitForSeconds(lifeTime);
        Deactivate();
    }

    private void OnDisable()
    {
        StopCoroutine(Movement());
        StopCoroutine(LifeRoutine());
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
        Destroy(gameObject);
    }
}
