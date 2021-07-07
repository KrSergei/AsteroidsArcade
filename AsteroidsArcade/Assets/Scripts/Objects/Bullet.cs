using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
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
            if (hitInfo.collider.CompareTag("Enemy"))
            {
                //��������� ���������� DestroyAndSpawnAsteroids � ������ ������ ��� ����������� � ��������� ����������
                hitInfo.collider.GetComponent<DestroyAsteroid>().StartDestroyAndSpawn();
            }

            if (hitInfo.collider.CompareTag("UFO"))
            {
                //��������� ���������� DestroyAndSpawnAsteroids � ������ ������ ��� ����������� � ��������� ����������
                hitInfo.collider.GetComponent<DestroyUFO>().StartDestroy();
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
