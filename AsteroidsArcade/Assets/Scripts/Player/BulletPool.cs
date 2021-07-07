using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public Transform spawnPos;
    [SerializeField] private int poolCount = 10; //���������� ��������� � ���� 
    [SerializeField] private bool autoExpand = false;  //���� �������������� ���� ��� ���������� ��������� ���������
    [SerializeField] private Bullet bulletPrefab; //������ �� ������ ����


    private PoolMono<Bullet> pool;  //��� ��������

    private void Start()
    {
        pool = new PoolMono<Bullet>(bulletPrefab, poolCount, spawnPos);
        pool.autoExpand = autoExpand;
    }

    /// <summary>
    /// ���������� ��������� �������
    /// </summary>
    /// <returns></returns>
    public Bullet CreateBullet()
    {
        var cube = this.pool.GetFreeElement();

        cube.transform.position = spawnPos.position;
        //var rPosition = new Vector3(spawnPos.position.x, spawnPos.position.y, spawnPos.position.z);
        //cube.transform.position = rPosition;
        var bullet = pool.GetFreeElement();

        return bullet;
    }
}
