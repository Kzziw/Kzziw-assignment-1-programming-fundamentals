using System;
using System.Globalization;

class Program
{
    static double ReadNumber(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            if (double.TryParse(Console.ReadLine(), NumberStyles.Float,
                CultureInfo.InvariantCulture, out double number) && double.IsFinite(number))
                return number;

            Console.WriteLine("Enter a valid number.");
        }
    }

    static void Calculator()
    {
        double a = ReadNumber("Enter the first number: ");
        double b = ReadNumber("Enter the second number: ");
        Console.Write("Enter operation (+, -, *, /): ");
        string operation = Console.ReadLine().Trim();
        double result;

        switch (operation)
        {
            case "+": result = a + b; break;
            case "-": result = a - b; break;
            case "*": result = a * b; break;
            case "/":
                if (b == 0)
                {
                    Console.WriteLine("Error: Division by zero.");
                    return;
                }
                result = a / b;
                break;
            default:
                Console.WriteLine("Invalid operation.");
                return;
        }
        Console.WriteLine($"Result: {result:G}");
    }

    static void TemperatureConverter()
    {
        Console.Write("Enter C or F: ");
        string direction = Console.ReadLine().Trim().ToUpperInvariant();

        if (direction == "C")
        {
            double celsius = ReadNumber("Enter temperature: ");
            double fahrenheit = celsius * 1.8 + 32;
            Console.WriteLine($"{celsius:G}°C = {fahrenheit:G}°F");
        }
        else if (direction == "F")
        {
            double fahrenheit = ReadNumber("Enter temperature: ");
            double celsius = (fahrenheit - 32) / 1.8;
            Console.WriteLine($"{fahrenheit:G}°F = {celsius:G}°C");
        }
        else
            Console.WriteLine("Invalid conversion direction.");
    }

    static void GradeAverage()
    {
        Console.Write("Enter the number of grades: ");
        if (!int.TryParse(Console.ReadLine(), out int count) || count <= 0)
        {
            Console.WriteLine("Invalid number of grades.");
            return;
        }

        double total = 0;
        for (int i = 0; i < count; i++)
        {
            double grade = ReadNumber($"Enter grade {i + 1}: ");
            while (grade < 1 || grade > 6)
                grade = ReadNumber("Enter a grade between 1 and 6: ");
            total += grade;
        }

        double average = total / count;
        Console.WriteLine($"Average: {average:F2}");
        if (average >= 3.0)
            Console.WriteLine("The student passed.");
        else
            Console.WriteLine("The student failed.");
    }

    static void Main()
    {
        CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;
        string choice;
        do
        {
            Console.WriteLine("\n===== ASSIGNMENT 1 =====");
            Console.WriteLine("1. Calculator");
            Console.WriteLine("2. Temperature converter");
            Console.WriteLine("3. Student grade average");
            Console.WriteLine("0. Exit");
            Console.Write("Select a task: ");
            choice = Console.ReadLine()?.Trim() ?? "0";

            switch (choice)
            {
                case "1": Calculator(); break;
                case "2": TemperatureConverter(); break;
                case "3": GradeAverage(); break;
                case "0": Console.WriteLine("Goodbye!"); break;
                default: Console.WriteLine("Invalid choice."); break;
            }
        } while (choice != "0");
    }
}
