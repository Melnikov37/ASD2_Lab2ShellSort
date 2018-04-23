using System;
using System.Diagnostics;
using System.Threading;

namespace ASD2_Lab2
{
    class Program
    {
        private static QuickSort _quickSort = new QuickSort();

        public static QuickSort QuickSort { get => _quickSort; set => _quickSort = value; }
        public static ShellSort ShellSort { get => _shellSort; set => _shellSort = value; }

        private static ShellSort _shellSort = new ShellSort();

        static void Main(string[] args)
        {
            ShellSort.ReadDate();
            for (int i = 0; i < ShellSort.CountElement; i++)
            {
                Console.WriteLine("Числа - Array[{1}]{0}", ShellSort.Array[i],i);
            }           
            Console.ReadLine();
            Console.WriteLine("Сортировка:");
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            ShellSort.ShellSorting();
            stopwatch.Stop();
            for (int i = 0; i < ShellSort.CountElement; i++)
            {
                Console.WriteLine("Числа - Array[{1}]{0}", ShellSort.Array[ShellSort.ArrayId[i]], i);
            }
            Console.WriteLine("Количество итераций - {0}", ShellSort.iner);
            TimeSpan ts = stopwatch.Elapsed;
            Console.WriteLine("Время выполнения - {0:00}:{1:00}:{2:00}",ts.Minutes,ts.Seconds,ts.Milliseconds);
            Console.ReadLine();
        }
    }
}