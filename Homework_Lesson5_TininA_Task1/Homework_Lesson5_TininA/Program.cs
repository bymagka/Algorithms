using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//TininA
//1.Реализовать перевод из десятичной в двоичную систему счисления с использованием стека.

namespace Homework_Lesson5_TininA
{
    class Program
    {
        static void Main(string[] args)
        {

            //вводим десятичное число
            int decimalNumber = int.Parse(Console.ReadLine());

            //стек для сохранения остатков от деления на 2
            Stack<int> digitsStack = new Stack<int>();

            //пока частное от деления больше двух добавляем в стек остаток от деления
            while (decimalNumber >= 2)
            {
                digitsStack.Push(decimalNumber % 2);
                decimalNumber /= 2;
            }
            //добавим в стек первый разряд итогового двоичного числа
            digitsStack.Push(decimalNumber);

            //получу элементы стека с помощью LINQ - практика)
            var finalNumber = from digit in digitsStack select digit;

            foreach (var number in finalNumber) Console.Write(number);

            Console.WriteLine();

            //получу элементы стека с помощью расширяющих методов LINQ - практика)
            var finalNumberWithLINQExtending = digitsStack.Select(number => number);

            foreach(var number in finalNumber) Console.Write(number);


            Console.ReadLine();
        }
    }
}
