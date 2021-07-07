using System.Collections;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    /* Реализация контроля игрока. 
     * Управление через получение значений в зависимости от состояния нажатия кнопок W, S, A, D
     * Задание вектора направления кнопками W, S, задание поворота кнопками A, D
     * При старте, получение компонента Rigidbody2D у игрока
     * Каждый FixedUpdate:
     *      получение значений от нажатия клавиш  W, S, A, D
     *      вызов корутины для поворота игрока в зависимост от состояния кнопок нажатия A, D
     *      вызов корутины для передвижения игрока в зависимост от состояния кнопок нажатия W, S
     */

    public float force = 10f; //Ускорение

    public float speedRotate = 1f; //Скорость поворота

    Rigidbody2D rb; //Компонент Rigidbody2D игрока

    
    void Start()
    {
        //Получение компонента Rigidbody2D
        rb = GetComponent<Rigidbody2D>();
    }


    void FixedUpdate()
    {
        //определение направления движения по горизонтали 
        float directionSide = Input.GetAxisRaw("Horizontal");
        //определение направления движения по вертикали
        float directionForward = Input.GetAxisRaw("Vertical");
        //Запуск корутины поворота
        StartCoroutine(Rotate(directionSide, directionForward));
        //Запуск корутины передвижения
        StartCoroutine(Movement(directionSide, directionForward));

    }

    /// <summary>
    /// Поворот в заисимости от значений входящих параметров
    /// </summary>
    /// <param name="directionSide">значение по оси Х</param>
    /// <param name="directionForward">значение по оси Y</param>
    /// <returns></returns>
    IEnumerator Rotate(float directionSide, float directionForward)
    {
        //Поворот в заданном направлении
        rb.AddTorque(- directionSide * speedRotate * Time.deltaTime, 0f);
        yield return null;
    }

    /// <summary>
    /// Передвижение в заисимости от значений входящих параметров
    /// </summary>
    /// <param name="directionSide">значение по оси Х</param>
    /// <param name="directionForward">>значение по оси Y</param>
    /// <returns></returns>
    IEnumerator Movement(float directionSide, float directionForward)
    {
        //Придание ускорения игроку
        rb.AddRelativeForce(new Vector2(directionSide, directionForward) * force * Time.deltaTime);
        yield return null;
    }

    /// <summary>
    /// Метод, возвращающий текущее положение игрока
    /// </summary>
    /// <returns></returns>
    public Vector2 GetCurrentPosition()
    {
        return transform.position;
    }
}
