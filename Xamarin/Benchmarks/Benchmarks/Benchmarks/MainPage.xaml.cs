using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Benchmarks
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void runBenchmark_Clicked(object sender, EventArgs e)
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
            string resultFor = $"Time in milliseconds: {start.ElapsedMilliseconds}{Environment.NewLine}Method: for{Environment.NewLine}";
            start = Stopwatch.StartNew();
            lista.ForEach(n => isPrime(n));
            start.Stop();
            string resultForEach = $"Time in milliseconds: {start.ElapsedMilliseconds}{Environment.NewLine}Method: foreach{Environment.NewLine}";
            start = Stopwatch.StartNew();
            Parallel.ForEach(lista, n => isPrime(n));
            start.Stop();
            string resultParallelForEach = $"Time in milliseconds: {start.ElapsedMilliseconds}{Environment.NewLine}Method: parallel foreach{Environment.NewLine}";

            string totalTime = $"{Environment.NewLine}{resultFor}{Environment.NewLine}{resultForEach}{Environment.NewLine}{resultParallelForEach}";

            labelResults.Text += totalTime;
            runBenchmark.Text = "Done. Click to run again";
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
