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
            Console.WriteLine("Тест сортировки(или сортировка отдельного массива)?");
            if (Console.ReadLine() == "да")
            {
                Test();
            }
            else
            {
                Sort();
            }
        }

        static void Sort()
        {
            ShellSort.ReadDate("", 0);
            for (int i = 0; i < ShellSort.CountElement; i++)
            {
                Console.WriteLine("Числа - Array[{1}]{0}", ShellSort.Array[i], i);
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
            Console.WriteLine("Количество итераций - {0}", ShellSort.iter);
            ShellSort.iter = 0;
            TimeSpan ts = stopwatch.Elapsed;
            Console.WriteLine("Время выполнения - {0:00}:{1:00}:{2:00}", ts.Minutes, ts.Seconds, ts.Milliseconds);
            Console.ReadLine();
        }

        static void Test()
        {
            int start = 2;
            int end = 11;
            int step = 1;
            int count = (end - start) / step;
            ShellSort.TestShellSorting(start,end,step);
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine("Результат при {1} = {0}", ShellSort.TestIterNubmer[i], start);
                start+=step;
            }
            Console.ReadLine();
        }
    }
}