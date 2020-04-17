using System;
using System.IO;
namespace Lab7._2
{
    class Program
    {
        static void Swap(ref int a, ref int b)
        {
            int tmp = a;
            a = b;
            b = tmp;
        }
        static void InsertionSort(int[] array, int l, int r, out TimeSpan interval, out long comparisons, out int swaps)
        {
            comparisons = 0;
            swaps = 0;
            DateTime StartTime;
            StartTime = DateTime.Now;

            for (int i = l + 1; i <= r; i++)
            {

                int j = i;
                int tmp = array[i];
                comparisons++;
                while (j > l && tmp > array[j - 1])
                {
                    comparisons++;
                    array[j] = array[j - 1];
                    j--;
                }
                array[j] = tmp;
                swaps++;
            }
            DateTime EndTime = DateTime.Now;
            interval = EndTime - StartTime;
        }
        static void SelectionSort(int[] array, int l, int r, out TimeSpan interval, out int comparisons, out int swaps)
        {
            comparisons = 1;
            swaps = 0;
            DateTime StartTime;
            StartTime = DateTime.Now;
            for (int i = l; i < r; i++)
            {
                int max = i;
                for (int j = i + 1; j <= r; j++)
                {
                    if (array[max] < array[j])
                    {
                        comparisons++;
                        max = j;
                    }
                }
                Swap(ref array[max], ref array[i]);
                swaps++;

            }
            DateTime EndTime = DateTime.Now;
            interval = EndTime - StartTime;
        }
        static void BubbleSort(int[] array, int l, int r, out TimeSpan interval, out long comparisons, out long swaps)
        {
            comparisons = 1;
            swaps = 0;
            DateTime StartTime;
            StartTime = DateTime.Now;
            for (int i = l; i < r; i++)
            {
                for (int j = r; j > i; j--)
                {
                    if (array[j - 1] < array[j])
                    {
                        comparisons++;
                        Swap(ref array[j - 1], ref array[j]);
                        swaps++;
                    }
                }
            }
            DateTime EndTime = DateTime.Now;
            interval = EndTime - StartTime;
        }
        static void ShakerSort(int[] array, int l, int r, out TimeSpan interval, out long comparisons, out long swaps)
        {
            comparisons = 1;
            swaps = 0;
            DateTime StartTime;
            StartTime = DateTime.Now;
            do
            {
                for (int i = l; i < r; i++)
                {
                    if (array[i] < array[i + 1])
                    {
                        comparisons++;
                        Swap(ref array[i], ref array[i + 1]);
                        swaps++;
                    }
                }
                r--;
                for (int i = r; i > l; i--)
                {
                    if (array[i] > array[i - 1])
                    {
                        comparisons++;
                        Swap(ref array[i], ref array[i - 1]);
                        swaps++;
                    }
                }
                l++;
            }
            while (l <= r);
            DateTime EndTime = DateTime.Now;
            interval = EndTime - StartTime;
        }
        static void Sort(int[] array, int l, int r, out TimeSpan interval, out int comparisons, out int swaps)
        {
            comparisons = 1;
            swaps = 0;
            DateTime StartTime;
            StartTime = DateTime.Now;
            int[] S = { 57, 23, 10, 4, 1 };
            foreach (int step in S)
            {
                for (int i = l + step; i <= r; i++)
                {
                    int tmp = array[i];
                    int j = i;
                    while (j >= l + step && tmp > array[j - step])
                    {
                        comparisons++;
                        array[j] = array[j - step];
                        j -= step;
                        swaps++;
                    }
                    array[j] = tmp;
                    
                }

            }
            DateTime EndTime = DateTime.Now;
            interval = EndTime - StartTime;
        }

        static void Main(string[] args)
        {
            string path = @"C:\Users\alisa\source\repos\Lab6.5\sorted.dat";
            Random rnd = new Random();
            int[] mas = new int[1000];
            for (int i = 0; i < mas.Length; i++)
            {
                mas[i] = rnd.Next(1000);
            }
            int[] array = new int[mas.Length];
            using (StreamWriter write = new StreamWriter(path, false))
            {
                int[] insertionSortArray = new int[mas.Length];
                for (int i = 0, k = mas.Length - 1; i < mas.Length && k > 0; i++, k--)
                {
                    insertionSortArray[i] = mas[k];
                }
                InsertionSort(insertionSortArray, 0, mas.Length - 1, out TimeSpan interval, out long comparisons, out int swaps);
                for (int i = 0; i < mas.Length; i++)
                {
                    write.Write(insertionSortArray[i] + " ");
                }
                Console.WriteLine("Сортировка вставками(массив из случайных чисел)\nВремя работы:{0}\nКоличество сравнений:{1}\nКоличество перестановок:{2}", interval, comparisons, swaps);
                write.WriteLine();
                array = insertionSortArray;
            }
            Console.WriteLine();
            using (StreamWriter write = new StreamWriter(path, true))
            {
                int[] insertionSortArray = array;
                InsertionSort(insertionSortArray, 0, mas.Length - 1, out TimeSpan interval, out long comparisons, out int swaps);
                for (int i = 0; i < mas.Length; i++)
                {
                    write.Write(insertionSortArray[i] + " ");
                }
                Console.WriteLine("Сортировка вставками(массив, отсортированный в порядке убывания)\nВремя работы:{0}\nКоличество сравнений:{1}\nКоличество перестановок:{2}", interval, comparisons, swaps);
                write.WriteLine();
            }
            Console.WriteLine();
            using (StreamWriter write = new StreamWriter(path, true))
            {
                int[] insertionSortArray = new int[array.Length];
                for (int i = 0, j = insertionSortArray.Length - 1; i < insertionSortArray.Length; i++, j--)
                {
                    insertionSortArray[i] = array[j];
                }
                InsertionSort(insertionSortArray, 0, mas.Length - 1, out TimeSpan interval, out long comparisons, out int swaps);
                for (int i = 0; i < mas.Length; i++)
                {
                    write.Write(insertionSortArray[i] + " ");
                }
                Console.WriteLine("Сортировка вставками(массив, отсортированный в порядке возрастания)\nВремя работы:{0}\nКоличество сравнений:{1}\nКоличество перестановок:{2}", interval, comparisons, swaps);
                write.WriteLine();
            }
            Console.WriteLine();

            using (StreamWriter write = new StreamWriter(path, true))
            {
                int[] SelectionSortArray = new int[mas.Length];
                for (int i = 0, k = mas.Length - 1; i < mas.Length && k > 0; i++, k--)
                {
                    SelectionSortArray[i] = mas[k];
                }
                SelectionSort(SelectionSortArray, 0, mas.Length - 1, out TimeSpan interval, out int comparisons, out int swaps);
                for (int i = 0; i < mas.Length; i++)
                {
                    write.Write(SelectionSortArray[i] + " ");
                }
                Console.WriteLine("Сортировка выбором(массив заполнен случайными числами)\nВремя работы:{0}\nКоличество сравнений:{1}\nКоличество перестановок:{2}", interval, comparisons, swaps);
                write.WriteLine();
                array = SelectionSortArray;
            }
            Console.WriteLine();
            using (StreamWriter write = new StreamWriter(path, true))
            {
                int[] SelectionSortArray = array;
                SelectionSort(SelectionSortArray, 0, mas.Length - 1, out TimeSpan interval, out int comparisons, out int swaps);
                for (int i = 0; i < mas.Length; i++)
                {
                    write.Write(SelectionSortArray[i] + " ");
                }
                Console.WriteLine("Сортировка выбором(массив, отсортированный в порядке убывания)\nВремя работы:{0}\nКоличество сравнений:{1}\nКоличество перестановок:{2}", interval, comparisons, swaps);
                write.WriteLine();
            }
            Console.WriteLine();
            using (StreamWriter write = new StreamWriter(path, true))
            {

                int[] SelectionSortArray = new int[mas.Length];
                for (int i = 0, j = SelectionSortArray.Length - 1; i < SelectionSortArray.Length; i++, j--)
                {
                    SelectionSortArray[i] = array[j];
                }
                InsertionSort(SelectionSortArray, 0, mas.Length - 1, out TimeSpan interval, out long comparisons, out int swaps);
                for (int i = 0; i < mas.Length; i++)
                {
                    write.Write(SelectionSortArray[i] + " ");
                }
                Console.WriteLine("Сортировка выбором(массив, отсортированный в порядке возрастания)\n Время работы:{0}\nКоличество сравнений:{1}\nКоличество перестановок:{2}", interval, comparisons, swaps);
                write.WriteLine();
            }
            Console.WriteLine();
            using (StreamWriter write = new StreamWriter(path, true))
            {
                int[] bubbleSortArray = new int[mas.Length];
                for (int i = 0, k = mas.Length - 1; i < mas.Length && k > 0; i++, k--)
                {
                    bubbleSortArray[i] = mas[k];
                }
                BubbleSort(bubbleSortArray, 0, mas.Length - 1, out TimeSpan interval, out long comparisons, out long swaps);
                for (int i = 0; i < mas.Length; i++)
                {
                    write.Write(bubbleSortArray[i] + " ");
                }
                Console.WriteLine("Сортировка пузырьком(массив заполнен случайными числами)\nВремя работы:{0}\nКоличество сравнений:{1}\nКоличество перестановок:{2}", interval, comparisons, swaps);
                write.WriteLine();
                array = bubbleSortArray;
            }
            Console.WriteLine();
            using (StreamWriter write = new StreamWriter(path, true))
            {
                int[] bubbleSortArray = array;
                BubbleSort(bubbleSortArray, 0, mas.Length - 1, out TimeSpan interval, out long comparisons, out long swaps);
                for (int i = 0; i < mas.Length; i++)
                {
                    write.Write(bubbleSortArray[i] + " ");
                }
                Console.WriteLine("Сортировка пузырьком(массив, отсортированный в порядке убывания)\nВремя работы:{0}\nКоличество сравнений:{1}\nКоличество перестановок:{2}", interval, comparisons, swaps);
                write.WriteLine();
            }
            Console.WriteLine();
            using (StreamWriter write = new StreamWriter(path, true))
            {
                int[] bubbleSortArray = new int[mas.Length];
                for (int i = 0, j = bubbleSortArray.Length - 1; i < bubbleSortArray.Length; i++, j--)
                {
                    bubbleSortArray[i] = array[j];
                }
                BubbleSort(bubbleSortArray, 0, mas.Length - 1, out TimeSpan interval, out long comparisons, out long swaps);
                for (int i = 0; i < mas.Length; i++)
                {
                    write.Write(bubbleSortArray[i] + " ");
                }
                Console.WriteLine("Сортировка пузырьком(массив, отсортированный в порядке возрастания)\n Время работы:{0}\nКоличество сравнений:{1}\nКоличество перестановок:{2}", interval, comparisons, swaps);
                write.WriteLine();
            }
            Console.WriteLine();
            using (StreamWriter write = new StreamWriter(path, true))
            {
                int[] shakerSortArray = new int[mas.Length];
                for (int i = 0, k = mas.Length - 1; i < mas.Length && k > 0; i++, k--)
                {
                    shakerSortArray[i] = mas[k];
                }
                ShakerSort(shakerSortArray, 0, mas.Length - 1, out TimeSpan interval, out long comparisons, out long swaps);
                for (int i = 0; i < mas.Length; i++)
                {
                    write.Write(shakerSortArray[i] + " ");
                }
                Console.WriteLine("Сортировка шейкерная(массив заполнен случайными числами)\nВремя работы:{0}\nКоличество сравнений:{1}\nКоличество перестановок:{2}", interval, comparisons, swaps);
                write.WriteLine();
                array = shakerSortArray;
            }
            Console.WriteLine();
            using (StreamWriter write = new StreamWriter(path, true))
            {
                int[] shakerSortArray = array;
                ShakerSort(shakerSortArray, 0, mas.Length - 1, out TimeSpan interval, out long comparisons, out long swaps);
                for (int i = 0; i < mas.Length; i++)
                {
                    write.Write(shakerSortArray[i] + " ");
                }
                Console.WriteLine("Сортировка шейкерная(массив, отсортированный в порядке убывания)\nВремя работы:{0}\nКоличество сравнений:{1}\nКоличество перестановок:{2}", interval, comparisons, swaps);
                write.WriteLine();
            }
            Console.WriteLine();
            using (StreamWriter write = new StreamWriter(path, true))
            {
                int[] shakerSortArray = new int[mas.Length];
                for (int i = 0, j = shakerSortArray.Length - 1; i < shakerSortArray.Length; i++, j--)
                {
                    shakerSortArray[i] = array[j];
                }
                ShakerSort(shakerSortArray, 0, mas.Length - 1, out TimeSpan interval, out long comparisons, out long swaps);
                for (int i = 0; i < mas.Length; i++)
                {
                    write.Write(shakerSortArray[i] + " ");
                }
                Console.WriteLine("Сортировка шейкерная(массив, отсортированный в порядке возрастания)\n Время работы:{0}\nКоличество сравнений:{1}\nКоличество перестановок:{2}", interval, comparisons, swaps);
                write.WriteLine();
            }
            Console.WriteLine();
            using (StreamWriter write = new StreamWriter(path, true))
            {
                int[] SortArray = new int[mas.Length];
                for (int i = 0, k = mas.Length - 1; i < mas.Length && k > 0; i++, k--)
                {
                    SortArray[i] = mas[k];
                }
                Sort(SortArray, 0, mas.Length - 1, out TimeSpan interval, out int comparisons, out int swaps);
                for (int i = 0; i < mas.Length; i++)
                {
                    write.Write(SortArray[i] + " ");
                }
                Console.WriteLine("Сортировка Шелла(массив заполнен случайными числами)\nВремя работы:{0}\nКоличество сравнений:{1}\nКоличество перестановок:{2}", interval, comparisons, swaps);
                write.WriteLine();
                array = SortArray;
            }
            Console.WriteLine();
            using (StreamWriter write = new StreamWriter(path, true))
            {
                int[] SortArray = array;
                Sort(SortArray, 0, mas.Length - 1, out TimeSpan interval, out int comparisons, out int swaps);
                for (int i = 0; i < mas.Length; i++)
                {
                    write.Write(SortArray[i] + " ");
                }
                Console.WriteLine("Сортировка Шелла(массив, отсортированный в порядке убывания)\nВремя работы:{0}\nКоличество сравнений:{1}\nКоличество перестановок:{2}", interval, comparisons, swaps);
                write.WriteLine();
            }
            Console.WriteLine();
            using (StreamWriter write = new StreamWriter(path, true))
            {
                int[] SortArray = new int[mas.Length];
                for (int i = 0, j = SortArray.Length - 1; i < SortArray.Length; i++, j--)
                {
                    SortArray[i] = array[j];
                }
                Sort(SortArray, 0, mas.Length - 1, out TimeSpan interval, out int comparisons, out int swaps);
                for (int i = 0; i < mas.Length; i++)
                {
                    write.Write(SortArray[i] + " ");
                }
                Console.WriteLine("Сортировка Шелла(массив, отсортированный в порядке возрастания)\n Время работы:{0}\nКоличество сравнений:{1}\nКоличество перестановок:{2}", interval, comparisons, swaps);
                write.WriteLine();
            }
            Console.WriteLine();
            bool check = false;
            StreamReader readFromFile = new StreamReader(File.Open(path, FileMode.Open));           
            int[] arrayOfNumbers = new int[mas.Length];
            string line = "";
            while (readFromFile.Peek() > -1)
            {
                line = readFromFile.ReadLine();
                string [] arrayOfString = line.Split(' ');
                for (int i = 0; i<arrayOfNumbers.Length;i++)
                {            
                    arrayOfNumbers[i] = int.Parse(arrayOfString[i]);  
                }
                for (int i = 0; i < arrayOfNumbers.Length-1; i++)
                {
                    if (arrayOfNumbers[i] < arrayOfNumbers[i + 1])
                    {
                        check = true;
                        break;
                    }
                }
            }
            readFromFile.Close();
            if (check)
                Console.WriteLine("Иассив не отсортирован");
            else
                Console.WriteLine("Массив отсортирован");
        }
    }
}
 