using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace ASD2_Lab2
{
    public class ShellSort
    {
        private int[] _array;
        private int[] _arrayId;
        private int _countElement = 0;
        private int[] _testIterNubmer;
        public int iter;

        public int[] Array { get => _array; set => _array = value; }
        public int CountElement { get => _countElement; set => _countElement = value; }
        public int[] ArrayId { get => _arrayId; set => _arrayId = value; }
        public int[] TestIterNubmer { get => _testIterNubmer; set => _testIterNubmer = value; }

        public void ReadDate(string value, int countElement)
        {
            if (value == "")
            {
                Console.WriteLine("Введите числа которые будут сортироваться(напишите \"rnd\" для случайных чисел):");
                value = Console.ReadLine();
            }
            if (countElement == 0)
            {
                Console.WriteLine("Введите количество элементов");
                CountElement = Int32.Parse(Console.ReadLine());
            }
            else
            {
                CountElement = countElement;
            }
            
            _array = new int[CountElement];
            _arrayId = new int[CountElement];
            do
            {
                if (value == "stop") break;
                if (value == "rnd")
                {
                    Random rnd = new Random();
                    for (int i = 0; i < CountElement; i++)
                    {
                        Array[i] = rnd.Next(-1000000, 1000000);
                    }

                    break;
                }
                Console.WriteLine("Введите число (Для остановки ввода напишите \"stop\") - ");
                Array[CountElement] = Int32.Parse(value);
            } while (true);

            for (int i = 0; i < CountElement; i++)
            {
                ArrayId[i] = i;
            }

        }

        public void ShellSorting()
        {
            int i, j, step;
            int tmp;
            for (step = CountElement/2; step > 0; step/=2)
            {
                for (i = step; i < CountElement; i++)
                {
                    tmp = Array[ArrayId[i]];
                    for (j = i; j >= step; j -= step)
                    {
                        if (tmp < Array[ArrayId[j - step]])
                            Array[ArrayId[j]] = Array[ArrayId[j - step]];
                        else
                            break;
                        iter++;
                    }
                    Array[ArrayId[j]] = tmp;
                }
            }
        }

        public void TestShellSorting(int start, int end, int step)
        {
            var elementTestArray = (end - start) / step;
            _testIterNubmer = new int[elementTestArray];
            for (int i = 0; i < elementTestArray; i++)
            {
                ReadDate("rnd", start);
                ShellSorting();
                TestIterNubmer[i] = iter;
                iter = 0;
                start += step;
            }
        }
    }
}
