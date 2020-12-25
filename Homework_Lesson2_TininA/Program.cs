using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//TininA

//1. Реализовать функцию перевода из десятичной системы в двоичную, используя рекурсию.

//2. Реализовать функцию возведения числа a в степень b:
//a.без рекурсии;
//b.рекурсивно;
//c. * рекурсивно, используя свойство четности степени.


namespace Homework_Lesson2_TininA
{
    class Program
    {
        static void Main(string[] args)
        {
            //1. Реализовать функцию перевода из десятичной системы в двоичную, используя рекурсию.
            NumberTranslate();

            //2. Реализовать функцию возведения числа a в степень b
            MyPow();


            Console.ReadLine();
        }


        //1. Реализовать функцию перевода из десятичной системы в двоичную, используя рекурсию.
        private static void NumberTranslate()
        {
            //число для перевода
            int n = int.Parse(Console.ReadLine());

            //основание сс, в которую осуществляется перевод
            int m = int.Parse(Console.ReadLine());

            List<int> newNumber = new List<int>();

            NumberTranslateRec(newNumber, ref n,  m);

            newNumber.Reverse();

            foreach(int number in newNumber)
            {
                Console.Write(number);
            }

            Console.Write("\n");

        }

        //1. Реализовать функцию перевода из десятичной системы в двоичную, используя рекурсию.
        private static void NumberTranslateRec(List<int> newNumber,ref int n,int m)
        {
            if (n < m)
            {
                newNumber.Add(n);
                return;
            }

            newNumber.Add(n % m);
            n /= m;
            NumberTranslateRec(newNumber, ref n, m);


        }


        //2. Реализовать функцию возведения числа a в степень b
        private static void MyPow()
        {
            int a = int.Parse(Console.ReadLine());

            int b = int.Parse(Console.ReadLine());

            //a.без рекурсии;
            Console.WriteLine(MyPowWithoutRec(a,b));

            //b.рекурсивно;
            Console.WriteLine(MyPowWithRec(a, b,0,1));
        }

        //2. Реализовать функцию возведения числа a в степень b
        //a.без рекурсии;
        private static int MyPowWithoutRec(int a, int b)
        {
            int result = 1;
            for(int n = 1; n <= b; n++)
            {
                result *= a;
            }

            return result;
        }

        //2. Реализовать функцию возведения числа a в степень b
        //b.рекурсивно;
        private static int MyPowWithRec(int a, int b,int iterator,int result)
        {
            if (iterator == b) return result;

            iterator++;
            return MyPowWithRec(a, b, iterator,result * a);
        }

    }
}
