using System;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class OutOfBorderScreen : MonoBehaviour
{
    protected Vector2 sizeBorder;   //Размер границы

    protected SpriteRenderer spriteRenderer; //Компонент для определения текущего положения

    public Action<OutOfBorderDirection> onObjectOutOfBorder; //Делегат пересечения границы

    void Awake()
    {
        //Получение компонента SpriteRenderer
        spriteRenderer = GetComponent<SpriteRenderer>();
        //Определение размера границы. Получение  координат границы по размеру экрана
        sizeBorder = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
    }

    void Update()
    {
        //Если половина размера spriteRenderer объекта по оси Х больше, чем координата границы по оси Х, что определение направления пересечечния вправо
        if (transform.position.x - spriteRenderer.bounds.size.x / 2 > sizeBorder.x)
            onObjectOutOfBorder(OutOfBorderDirection.Right);
        //Если половина размера spriteRenderer объекта по оси Х меньше, чем  отрицательная координата границы по оси Х, что определение направления пересечечния влево
        else if (transform.position.x + spriteRenderer.bounds.size.x / 2 < -sizeBorder.x)
            onObjectOutOfBorder(OutOfBorderDirection.Left);
        //Если половина размера spriteRenderer объекта по оси Y меньше, чем  координата границы по оси Y, что определение направления пересечечния вверх
        else if (transform.position.y - spriteRenderer.bounds.size.y / 2 > sizeBorder.y)
            onObjectOutOfBorder(OutOfBorderDirection.Top);
        //Если половина размера spriteRenderer объекта по оси Y меньше, чем  отрицательная координата границы по оси Y, что определение направления пересечечния вниз
        else if (transform.position.y + spriteRenderer.bounds.size.y / 2 < -sizeBorder.y)
            onObjectOutOfBorder(OutOfBorderDirection.Bottom);
    }

    /// <summary>
    /// Направление сторон при пересечении границы
    /// </summary>
    public enum OutOfBorderDirection
    {
        Top, Bottom, Left, Right
    }
}
