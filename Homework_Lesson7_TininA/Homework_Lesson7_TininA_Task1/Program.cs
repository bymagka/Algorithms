using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Graphs;

namespace Homework_Lesson7_TininA_Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            //создадим объект графа. Прочитаем файл и выведем его на экран (задание 1)
            Graph gr = new Graph(@"..\..\matrix.txt");
            gr.Print();


            Console.ReadLine();
        }
    }
}
