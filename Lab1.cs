
using System;
using System.Collections.Generic;

public interface ITask
{
    void Execute();
}

public class Task1 : ITask
{
    public void Execute()
    {
        int[] numbers = { 3, 15, 7 }; // Example input
        int lowerBound = 1;
        int upperBound = 15; // 10 + 5 (Example)

        Console.WriteLine($"Numbers in the range [{lowerBound}, {upperBound}]:");
        for (int i = 0; i < numbers.Length; i++)
        {
            if (numbers[i] >= lowerBound && numbers[i] <= upperBound)
            {
                Console.Write(numbers[i] + " ");
            }
        }
        Console.WriteLine();
    }
}

public class Task2 : ITask
{
    public void Execute()
    {
        int a = 3, b = 4, c = 5; // Example input

        if (a + b > c && a + c > b && b + c > a)
        {
            int perimeter = a + b + c;
            double s = perimeter / 2.0;
            double area = Math.Sqrt(s * (s - a) * (s - b) * (s - c));

            Console.WriteLine($"Perimeter: {perimeter}");
            Console.WriteLine($"Area: {area:F2}");

            if (a == b && b == c)
                Console.WriteLine("Type: Equilateral");
            else if (a == b || b == c || a == c)
                Console.WriteLine("Type: Isosceles");
            else
                Console.WriteLine("Type: Scalene");
        }
        else
        {
            Console.WriteLine("Triangle with these sides cannot exist.");
        }
    }
}

public class Task3 : ITask
{
    public void Execute()
    {
        int[] array = { 3, -5, 12, 7, 9, 15, -2, 0, 8, 6, 4 }; // Example array
        int min = array[0], max = array[0];

        for (int i = 1; i < array.Length; i++)
        {
            if (array[i] < min) min = array[i];
            if (array[i] > max) max = array[i];
        }

        Console.WriteLine("Array: ");
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write(array[i] + " ");
        }
        Console.WriteLine($"
Minimum: {min}, Maximum: {max}");
    }
}

public class Task4 : ITask
{
    public void Execute()
    {
        int[] array = { -10, -7, 0, 5, 3, -15, 20, 8, -2, 1, 6 }; // Example array
        int M = 5; // Example threshold
        List<int> result = new List<int>();

        for (int i = 0; i < array.Length; i++)
        {
            if (Math.Abs(array[i]) > M)
            {
                result.Add(array[i]);
            }
        }

        Console.WriteLine($"Given number M: {M}");
        Console.WriteLine("Original Array: ");
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write(array[i] + " ");
        }

        Console.WriteLine("
Filtered Array: ");
        foreach (int value in result)
        {
            Console.Write(value + " ");
        }
        Console.WriteLine();
    }
}

public class TaskController
{
    private readonly List<ITask> _tasks;

    public TaskController()
    {
        _tasks = new List<ITask>
        {
            new Task1(),
            new Task2(),
            new Task3(),
            new Task4()
        };
    }

    public void RunAll()
    {
        foreach (var task in _tasks)
        {
            task.Execute();
            Console.WriteLine(new string('-', 40));
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        TaskController controller = new TaskController();
        controller.RunAll();
    }
}
