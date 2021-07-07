using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public Transform spawnPos;
    [SerializeField] private int poolCount = 10; //Количество элементов в пуле 
    [SerializeField] private bool autoExpand = false;  //Флаг авторасширение пула при отсутствии свободных элементов
    [SerializeField] private Bullet bulletPrefab; //Ссылка на пребаф пули


    private PoolMono<Bullet> pool;  //Пул объектов

    private void Start()
    {
        pool = new PoolMono<Bullet>(bulletPrefab, poolCount, spawnPos);
        pool.autoExpand = autoExpand;
    }

    /// <summary>
    /// Возвращает свободный элемент
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
