using System;
using System.Text;

class Program
{
    public static void Main(string[] args)
    {
        ConfigureConsole();
        
        bool isRunning = true;
        while (isRunning)
        {
            ShowMenu();
            string choice = GetUserChoice();
            
            switch (choice)
            {
                case "1":
                    HandleRandomMode();
                    break;
                case "2":
                    HandleManualMode();
                    break;
                case "0":
                    isRunning = false;
                    Console.WriteLine("Вихід з програми...");
                    break;
                default:
                    Console.WriteLine("Помилка: введено невірний варіант. Спробуйте ще раз.");
                    break;
            }
        }
    }

    static void ConfigureConsole()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;
    }

    static void ShowMenu()
    {
        Console.WriteLine("\n--- ГОЛОВНЕ МЕНЮ ---");
        Console.WriteLine("1. Заповнити масив випадково");
        Console.WriteLine("2. Заповнити масив вручну");
        Console.WriteLine("0. Вихід");
        Console.Write("\nВаш вибір: ");
    }

    static string GetUserChoice()
    {
        return Console.ReadLine();
    }

    static void HandleRandomMode()
    {
        int[][] randomArray = InputDataRandom();
        ExecuteArrayTask(ref randomArray);
    }

    static void HandleManualMode()
    {
        int[][] manualArray = InputDataManual();
        ExecuteArrayTask(ref manualArray);
    }

    static void ExecuteArrayTask(ref int[][] arrayToProcess)
    {
        PrintJaggedArray(arrayToProcess, "Початковий зубчастий масив:");
        
        DeleteEvenRows(ref arrayToProcess);
        
        PrintJaggedArray(arrayToProcess, "Масив після видалення парних рядків (2, 4, 6...):");
    }

    static int[][] InputDataRandom()
    {
        Console.Write("Скільки рядків (масивів) має бути? ");
        int arraysCount = Convert.ToInt32(Console.ReadLine());

        int[][] generatedArray = new int[arraysCount][];
        Random randomGenerator = new Random();

        for (int rowIndex = 0; rowIndex < arraysCount; rowIndex++)
        {
            Console.Write($"Введіть кількість елементів для рядка {rowIndex + 1}: ");
            int elementsCount = Convert.ToInt32(Console.ReadLine());

            generatedArray[rowIndex] = new int[elementsCount];
            for (int columnIndex = 0; columnIndex < elementsCount; columnIndex++)
            {
                generatedArray[rowIndex][columnIndex] = randomGenerator.Next(-10, 10);
            }
        }
        return generatedArray;
    }

    static int[][] InputDataManual()
    {
        Console.Write("Скільки рядків (масивів) має бути? ");
        int arraysCount = Convert.ToInt32(Console.ReadLine());

        int[][] generatedArray = new int[arraysCount][];

        for (int rowIndex = 0; rowIndex < arraysCount; rowIndex++)
        {
            Console.Write($"Введіть кількість елементів для рядка {rowIndex + 1}: ");
            int elementsCount = Convert.ToInt32(Console.ReadLine());

            generatedArray[rowIndex] = new int[elementsCount];

            Console.WriteLine($"Введіть {elementsCount} елементів через пробіл:");
            string inputString = Console.ReadLine();
            string[] stringElements = inputString.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            for (int columnIndex = 0; columnIndex < stringElements.Length && columnIndex < elementsCount; columnIndex++)
            {
                generatedArray[rowIndex][columnIndex] = Convert.ToInt32(stringElements[columnIndex]);
            }
        }
        return generatedArray;
    }

    static void DeleteEvenRows(ref int[][] initialData)
    {
        if (initialData == null || initialData.Length == 0)
        {
            Console.WriteLine("Масив порожній.");
            return;
        }

        int newArraySize = (initialData.Length + 1) / 2;
        int[][] filteredArray = new int[newArraySize][];
        int newRowIndex = 0;

        for (int rowIndex = 0; rowIndex < initialData.Length; rowIndex += 2) 
        {
            filteredArray[newRowIndex] = initialData[rowIndex]; 
            newRowIndex++;
        }

        initialData = filteredArray;
    }

    static void PrintJaggedArray(int[][] arrayToPrint, string headerMessage)
    {
        Console.WriteLine($"\n{headerMessage}");
        if (arrayToPrint.Length == 0)
        {
            Console.WriteLine("Масив порожній.");
            return;
        }

        for (int rowIndex = 0; rowIndex < arrayToPrint.Length; rowIndex++)
        {
            Console.Write($"Рядок {rowIndex + 1}: ");
            for (int columnIndex = 0; columnIndex < arrayToPrint[rowIndex].Length; columnIndex++)
            {
                Console.Write($"{arrayToPrint[rowIndex][columnIndex],5}");
            }
            Console.WriteLine();
        }
    }
}