using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementUFO : MonoBehaviour
{

    public float force = 15f; //Сила воздействия
    public float minTimeForce = 2f; //Минимальное время действия силы
    public float maxTimeForce = 5f; //Максимальное время действия силы
    Rigidbody2D rb; //Компонент Rigidbody2D

    private float currentTimeForce;  //Текущее время действия силы
    private Vector2 sizeBorder; //Границы экрана
    private Vector2 direction;  //Вектор движения

    void Awake()
    {
        //Определение размера границы
        sizeBorder = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
    }

    private void Start()
    {
        //Получение компонента  Rigidbody2D
        rb = GetComponent<Rigidbody2D>();
        //Определение времени действия с
        GetTimeForce();
        direction = GetDirection();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        //Если текущее время воздействия силы больше 0, вызов корутины движения и декремент времени воздействия силы
        if (currentTimeForce > 0)
        {
            StartCoroutine(Movement(direction));
            currentTimeForce -= Time.deltaTime;
        }
        //Если текущее время воздействия силы меньше  равно 0, определение нового времени воздействия и нового вектора направления
        if (currentTimeForce <= 0)
        {
            GetTimeForce();
            direction = GetDirection();
        }

    }

    /// <summary>
    /// Корутина движения с заданным вектором
    /// </summary>
    /// <param name="currentDirection"></param>
    /// <returns></returns>
    IEnumerator Movement(Vector2 currentDirection)
    {
        //Придание ускорения в зависимости от выбранного вектора направления
        rb.AddRelativeForce(currentDirection * force * Time.deltaTime);
        yield return null;
    }

    /// <summary>
    /// Получение случайного времени действия силы
    /// </summary>
    private void GetTimeForce()
    {
        currentTimeForce = Random.Range(minTimeForce, maxTimeForce);
    }

    /// <summary>
    /// Определение нового вектора направления движения
    /// </summary>
    /// <returns></returns>
    private Vector2 GetDirection()
    {
        //Обнуление текущего вектора
        direction = Vector2.zero;
        //Определение новго вектора движения
        direction = new Vector2(GetRandomValue(sizeBorder.x), GetRandomValue(sizeBorder.y));
        return direction;
    }

    /// <summary>
    /// Определение случайного значения
    /// </summary>
    /// <param name="minValue"></param>
    /// <param name="maxValue"></param>
    /// <returns></returns>
    private float GetRandomValue(float value)
    {
        return Random.Range(-value, value);
    }
}
