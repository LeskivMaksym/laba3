using System;

class Program
{
    static void Main()
    {
        Console.Write("Введіть кількість елементів масиву: ");
        int n = int.Parse(Console.ReadLine());

        // Оголошення масиву типу double та створення об'єкта Random
        double[] array = new double[n];
        Random rnd = new Random();

        // Заповнення масиву псевдовипадковими числами
        for (int i = 0; i < n; i++)
        {
            double randomValue = Math.Round((rnd.NextDouble() * (3.59 - (-7.51)) + (-7.51)), 2);
            array[i] = randomValue;
        }

        // Виведення початкового масиву
        Console.WriteLine("Початковий масив:");
        PrintArray(array);

        // Знайти суму модулів елементів, які мають дробову частину меншу за 0.5
        double sum = 0;
        foreach (double element in array)
        {
            if (Math.Abs(element % 1) < 0.5)
            {
                sum += Math.Abs(element);
            }
        }
        Console.WriteLine($"Сума модулів елементів з дробовою частиною меншою за 0.5: {sum}");

        // Знайдемо мінімальний елемент та відсортуємо решту
        double min = array[0];
        int minIndex = 0;
        for (int i = 1; i < n; i++)
        {
            if (array[i] < min)
            {
                min = array[i];
                minIndex = i;
            }
        }

        Array.Sort(array, minIndex + 1, n - minIndex - 1, Comparer<double>.Create((a, b) => b.CompareTo(a)));

        // Виведення відсортованого масиву
        Console.WriteLine("Масив після впорядкування:");
        PrintArray(array);
    }

    static void PrintArray(double[] arr)
    {
        foreach (double element in arr)
        {
            Console.Write(element + " ");
        }
        Console.WriteLine();
    }
}
