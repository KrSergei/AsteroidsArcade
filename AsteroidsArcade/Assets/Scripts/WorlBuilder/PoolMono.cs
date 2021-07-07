using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolMono<T> where T : MonoBehaviour
{
    public T prefab { get; } //Ссылка на префаб объекта

    public bool autoExpand { get; set; } //Флаг, что пул расширяемый

    public Transform container { get; } //Ссылка на контейнер, содержащий пул 

    private List<T> poolBullet; //Список содержащий объекты

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
    /// Создание пула объекта по указанному количеству 
    /// </summary>
    /// <param name="count"></param>
    private void CreatePool(int count)
    {
        //Инициализация списка
        poolBullet = new List<T>();

        //Заполнение списка объектами 
        for (int i = 0; i < count; i++)
        {
            //Вызов метода  для создания объекта
            CreateObject();
        }
    }

    /// <summary>
    /// Создание объекта и его деактивания
    /// </summary>
    /// <param name="isActiveByDefault"></param>
    /// <returns></returns>
    private T CreateObject(bool isActiveByDefault = false)
    {
        //Создание объекта
        var createdObject = Object.Instantiate(prefab, container);
        //Отключение созданного объекта
        createdObject.gameObject.SetActive(isActiveByDefault);
        //Addind the created object to list 
        poolBullet.Add(createdObject);
        return createdObject;
    }

    /// <summary>
    /// Метод, определяющий есть ли свободный элемент в пуле 
    /// Возвращает true и ссылку на элемент, если нет, возвращает false и element = null;
    /// </summary>
    /// <param name="element"></param>
    /// <returns></returns>
    public bool HasFreeElement(out T element)
    {
        //Перебор по списку элементов
        foreach(var mono in poolBullet)
        {
            //Если элемент не активный(свободный)
            if (!mono.gameObject.activeInHierarchy)
            {
                //Присвоение ссылки element на свободный элемент в списке
                element = mono;
                //Включение элемента
                mono.gameObject.SetActive(true);
                return true;
            }
        }
        //Если нет найден свободный элемент, возвращает null
        element = null;
        return false;
    }

    /// <summary>
    /// Возврат свободного элемента
    /// </summary>
    /// <returns></returns>
    public T GetFreeElement()
    {
        //Если есть свободный элемент, возвращает его
        if (HasFreeElement(out var element)) return element;
        //Если нет свободного элемент и стоит флаг авторасширения, то создает объект и включает его
        if (autoExpand) return CreateObject(true);

        throw new System.Exception($"Don't having a free element of type {typeof(T)}");
    }
}
