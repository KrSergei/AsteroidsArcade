
using System.Collections;
using UnityEngine;

public class MovementAsteroid : MonoBehaviour
{
    public float force; //Сила воздействия
    Rigidbody2D rb; //Компонент Rigidbody2D
    
    void Start()
    {
        //Получение комоненты Rigidbody2D
        rb = GetComponent<Rigidbody2D>();
        //Запуск корутины для движения астероида
        StartCoroutine(Movement());
    }

    /// <summary>
    /// Задание движения астероиду
    /// </summary>
    /// <returns></returns>
    IEnumerator Movement()
    {
        //Придание испульса ускорения астероиду по случайному вектору направления
        rb.AddRelativeForce(new Vector2(RandomValue(), RandomValue()) * force, ForceMode2D.Impulse);
        yield return null;
    }

    /// <summary>
    /// Определение и возврат случайного числа для координаты вектора от -1 до 1
    /// </summary>
    /// <returns></returns>
    private float RandomValue()
    {
        return Random.Range(-1f, 1f);
    }
}
