using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Z2
{
    class Program
    {
        static void PrMasI(int[] mas, int N, string S)
        {
            Console.WriteLine(S);
            int i = 0;
            foreach (int wot in mas)
            {
                Console.WriteLine($"mas[{i}] = {wot}");
                i++;
            }
        }
        static void GenMasI(int[] mas, int N, int a, int b)
        {
            Random rnd = new Random();
            for (int i = 0; i < N; i++)
                mas[i] = rnd.Next(a, b);
        }
        static void Main(string[] args)
        {
            const int a = 5, b = 70;
            int N;
            Console.Write("Введiть к-сть елементiв масиву: "); 
            N = Convert.ToInt32(Console.ReadLine());
            int[] mas = new int[N];
            GenMasI(mas, N, a, b);
            PrMasI(mas, N, "Початковий масив");
            Console.ReadKey();
        }
    }
}
