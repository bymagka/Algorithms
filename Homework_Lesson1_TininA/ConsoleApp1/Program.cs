using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//TininA

//12. Написать функцию нахождения максимального из трех чисел.
//13. * Написать функцию, генерирующую случайное число от 1 до 100.
//а) с использованием стандартной функции rand()
//б) без использования стандартной функции rand()

//14. *Автоморфные числа. Натуральное число называется автоморфным, если оно равно последним цифрам своего квадрата. Например, 252 = 625. Напишите программу, которая вводит натуральное число N и выводит на экран все автоморфные числа, не превосходящие N.
namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //12. Написать функцию нахождения максимального из трех чисел.
            FindMax();

            //13. * Написать функцию, генерирующую случайное число от 1 до 100.
            //а) с использованием стандартной функции rand()
            Random rnd = new Random();
            Console.WriteLine(rnd.Next(1, 100));

            //б) без использования стандартной функции rand()
            RndWithoutRandom();


            //14. *Автоморфные числа. Натуральное число называется автоморфным, если оно равно последним цифрам своего квадрата. Например, 252 = 625. Напишите программу, которая вводит натуральное число N и выводит на экран все автоморфные числа, не превосходящие N.
            Automorh();

            Console.ReadLine();
        }

        //14. *Автоморфные числа. Натуральное число называется автоморфным, если оно равно последним цифрам своего квадрата. Например, 252 = 625. Напишите программу, которая вводит натуральное число N и выводит на экран все автоморфные числа, не превосходящие N.
        private static void Automorh()
        {
            //Находим остаток от деления квадрата числа на число разрядов, "добавленных" к исходному числу во время возведения в квадрат
            int N = int.Parse(Console.ReadLine());

            int d = 10;

            for (int i = 0; i <= N; i++)
            {
                if((i*i) % d == i)
                {
                    Console.WriteLine($"{i*i} {i}");
                }

                if (i > d) d *= 10;
            }
        }

        //б) без использования стандартной функции rand()
        private static void RndWithoutRandom()
        {
            DateTime dt = DateTime.Now;

            int Seconds = dt.Second;
            int randomNumber = Seconds % 100;

            if (randomNumber == 0) randomNumber = 100;

            Console.WriteLine(randomNumber);
        }

        //12. Написать функцию нахождения максимального из трех чисел.
        private static void FindMax()
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());

            int max = a;

            if (b > max) max = b;
            if (c > max) max = c;

            Console.WriteLine($"{max}");
           
        }
    }
}
