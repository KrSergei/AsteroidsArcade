using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
    public float speed;             //скорость полета пули
    public float lifeTime;          //время существования пули
    public float distance;          //дистанция на которой определяется столкновение с жестким телом

    public LayerMask whatIsSolid;   //маска определения жесткого тела

    private void Start()
    {
        StartCoroutine(LifeRoutine());
    }

    private void Update()
    {
        //Определение столкновения с жестким телом
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);

        //Задание движения пуле
        StartCoroutine(Movement());

        //Если есть столкновение с коллайдером
        if (hitInfo.collider != null)
        {
            //Проверка коллайдера по тегу enemy
            if (hitInfo.collider.CompareTag("Player"))
            {
                 //Деактивация пули
                 Deactivate();
            }

            //Проверка коллайдера по тегу enemy
            if (hitInfo.collider.CompareTag("Enemy"))
            {
                //Получение компонента DestroyAndSpawnAsteroids и вызвов метода для уничтожения и генерации астероидов c указанием флага отказа подсчета результата
                hitInfo.collider.GetComponent<DestroyAsteroid>().StartDestroyAndSpawn(false);
            }

            //Деактивация пули
            Deactivate();
        }
    }

    /// <summary>
    /// Задание направления и передвижение пули
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
