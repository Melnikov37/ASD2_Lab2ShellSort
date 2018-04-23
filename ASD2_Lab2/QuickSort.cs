using System;
using System.Collections.Generic;
using System.Text;

namespace ASD2_Lab2
{ 
    public class QuickSort
    {
        private int[] _array = new int[1];
        private int[] _arrayId = new int[1];
        private int _countElement = 0;
        public int iter = 0;

        public int[] Array { get => _array; set => _array = value; }
        public int CountElement { get => _countElement; set => _countElement = value; }
        public int[] ArrayId { get => _arrayId; set => _arrayId = value; }

        public void ReadDate()
        {
            Console.WriteLine("Введите числа которые будут сортироваться(напишите \"random\" для случайных чисел):");
            var value = Console.ReadLine();
            Console.WriteLine("Введите количество элементов");
            CountElement = Int32.Parse(Console.ReadLine());
            _array = new int[CountElement];
            _arrayId = new int[CountElement];
            do
            {    
                if (value == "stop") break;
                if (value == "random")
                {
                    Random rnd = new Random();
                    for (int i = 0; i < CountElement; i++)
                    {
                        Array[i] = rnd.Next(Int32.MinValue + 10, Int32.MaxValue - 10);
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
        public void QuickSorting(int star, int end)
        {
            iter++;
            if (star < end)
            {
                var splitPoint = Separation(star, end);
                QuickSorting(star, splitPoint - 1);
                QuickSorting(splitPoint + 1, end);
            }
        }
        public int SearchSplitPoint(int star, int end)
        {
            int max = Int32.MinValue;
            int min = Int32.MaxValue;
            for (int j = star; j < end; j++)
            {
                iter++;
                if (max < Array[ArrayId[j]]) max = Array[ArrayId[j]];
                if (min > Array[ArrayId[j]]) min = Array[ArrayId[j]];
            }
            var point = (min+max)/2;
            return point;
        }

        public int Separation(int star, int end)
        {
            var basicValue = SearchSplitPoint(star, end);
            var i = star;
            var j = end;
            while (i<=j)
            {
                iter++;
                while (Array[ArrayId[i]] < basicValue)
                {
                    iter++;
                    i++;
                }

                while (Array[ArrayId[j]] > basicValue)
                {
                    iter++;
                    j--;
                }

                if (i <= j)
                {
                    var idSwap = ArrayId[i];
                    ArrayId[i] = ArrayId[j];
                    ArrayId[j] = idSwap;
                    i++;
                    j--;
                }
            }

            return i;
        }
    }
}
