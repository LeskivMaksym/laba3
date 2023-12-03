using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfArrayOperations
{
    public partial class MainWindow : Window
    {
        Random rnd = new Random();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void GenerateArrayButton_Click(object sender, RoutedEventArgs e)
        {
            int n = int.Parse(NumberOfElementsTextBox.Text);
            double[] array = GenerateRandomArray(n);

            // Display the generated array in the ListBox
            DisplayArray(array, GeneratedArrayListBox);
        }

        private double[] GenerateRandomArray(int n)
        {
            double[] array = new double[n];
            for (int i = 0; i < n; i++)
            {
                double randomValue = rnd.NextDouble() * (3.59 + 7.51) - 7.51;
                array[i] = Math.Round(randomValue, 2);
            }
            return array;
        }

        private void DisplayArray(double[] array, ListBox listBox)
        {
            listBox.Items.Clear();
            foreach (var item in array)
            {
                listBox.Items.Add(item);
            }
        }

        private void SumOfModulusButton_Click(object sender, RoutedEventArgs e)
        {
            double[] array = GetArrayFromListBox(GeneratedArrayListBox);
            double sum = CalculateSumOfModulus(array);
            ResultTextBox.Text = "Сума модулів елементів з дробовою частиною < 0.5: " + sum.ToString();
        }

        private double[] GetArrayFromListBox(ListBox listBox)
        {
            return listBox.Items.Cast<double>().ToArray();
        }

        private double CalculateSumOfModulus(double[] array)
        {
            double sum = 0;
            foreach (var item in array)
            {
                if (Math.Abs(item % 1) < 0.5)
                {
                    sum += Math.Abs(item);
                }
            }
            return sum;
        }

        private void SortArrayButton_Click(object sender, RoutedEventArgs e)
        {
            double[] array = GetArrayFromListBox(GeneratedArrayListBox);
            double[] sortedArray = SortArrayAfterMinValue(array);
            ResultTextBox.Text = "Масив після сортування: " + string.Join(", ", sortedArray);
        }

        private double[] SortArrayAfterMinValue(double[] array)
        {
            double min = array.Min();
            var sortedArray = array.Where(x => x > min).OrderByDescending(x => x).ToArray();
            return sortedArray;
        }
    }
}

