using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Z1
{
    class Program
    {
        static void GenMasD(double[] mas, int N, int a, int b)
        {
            Random rnd = new Random();
            for (int i = 0; i < N; i++)
                mas[i] = a + rnd.NextDouble() * (b - a);
        }
        static void PrMasD(double[] mas, int N, string S)
        {
            Console.WriteLine(S);
            int i = 0;
            foreach(double wot in mas)
            {
                Console.WriteLine($"mas[{i}] = {wot}");
                i++;
            }
        }
        static double[] BubbleSort(double[] mas)
        {
            double temp;
            
            for (int i = 0; i < mas.Length; i++)
            {
                for (int j = i + 1; j < mas.Length; j++)
                {
                    if (mas[i] > mas[j])
                    {
                        temp = mas[i];
                        mas[i] = mas[j];
                        mas[j] = temp;
                    }
                }
            }
            return mas;
        }
        static double[] pramouON(double[] mas,int N)
        {

            for (int i = 1; i < N; i++)
            {
                int j = 0, k;
                double elem = mas[i];
                while (j < i && mas[j] <= mas[i])
                    j++;
                if (j < i)
                {
                    for (k = i - 1; k >= j; k--)
                        mas[k + 1] = mas[k];
                    mas[j] = elem;
                }
            }
            return mas;
        }
        static double[] pramouVib(double[] mas, int N)
        {

            for (int i = 0; i < N - 1; i++)
            {
                double min = mas[i];
                int IndexMin = i;
                for (int j = i + 1; j < N; j++)
                    if (mas[j] < min)
                    {
                        min = mas[j];
                        IndexMin = j;
                    }
                if (IndexMin > i)
                {
                    mas[IndexMin] = mas[i];
                    mas[i] = min;
                }
            }
            return mas;
        }
        static void Swap(ref double x, ref double y)
        {
            var t = x;
            x = y;
            y = t;
        }
        static int Partition(double[] array, int minIndex, int maxIndex)
        {
            int pivot = minIndex - 1;
            for (int i = minIndex; i < maxIndex; i++)
            {
                if (array[i] < array[maxIndex])
                {
                    pivot++;
                    Swap(ref array[pivot], ref array[i]);
                }
            }

            pivot++;
            Swap(ref array[pivot], ref array[maxIndex]);
            return pivot;
        }
        static double[] QuickSort(double[] array, int minIndex, int maxIndex)
        {
            if (minIndex >= maxIndex)
            {
                return array;
            }

            int pivotIndex = Partition(array, minIndex, maxIndex);
            QuickSort(array, minIndex, pivotIndex - 1);
            QuickSort(array, pivotIndex + 1, maxIndex);

            return array;
        }
        static double[] QuickSort(double[] array)
        {
            return QuickSort(array, 0, array.Length - 1);
        }
        static void Main(string[] args)
        {
           repeat:
            const int a = 5, b = 70;
            int N, k;
            bool method1 = false, method2 = false, method3 = false, method4 = false, method0 = false;
            Console.WriteLine("Завдання №1");
            Console.Write("Введiть к-сть елементiв масиву: ");
            N = Convert.ToInt32(Console.ReadLine());
            double[] mas = new double[N];
            GenMasD(mas, N, a, b);
            PrMasD(mas, N, "Початковий масив");
            Console.Write("Виберіть метод сортування\n0, 1, 2, 3, 4;\n 0 - методом бульбашок, 1 - методом прямого включення, 2 - метод прямого вибору, " +
                "3 - методом швидкого сортування обміном навеликих відстанях, 4 - стандартний метод Array.Sort():  ");
            k = Convert.ToInt32(Console.ReadLine());
            if (k == 0)
                method0 = true;
            else if (k == 1)
                method1 = true;
            else if (k == 2)
                method2 = true;
            else if (k == 3)
                method3 = true;
            else if (k == 4)
                method4 = true;
            while (method0)
            {
                DateTime start = DateTime.Now;
                BubbleSort(mas);
                DateTime finish = DateTime.Now;
                Console.WriteLine();
                PrMasD(mas, N, "Вiдсортований массив методом бульбашок");
                Console.WriteLine($"Час сортування методом бульбашок: {finish - start}");
                Console.ReadKey();
                method0 = false;
            }
            while (method1)
            {
                DateTime start = DateTime.Now;
                pramouON(mas, N);
                DateTime finish = DateTime.Now;
                PrMasD(mas, N, "\n Вiдсортований масив методом прямого включення");
                Console.WriteLine($"Час сортування методом прямого включення: {finish - start}");
                Console.ReadKey();
                method1 = false;
            }
            while (method2)
            {
                DateTime start = DateTime.Now;
                pramouVib(mas, N);
                DateTime finish = DateTime.Now;
                PrMasD(mas, N, "\n Вiдсортований масив методом прямого вибору");
                Console.WriteLine($"Час сортування методом прямого вибору: {finish - start}");
                Console.ReadKey();
                method2 = false;
            }
            while (method3)
            {
                DateTime start = DateTime.Now;
                QuickSort(mas);
                DateTime finish = DateTime.Now;
                PrMasD(mas, N, "\n Вiдсортований масив методом швидкого сортування обмiном на великих вiдстанях");
                Console.WriteLine($"Час сортування методом швидкого сортування обміном на великих вiдстанях: {finish - start}");
                Console.ReadKey();
                method3 = false;
            }
            while (method4)
            {
                DateTime start = DateTime.Now;
                Array.Sort(mas);
                DateTime finish = DateTime.Now;
                PrMasD(mas, N, "\n Вiдсортований масив методом прямого вибору");
                Console.WriteLine($"Час сортування методом Array.Sort() : {finish - start}");
                Console.ReadKey();
                method4 = false;
            }
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Бажаєте продовжити? 0 - так 1 - нi ");
            k = Convert.ToInt32(Console.ReadLine());
            if (k == 0)
                goto repeat;
        }
    }
}
