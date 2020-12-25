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

/*
    * 3. Исполнитель Калькулятор преобразует целое число, записанное на экране. У исполнителя две команды, каждой команде присвоен номер:
Прибавь 1
Умножь на 2
Первая команда увеличивает число на экране на 1, вторая увеличивает это число в 2 раза. Сколько существует программ, которые число 3 преобразуют в число 20?
а) с использованием массива;
б) с использованием рекурсии.
 * 
 */
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

            //Калькулятор
            Calculate();


            Console.ReadLine();
        }

        //Калькулятор
        private static void Calculate()
        {
            //а) с использованием массива;
            CalculateWithArray();

            //б) с использованием рекурсии.
            int start = int.Parse(Console.ReadLine());

            int final = int.Parse(Console.ReadLine());

            int p = 1;

            int n = 2;

            Console.WriteLine(CalculateWithRec(p,n,start,final));



        }

        //Калькулятор
        //б) с использованием рекурсии.
        private static int CalculateWithRec(int p,int n,int start,int final)
        {
            if (final < start) return 0;
            if (final == start) return 1;

            if (final % 2 == 0) return CalculateWithRec(p, n, start, final / n) + CalculateWithRec(p, n, start, final - p);
            else return CalculateWithRec(p, n, start, final - p);
        }

        //Калькулятор
        //а) с использованием массива;
        private static void CalculateWithArray()
        {
            int start = int.Parse(Console.ReadLine());

            int final = int.Parse(Console.ReadLine());

            int p = 1;

            int n = 2;

            int[] intArray = new int[final + 1];

            intArray[start] = 1;

            for (int i = start + 1; i <= final; i++)
            {
                if (i % 2 == 0) intArray[i] = intArray[i / n] + intArray[i - p];
                else intArray[i] = intArray[i - p];

                Console.Write("\t" + intArray[i]);
            }

            Console.WriteLine("\n" + intArray[final]);
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

            //рекурсивно, используя свойство четности степени.;
            Console.WriteLine(MyPowWithRecOddPow(a, b, 0, 1));
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

        //2. Реализовать функцию возведения числа a в степень b
        //c. * рекурсивно, используя свойство четности степени.
        private static int MyPowWithRecOddPow(int a, int b, int iterator, int result)
        {
            if (iterator == b) return result;

            iterator++;

            //если число четное - перемножаем значения "половинных" значений степеней. Если нечетная степень - умножаем число на число в степени b-1
            if (b % 2 == 0)
            {
                int halfPow = MyPowWithRecOddPow(a, b / 2, 0, result);
                return halfPow * halfPow;
            }
            else
            {
                return MyPowWithRecOddPow(a, b - 1, iterator, result) * a;
                
            }

        }

    }
}
