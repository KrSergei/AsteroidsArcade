using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : MonoBehaviour
{
    public GameObject bullet;           //Объект пули
    public GameObject gun;              //Объект оружие

    public AudioSource shootSound;  //Звук выстрела

    public float delayTimeShooting = 1f;     //интервал между выстрелами
    private float startTimeShooting;     //время до начала выстрела

    void Update()
    {
        //Проверка времени до старта стрельбы, если блольше 0, то обратный отсчет до начала стрельбы, иначе делаем выстрел 
        if (startTimeShooting <= 0)
        {
            //страт корутины стрельбы
            StartCoroutine(DoShoot());
            //старт перезарядки
            startTimeShooting = delayTimeShooting;
        }
        else startTimeShooting -= Time.deltaTime;  //Уменьшение интервала между выстрелами
    }

    /// <summary>
    /// Реализация стрельбы 
    /// </summary>
    public IEnumerator DoShoot()
    {
        //создание объекта пули
        Instantiate(bullet, gun.transform.position, transform.rotation).GetComponent<BulletEnemy>();
        //Проигрывание звука выстрела
        shootSound.Play();
        yield return null;
    }
}
