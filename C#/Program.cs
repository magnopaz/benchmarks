using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Cs
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = 10000000;
            List<Int32> lista = new List<Int32>();
            for (int i = 0; i < N; i++)
            {
                lista.Add(i);
            }
            var start = Stopwatch.StartNew();
            for (int i = 0; i < N; i++)
            {
                isPrime(i);
            }
            start.Stop();
            Console.WriteLine($"Levou: {start.ElapsedMilliseconds}{Environment.NewLine}Metodo: for{Environment.NewLine}");
            start = Stopwatch.StartNew();
            lista.ForEach(n => isPrime(n));
            start.Stop();
            Console.WriteLine($"Levou: {start.ElapsedMilliseconds}{Environment.NewLine}Metodo: foreach{Environment.NewLine}");
            start = Stopwatch.StartNew();
            Parallel.ForEach(lista, n => isPrime(n));
            start.Stop();
            Console.WriteLine($"Levou: {start.ElapsedMilliseconds}{Environment.NewLine}Metodo: parallel foreach{Environment.NewLine}");
        }

        public static bool isPrime(int num)
        {
            if (num == 2) return true;
            if (num <= 1 || num % 2 == 0) return false;
            double sqrt_num = Math.Sqrt(num);
            for (int div = 3; div <= sqrt_num; div += 2)
            {
                if (num % div == 0) return false;
            }
            return true;
        }
    }
}