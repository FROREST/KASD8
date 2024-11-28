namespace KASD_Library_8;

using System;

public class MyStack<T> : MyVector<T>
{
    // Метод для добавления элемента в стек (push)
    public void Push(T item)
    {
        Add(item); // Используем метод Add из MyVector
    }

    // Метод для извлечения элемента из стека (pop)
    public T Pop()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Stack is empty.");
        }
        return RemoveAt(Size() - 1); // Удаляем последний элемент
    }

    // Метод для просмотра верхнего элемента без извлечения (peek)
    public T Peek()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Stack is empty.");
        }
        return LastElement(); // Возвращаем последний элемент
    }

    // Метод для проверки, пуст ли стек
    public bool Empty()
    {
        return IsEmpty(); // Используем метод IsEmpty из MyVector
    }

    // Метод для поиска глубины элемента (search)
    public int Search(T item)
    {
        int index = LastIndexOf(item); // Находим последний индекс элемента
        if (index == -1)
        {
            return -1; // Если элемент не найден
        }
        return Size() - index; // Глубина элемента
    }
}