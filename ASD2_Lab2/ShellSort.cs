﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ASD2_Lab2
{
    public class ShellSort
    {
        private int[] _array = new int[1];
        private int[] _arrayId = new int[1];
        private int _countElement = 0;
        public int iner;

        public int[] Array { get => _array; set => _array = value; }
        public int CountElement { get => _countElement; set => _countElement = value; }
        public int[] ArrayId { get => _arrayId; set => _arrayId = value; }

        public void ReadDate()
        {
            Console.WriteLine("Введите числа которые будут сортироваться(напишите \"rnd\" для случайных чисел):");
            var value = Console.ReadLine();
            Console.WriteLine("Введите количество элементов");
            CountElement = Int32.Parse(Console.ReadLine());
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
                        Array[i] = rnd.Next(-10000, 10000);
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
                        iner++;
                    }
                    Array[ArrayId[j]] = tmp;
                }
            }
        }

    }
}
