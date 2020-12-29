using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Тинин А
 * 
 * 1. Попробовать оптимизировать пузырьковую сортировку. Сравнить количество операций сравнения
    оптимизированной и не оптимизированной программы. Написать функции сортировки, которые
    возвращают количество операций.

 * 
 * 2. *Реализовать шейкерную сортировку
 * 
 * 3. Реализовать бинарный алгоритм поиска в виде функции, которой передается отсортированный
    массив. Функция возвращает индекс найденного элемента или -1, если элемент не найден.
 */
namespace Homework_Lesson3_TininA
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] a = new int[] { 8,3,5,7,8,12, 7, 4, 3, 8,14 };

            
            //обычная сортировка с выводом количества любых операций
            UsualBubbleSort(ref a, out int iterator);

            foreach(var item in a)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\n" + iterator);
            Console.WriteLine("\n");
            //оптимизированная сортировка с выводом количества любых операций
            int[] b = new int[] { 8, 3, 5, 7, 8, 12, 7, 4, 3, 8, 14 };
            OptimizedBubbleSort(ref b, out iterator);

            foreach (var item in a)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\n" + iterator);
            Console.WriteLine("\n");

            //Шейкерная сортировка
            int[] c = new int[] { 8, 3, 5, 7, 8, 12, 7, 4, 3, 8, 14 };
            ShakeSort(ref c, out iterator);

            foreach (var item in a)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\n" + iterator);

            Console.WriteLine("\n");

            //Реализовать бинарный алгоритм поиска в виде функции, которой передается отсортированный массив.
            Console.WriteLine(SearchAlgorithm(c, int.Parse(Console.ReadLine())));

            Console.ReadLine();
        }

        //Реализовать бинарный алгоритм поиска в виде функции, которой передается отсортированный массив.
        private static int SearchAlgorithm(int[] c, int value)
        {

            int leftBound = c.GetLowerBound(0);
            int rightBound = c.Length;
            int middleIndex = 0;

            while (leftBound != rightBound)
            {
                middleIndex = (leftBound + rightBound) / 2;

                if (c[middleIndex] == value) return middleIndex;
                else if (c[middleIndex] > value) rightBound = middleIndex-1;
                else leftBound = middleIndex+1;

            }
 

            return -1;
        }

        //обычная сортировка с выводом количества любых операций
        private static void UsualBubbleSort(ref int[] a,out int iterator)
        {
            iterator = 0;
            for(int i = 0; i < a.Length; i++)
            {
                iterator++;
                for(int j = 0; j < a.Length - 1; j++)
                {
                    iterator++;

                    if(a[j] > a[j+1])
                    {
                        iterator++;

                        int temp = a[j];
                        a[j] = a[j + 1];
                        a[j + 1] = temp;
                    }
                }
            }
        }


        //оптимизированная сортировка с выводом количества любых операций
        private static void OptimizedBubbleSort(ref int[] a, out int iterator)
        {

            //Суть оптимизации: если никаких свапов больше не обнаружено, то смысла проверять дальше нет
            iterator = 0;

            bool Flag = false;

            for (int i = 0; i < a.Length; i++)
            {
                Flag = false;
                iterator++;
                for (int j = 0; j < a.Length - 1; j++)
                {
                    iterator++;

                    if (a[j] > a[j + 1])
                    {
                        iterator++;

                        int temp = a[j];
                        a[j] = a[j + 1];
                        a[j + 1] = temp;

                        Flag = true;
                    }
                }

                //Оптимизация: если обменов элементов не обнаружено - прерываем сортировку
                if (!Flag) break;
            }
        }

        //шейкерная сортировка
        private static void ShakeSort(ref int[] a, out int iterator)
        {
            iterator = 0;

            int leftBound = 1;
            int rightBound = a.GetUpperBound(0);

            while(leftBound <= rightBound)
            {
                for(int i = rightBound; i >= leftBound; i--)
                {
                    iterator++;

                    if(a[i-1] > a[i])
                    {
                        iterator++;

                        int temp = a[i];
                        a[i] = a[i - 1];
                        a[i - 1] = temp;
                        
                    }
                }
                leftBound++;

                for (int i = leftBound; i <= rightBound; i++)
                {
                    iterator++;

                    if (a[i - 1] > a[i])
                    {
                        iterator++;

                        int temp = a[i];
                        a[i] = a[i - 1];
                        a[i - 1] = temp;
                     
                    }
                }
                rightBound--;
            }
        }


    }
}
