using System;

class Program
{
    static void Main()
    {
        Console.Write("Введіть кількість рядків: ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("Введіть кількість стовпців: ");
        int m = int.Parse(Console.ReadLine());

        double[,] array = new double[n, m];

        // Заповнення масиву псевдовипадковими числами в заданому діапазоні
        Random random = new Random();
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                double randomNumber = (random.NextDouble() * (7.03 - (-42.31))) + (-42.31);
                array[i, j] = Math.Round(randomNumber, 2);
            }
        }

        // Виведення початкового масиву
        Console.WriteLine("Початковий масив:");
        PrintArray(array);

        // Завдання 1: Знайдемо кількість рядків без від'ємних елементів
        int rowsWithoutNegatives = 0;
        for (int i = 0; i < n; i++)
        {
            bool hasNegative = false;
            for (int j = 0; j < m; j++)
            {
                if (array[i, j] < 0)
                {
                    hasNegative = true;
                    break;
                }
            }
            if (!hasNegative)
            {
                rowsWithoutNegatives++;
            }
        }
        Console.WriteLine($"Кількість рядків без від'ємних елементів: {rowsWithoutNegatives}");

        // Завдання 2: Поміняємо порядок елементів у стовпцях на протилежний
        for (int j = 0; j < m; j++)
        {
            for (int i = 0; i < n / 2; i++)
            {
                double temp = array[i, j];
                array[i, j] = array[n - 1 - i, j];
                array[n - 1 - i, j] = temp;
            }
        }

        // Виведення масиву після зміни порядку елементів у стовпцях
        Console.WriteLine("Масив після зміни порядку елементів у стовпцях:");
        PrintArray(array);
    }

    // Метод для виведення масиву
    static void PrintArray(double[,] array)
    {
        int n = array.GetLength(0);
        int m = array.GetLength(1);
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                Console.Write($"{array[i, j],8:F2} ");
            }
            Console.WriteLine();
        }
    }
}
