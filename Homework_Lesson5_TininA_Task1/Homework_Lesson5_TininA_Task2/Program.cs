using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//TininA
//3. Написать программу, которая определяет, является ли введенная скобочная последовательность правильной. Примеры правильных скобочных выражений: (), ([])(), {}(), ([{}]), неправильных — )(, ())({), (, ])}), ([(]) для скобок [,(,{.

namespace Homework_Lesson5_TininA_Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            //логика такая: если символ является открытой скобкой, кладу символ в стек. Если символ не является открытой скобкой, пытаемся найти соответствующую открытую скобку для символа. Если открытая скобка для символа найдена и последний элемент в стеке является найденной открытой скобкой - проверка символа пройдена успешно. 

            //в этой переменной хранится флаг правильности расстановки скобок в строке
            bool rightPositionOfBraces = true;

            string inputLine = Console.ReadLine();

            Stack<char> bracesStack = new Stack<char>();
            
            //break в цикле нужен, чтобы не делать бессмысленных проверок, когда уже понятно что проверка не пройдена
            foreach(char symbol in inputLine)
            {
                if (IsOpenBrace(symbol)) bracesStack.Push(symbol);
                else if (CompareBraces(symbol) != ' ')
                {
                    //если проверяемый символ закрывающая скобка и стек пустой - проверка не пройдена
                    if (bracesStack.Count == 0)
                    {
                        rightPositionOfBraces = false;
                        break;
                    }

                    // если проверяемый символ закрывающая скобка и элемент в стеке не соответствует нужной открываемой скобке - проверка не пройдена
                    if (CompareBraces(symbol) != bracesStack.Pop())
                    {
                        rightPositionOfBraces = false;
                    }
                }
            }

            //может возникнуть ситуация, когда проверка строки пройдена удачно, но в стеке остались элементы. Это значит, что строка неправильная - слишком много открывающих скобок
            if (bracesStack.Count != 0) rightPositionOfBraces = false;

            Console.WriteLine(rightPositionOfBraces);
            
            Console.ReadLine();
        }


        //Метод, определяющий, является ли скобка открытой.
        static bool IsOpenBrace(char Brace)
        {
            switch (Brace)
            {
                case '{':
                    return true;
                case '[':
                    return true;
                case '(':
                    return true;
                default:
                    return false;
            }
        }

        //Метод, который возвращает открывающую скобку, соответствующую закрывающей скобке
        static char CompareBraces(char Brace)
        {
            switch (Brace)
            {
                case '}':
                    return '{';
                case ']':
                    return '[';
                case ')':
                    return '(';
                default:
                    return ' ';
            }

        }
    }


}
