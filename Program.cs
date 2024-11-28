namespace KASD_Library_8;

public class Program
{
    public static void Main(string[] args)
    {
        MyStack<int> stack = new MyStack<int>();

        stack.Push(10);
        stack.Push(20);
        stack.Push(30);

        Console.WriteLine($"Peek: {stack.Peek()}"); // Ожидается 30

        Console.WriteLine($"Pop: {stack.Pop()}"); // Ожидается 30
        Console.WriteLine($"Peek после pop: {stack.Peek()}"); // Ожидается 20

        Console.WriteLine($"Empty: {stack.Empty()}"); // Ожидается False

        Console.WriteLine($"Search(10): {stack.Search(10)}"); // Ожидается 2
        Console.WriteLine($"Search(40): {stack.Search(40)}"); // Ожидается -1

        // Очищаем стек
        stack.Pop();
        stack.Pop();
        Console.WriteLine($"Empty после очистки: {stack.Empty()}"); // Ожидается True
    }
}
