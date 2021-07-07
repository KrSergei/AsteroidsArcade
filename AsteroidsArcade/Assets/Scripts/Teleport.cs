using UnityEngine;

public class Teleport : OutOfBorderScreen
{
    private void Start()
    {
        //Подписка на событие пересечения границы
        onObjectOutOfBorder += ChangePos;
    }

    /// <summary>
    /// Метод телепортации объекта в зависимости от входного параметра - направления пересечения границы
    /// </summary>
    /// <param name="direction">Направление пересечения границы</param>
    private void ChangePos(OutOfBorderDirection direction)
    {
        //Определение направления пересечения границы
        switch (direction)
        {
            //Если пересечение Top, то перемещение объекта по оси Y на уровень Bottom: вычитание двойного размера границ по оси Y + размеры spriteRenderer по оси Y
            case OutOfBorderDirection.Top:
                transform.position -= new Vector3(0, sizeBorder.y * 2 + spriteRenderer.bounds.size.y);
                break;
            //Если пересечение Bottom, то перемещение объекта по оси Y на уровень Top: прибавление двойного размера границ по оси Y + размеры spriteRenderer по оси Y
            case OutOfBorderDirection.Bottom:
                transform.position += new Vector3(0, sizeBorder.y * 2 + spriteRenderer.bounds.size.y);
                break;
            //Если пересечение Right, то перемещение объекта по оси Х на сторону Left: вычитание двойного размера границ по оси Х + размеры spriteRenderer по оси X
            case OutOfBorderDirection.Right:
                transform.position -= new Vector3(sizeBorder.x * 2 + spriteRenderer.bounds.size.x, 0);
                break;
            //Если пересечение Left, то перемещение объекта по оси Х на сторону Right: добавление двойного размера границ по оси Х + размеры spriteRenderer по оси X
            case OutOfBorderDirection.Left:
                transform.position += new Vector3(sizeBorder.x * 2 + spriteRenderer.bounds.size.x, 0);
                break;
        }
    }

    /// <summary>
    /// Отписка от делегата
    /// </summary>
    private void OnDestroy()
    {
        //Отписка от события пересечения границы
        onObjectOutOfBorder -= ChangePos;
    }
}
