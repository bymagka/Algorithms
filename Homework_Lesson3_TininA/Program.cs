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
 * 
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
            OptimizedBubbleSort(ref a, out iterator);

            foreach (var item in a)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\n" + iterator);

            Console.ReadLine();
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
    }
}
