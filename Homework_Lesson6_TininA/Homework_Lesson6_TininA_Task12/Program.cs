using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Tinin A
//1. Реализовать простейшую хеш-функцию. На вход функции подается строка, на выходе сумма кодов символов.
namespace Homework_Lesson6_TininA_Task12
{
    class Program
    {
        static void Main(string[] args)
        {

            //1. Реализовать простейшую хеш-функцию. На вход функции подается строка, на выходе сумма кодов символов.
            Console.WriteLine(HashFunction(Console.ReadLine()));

            Console.ReadLine();
        }

        private static string HashFunction(string inputLine)
        {

            int hashValue = 0;

            foreach(char symbol in inputLine)
            {
                hashValue += (int)symbol;             
            }              

            return hashValue.ToString();
        }
    }
}
