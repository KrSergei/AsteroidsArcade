using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{   

    /// <summary>
    /// �����, ������� ��������� ���������� ������
    /// </summary>
    public int AddLife(int value)
    {
        value++;
        return value;
    }

    /// <summary>
    /// �����, ������� ��������� ���������� ������
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
