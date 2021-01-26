using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

/*
 * TininA
 * 
 * 1. Реализовать сортировку подсчетом.
   2. Реализовать быструю сортировку.
 * 
 */
namespace Homework_Lesson8_TininA
{
    class Program
    {
        static Stopwatch sw = new Stopwatch();

        static Random rnd = new Random();

        static void Main(string[] args)
        {
 
            int[] array100 = new int[100];
            int[] array1000 = new int[1000];
            int[] array100000 = new int[100000];

            InitiateArrays(ref array100, ref array1000, ref array100000);

            //2. Реализовать быструю сортировку.
            Console.WriteLine("**********Quick sort**********");
            //100 элементов
            sw.Start();
            quickSort(array100, 0, array100.Length - 1);
            sw.Stop();
            Console.WriteLine($"100: {sw.Elapsed}");
            sw.Reset();


            //1000 элементов
            sw.Start();
            quickSort(array1000, 0, array1000.Length - 1);
            sw.Stop();
            Console.WriteLine($"1000: {sw.Elapsed}");
            sw.Reset();

          

            //100000 элементов
            sw.Start();
            quickSort(array100000, 0, array100000.Length - 1);
            sw.Stop();
            Console.WriteLine($"100000: {sw.Elapsed}");
            sw.Reset();

            //*1.Реализовать сортировку подсчетом.
            InitiateArrays(ref array100, ref array1000, ref array100000);
            Console.WriteLine("**********Counting sort**********");
            //100 элементов
            sw.Start();
            CountingSort(array100, 100);
            sw.Stop();
            Console.WriteLine($"100: {sw.Elapsed}");
            sw.Reset();


            //1000 элементов
            sw.Start();
            CountingSort(array1000, 1000);
            sw.Stop();
            Console.WriteLine($"1000: {sw.Elapsed}");
            sw.Reset();



            //100000 элементов
            sw.Start();
            CountingSort(array100000, 100000);
            sw.Stop();
            Console.WriteLine($"100000: {sw.Elapsed}");
            sw.Reset();

            Console.ReadLine();
        }

        //Перезаполнение массивов
        private static void InitiateArrays(ref int[] array100, ref int[] array1000, ref int[] array100000)
        {
            for (int i = 0; i < array100.Length; i++)
            {
                array100[i] = rnd.Next(1, 100);
            }


            for (int i = 0; i < array1000.Length; i++)
            {
                array1000[i] = rnd.Next(1, 1000);
            }


            for (int i = 0; i < array100000.Length; i++)
            {
                array100000[i] = rnd.Next(1, 100000);
            }
        }

        //Быстрая сортировка
        static void quickSort(int[] array, int first, int last)
        {
            int i = first, j = last, x = array[(first + last) / 2];
            int tmp;
            do
            {
                while (array[i] < x)
                    i++;
                while (array[j] > x)
                    j--;
                if (i <= j)
                {
                    if (array[i] > array[j])
                    {
                        tmp = array[i];
                        array[i] = array[j];
                        array[j] = tmp;
                    }            
                    i++;
                    j--;
                }
            } while (i <= j);
            if (i < last)
                quickSort(array, i, last);
            if (first < j)
                quickSort(array, first, j);
        }

        //сортировка подсчетом
        static void CountingSort(int[] array, int k)
        {
            //частотный массив. Сохраняем количество повторений чисел
            int[] count = new int[k + 1];
            for (int i = 0; i < array.Length; i++)
            {
                count[array[i]]++;
            }

            //располагаем числа в массиве по порядку и с количеством повторений из частотного массива
            int index = 0;
            for (int i = 0; i < count.Length; i++)
            {
                for (int j = 0; j < count[i]; j++)
                {
                    array[index] = i;
                    index++;
                }
            }
        }

    }
}
