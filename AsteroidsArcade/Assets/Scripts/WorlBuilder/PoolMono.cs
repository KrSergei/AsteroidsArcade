using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolMono<T> where T : MonoBehaviour
{
    public T prefab { get; } //������ �� ������ �������

    public bool autoExpand { get; set; } //����, ��� ��� �����������

    public Transform container { get; } //������ �� ���������, ���������� ��� 

    private List<T> poolBullet; //������ ���������� �������

    public PoolMono(T prefab, int count)
    {
        this.prefab = prefab;
        container = null;
        CreatePool(count);
    }

    public PoolMono(T prefab, int count, Transform container)
    {
        this.prefab = prefab;
        this.container = container;
        CreatePool(count);
    }

    /// <summary>
    /// �������� ���� ������� �� ���������� ���������� 
    /// </summary>
    /// <param name="count"></param>
    private void CreatePool(int count)
    {
        //������������� ������
        poolBullet = new List<T>();

        //���������� ������ ��������� 
        for (int i = 0; i < count; i++)
        {
            //����� ������  ��� �������� �������
            CreateObject();
        }
    }

    /// <summary>
    /// �������� ������� � ��� �����������
    /// </summary>
    /// <param name="isActiveByDefault"></param>
    /// <returns></returns>
    private T CreateObject(bool isActiveByDefault = false)
    {
        //�������� �������
        var createdObject = Object.Instantiate(prefab, container);
        //���������� ���������� �������
        createdObject.gameObject.SetActive(isActiveByDefault);
        //Addind the created object to list 
        poolBullet.Add(createdObject);
        return createdObject;
    }

    /// <summary>
    /// �����, ������������ ���� �� ��������� ������� � ���� 
    /// ���������� true � ������ �� �������, ���� ���, ���������� false � element = null;
    /// </summary>
    /// <param name="element"></param>
    /// <returns></returns>
    public bool HasFreeElement(out T element)
    {
        //������� �� ������ ���������
        foreach(var mono in poolBullet)
        {
            //���� ������� �� ��������(���������)
            if (!mono.gameObject.activeInHierarchy)
            {
                //���������� ������ element �� ��������� ������� � ������
                element = mono;
                //��������� ��������
                mono.gameObject.SetActive(true);
                return true;
            }
        }
        //���� ��� ������ ��������� �������, ���������� null
        element = null;
        return false;
    }

    /// <summary>
    /// ������� ���������� ��������
    /// </summary>
    /// <returns></returns>
    public T GetFreeElement()
    {
        //���� ���� ��������� �������, ���������� ���
        if (HasFreeElement(out var element)) return element;
        //���� ��� ���������� ������� � ����� ���� ��������������, �� ������� ������ � �������� ���
        if (autoExpand) return CreateObject(true);

        throw new System.Exception($"Don't having a free element of type {typeof(T)}");
    }
}
