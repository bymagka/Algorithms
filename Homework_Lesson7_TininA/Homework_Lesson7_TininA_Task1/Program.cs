using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//подключение пространства имен с графами (задание 4)
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


            Console.Write("\n");

            //задание 2 (обход в глубину)
            Console.WriteLine(gr.PrintDFS());

            Console.ReadLine();
        }
    }
}
