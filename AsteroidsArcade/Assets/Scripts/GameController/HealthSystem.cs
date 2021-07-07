using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{   

    /// <summary>
    /// Метод, который уменьшает количество жизней
    /// </summary>
    public int AddLife(int value)
    {
        value++;
        return value;
    }

    /// <summary>
    /// Метод, который уменьшает количество жизней
    /// </summary>
    public int CalcLife(int value)
    {
        value--;
        if( value == 0)
        {
           
        }
        return value;
    }
}
