using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    private Transform player;           //Объект игрок
    public float offsetGun;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void Update()
    {
        StartCoroutine(RotationToTarget());
    }

    /// <summary>
    /// Метод для поворота в сторону цели
    /// </summary>
    IEnumerator RotationToTarget()
    {
        //Получение значения положения цели
        Vector2 currentTargetPos = player.position - transform.position;
        //Вычисление угла поворота по оси Z
        float rotateZ = Mathf.Atan2(currentTargetPos.y, currentTargetPos.x) * Mathf.Rad2Deg;
        //Поворот к цели на заданный угол по оси Z с добавлением угла поворота
        transform.rotation = Quaternion.Euler(0f, 0f, rotateZ + offsetGun);
        yield return null;
    }
}
