namespace KASD_Library_8;

public class MyVector<T>
{
    private T[] elementData; 
    private int elementCount; 
    private int capacityIncrement; 
    public MyVector(int initialCapacity, int capacityIncrement)
    {
        if (initialCapacity < 0) throw new ArgumentOutOfRangeException(nameof(initialCapacity));
        elementData = new T[initialCapacity];
        this.capacityIncrement = capacityIncrement;
        elementCount = 0;
    }

   
    public MyVector(int initialCapacity) : this(initialCapacity, 0) { }

    // Конструктор по умолчанию с ёмкостью 10 и приращением по умолчанию (0)
    public MyVector() : this(10) { }

    // Конструктор, заполняющий вектор элементами из массива
    public MyVector(T[] a)
    {
        elementData = new T[a.Length];
        Array.Copy(a, elementData, a.Length);
        elementCount = a.Length;
        capacityIncrement = 0;
    }

    // Метод для увеличения ёмкости
    private void EnsureCapacity(int minCapacity)
    {
        if (minCapacity > elementData.Length)
        {
            int newCapacity = elementData.Length;
            if (capacityIncrement > 0)
                newCapacity += capacityIncrement;
            else
                newCapacity = elementData.Length * 2;

            if (newCapacity < minCapacity) newCapacity = minCapacity;

            T[] newArray = new T[newCapacity];
            Array.Copy(elementData, newArray, elementCount);
            elementData = newArray;
        }
    }

    // Метод добавления элемента в конец
    public void Add(T e)
    {
        EnsureCapacity(elementCount + 1);
        elementData[elementCount++] = e;
    }

    // Метод для добавления всех элементов из массива
    public void AddAll(T[] a)
    {
        EnsureCapacity(elementCount + a.Length);
        Array.Copy(a, 0, elementData, elementCount, a.Length);
        elementCount += a.Length;
    }

    // Метод очистки вектора
    public void Clear()
    {
        elementCount = 0;
    }

    // Метод для проверки, содержится ли элемент в векторе
    public bool Contains(T o)
    {
        for (int i = 0; i < elementCount; i++)
        {
            if (elementData[i].Equals(o)) return true;
        }
        return false;
    }

    // Метод для проверки, содержатся ли все элементы массива в векторе
    public bool ContainsAll(T[] a)
    {
        foreach (T item in a)
        {
            if (!Contains(item)) return false;
        }
        return true;
    }

    // Метод для проверки, пуст ли вектор
    public bool IsEmpty()
    {
        return elementCount == 0;
    }

    // Метод удаления элемента
    public bool Remove(T o)
    {
        for (int i = 0; i < elementCount; i++)
        {
            if (elementData[i].Equals(o))
            {
                RemoveAt(i);
                return true;
            }
        }
        return false;
    }

    // Метод для удаления всех элементов из массива
    public void RemoveAll(T[] a)
    {
        foreach (T item in a)
        {
            Remove(item);
        }
    }

    // Метод для замены элемента
    public T Set(int index, T element)
    {
        if (index >= elementCount || index < 0) throw new ArgumentOutOfRangeException(nameof(index));
        T oldValue = elementData[index];
        elementData[index] = element;
        return oldValue;
    }

    // Метод для получения размера вектора
    public int Size()
    {
        return elementCount;
    }

    // Метод для удаления элемента по индексу
    public T RemoveAt(int index)
    {
        if (index >= elementCount || index < 0) throw new ArgumentOutOfRangeException(nameof(index));
        T oldValue = elementData[index];
        Array.Copy(elementData, index + 1, elementData, index, elementCount - index - 1);
        elementCount--;
        return oldValue;
    }

    // Метод для получения элемента по индексу
    public T Get(int index)
    {
        if (index >= elementCount || index < 0) throw new ArgumentOutOfRangeException(nameof(index));
        return elementData[index];
    }

    // Метод для получения массива всех элементов
    public T[] ToArray()
    {
        T[] result = new T[elementCount];
        Array.Copy(elementData, result, elementCount);
        return result;
    }

    // Метод для возврата подмножества вектора
    public MyVector<T> SubList(int fromIndex, int toIndex)
    {
        if (fromIndex < 0 || toIndex > elementCount || fromIndex > toIndex)
            throw new ArgumentOutOfRangeException();

        T[] subArray = new T[toIndex - fromIndex];
        Array.Copy(elementData, fromIndex, subArray, 0, toIndex - fromIndex);
        return new MyVector<T>(subArray);
    }

    // Метод для нахождения индекса элемента
    public int IndexOf(T o)
    {
        for (int i = 0; i < elementCount; i++)
        {
            if (elementData[i].Equals(o)) return i;
        }
        return -1;
    }

    // Метод для нахождения последнего индекса элемента
    public int LastIndexOf(T o)
    {
        for (int i = elementCount - 1; i >= 0; i--)
        {
            if (elementData[i].Equals(o)) return i;
        }
        return -1;
    }

    // Метод для возвращения первого элемента
    public T FirstElement()
    {
        if (IsEmpty()) throw new InvalidOperationException("Vector is empty");
        return elementData[0];
    }

    // Метод для возвращения последнего элемента
    public T LastElement()
    {
        if (IsEmpty()) throw new InvalidOperationException("Vector is empty");
        return elementData[elementCount - 1];
    }

    // Метод для удаления элемента на заданной позиции
    public void RemoveElementAt(int pos)
    {
        RemoveAt(pos);
    }

    // Метод для удаления нескольких элементов подряд
    public void RemoveRange(int begin, int end)
    {
        if (begin < 0 || end > elementCount || begin > end)
            throw new ArgumentOutOfRangeException();

        int numMoved = elementCount - end;
        Array.Copy(elementData, end, elementData, begin, numMoved);
        elementCount -= (end - begin);
    }
}
