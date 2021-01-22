using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Tinin A
//1. Реализовать простейшую хеш-функцию. На вход функции подается строка, на выходе сумма кодов символов.

/*
 * 
 * 2. Переписать программу, реализующую двоичное дерево поиска.
    а) Добавить в него обход дерева различными способами;
    б) Реализовать поиск в двоичном дереве поиска;
 * 
 * 
 * 
 * 3. *Разработать базу данных студентов из полей «Имя», «Возраст», «Табельный номер», в которой использовать все знания,      полученные на уроках.
       Считайте данные в двоичное дерево поиска. Реализуйте поиск по какому-нибудь полю базы данных (возраст).
 * 
 * 
 */
namespace Homework_Lesson6_TininA_Task12
{
    class Program
    {
        static void Main(string[] args)
        {

            //1. Реализовать простейшую хеш-функцию. На вход функции подается строка, на выходе сумма кодов символов.
            Console.WriteLine(HashFunction(Console.ReadLine()));

            /*
             *  * 2. Переписать программу, реализующую двоичное дерево поиска.
                    а) Добавить в него обход дерева различными способами;
                    б) Реализовать поиск в двоичном дереве поиска;
            *
            ** 3. *Разработать базу данных студентов из полей «Имя», «Возраст», «Табельный номер», в которой использовать все знания,                       полученные на уроках.
                      Считайте данные в двоичное дерево поиска. Реализуйте поиск по какому-нибудь полю базы данных (возраст).
            *
             */
            WorkWithTrees();

            Console.ReadLine();
        }

        //хеш функция
        private static string HashFunction(string inputLine)
        {

            int hashValue = 0;

            foreach (char symbol in inputLine)
            {
                hashValue += (int)symbol;
            }

            return hashValue.ToString();
        }


        //работа с деревьями
        private static void WorkWithTrees()
        {

            //создадим базу с работниками
            Employee[] employees = new[]
            {
                new Employee("Petya",18, "1"),
                new Employee("Sasha",20,"2"),
                new Employee("Misha",30, "3"),
                new Employee("Ivan",45,"4"),
                new Employee("Katya",19, "5"),
                new Employee("Polina",17,"6")
            };
            
            //корневой элемент
            Tree root = new Tree(employees[0], null);

            Random rnd = new Random();

            for(int i = 1; i < employees.Length; i++)
            {
                root.Add(employees[i]);

            }
            root.Print();

            //б) Реализовать поиск в двоичном дереве поиска;
            int searchingValue = int.Parse(Console.ReadLine());

            Tree result = Tree.BinarySearch(root, searchingValue);

            result?.Print();

            // а) Добавить в него обход дерева различными способами;
            root.ReadInDifFormats();
        }
    }


    //класс для узла дерева
    class Tree
    {
        Employee value;
        public Tree parent;
        public Tree left;
        public Tree right;

        public Tree(Employee value,Tree parent)
        {
            this.parent = parent;
            this.value = value;
        }

        //Добавление элементов. Меньшие - налево, большие направо
        public void Add(Employee value)
        {
            if (value.CompareTo(this.value) == -1)
            {
                if (left != null) left.Add(value);
                else left = new Tree(value, this);
              
            }
            else
            {
                if (right != null) right.Add(value);
                else right = new Tree(value, this);
            }
        }

        //скобочная печать дерева
        public void Print()
        {
            Console.Write(value);
            if (left != null || right != null)
            {
                Console.Write("(");
                if (left != null)
                    left.Print();
                else
                    Console.Write("NULL");
                Console.Write(",");
                if (right != null)
                    right.Print();
                else
                    Console.Write("NULL");

                Console.Write(")");
            }
        }
       
        //Механизм поиска по дереву
        public static Tree BinarySearch(Tree searchingTree, int val)
        {
            if (searchingTree == null) return null;

            switch (val.CompareTo(searchingTree.value.Age))
            {
                case 0: return searchingTree;
                case 1: return BinarySearch(searchingTree.right, val);
                case -1: return BinarySearch(searchingTree.left, val);
                default: return null;
            }
        }

        //обход дерева различными способами
        public void ReadInDifFormats()
        {
            //Прямой обход
            Console.WriteLine();
            PreorderRead(this);

            //Симметричный обход
            Console.WriteLine();
            InRead(this);

            //Обратный обход
            Console.WriteLine();
            PostRead(this);
        }
            
        //Прямой обход
        public static void PreorderRead(Tree node)
        {         
            if (node != null)
            {
                Console.Write($" {node.value} ");
                PreorderRead(node.left);
                PreorderRead(node.right);
            }
            else Console.Write(" NULL ");
        }

        //Симметричный обход
        public static void InRead(Tree node)
        {
            if (node != null)
            {
                InRead(node.left);
                Console.Write($" {node.value} ");  
                InRead(node.right);
            }
            else Console.Write(" NULL ");
        }

        //Обратный обход
        public static void PostRead(Tree node)
        {
            if (node != null)
            {
                PostRead(node.left);
                PostRead(node.right);
                Console.Write($" {node.value} ");
            }
            else Console.Write(" NULL ");
        }
    }

    //структура для хранения данных о работниках (задача 3)
    class Employee : IComparable
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Number { get; set; }


        public Employee(string name, int age, string number)
        {
            Name = name;
            Age = age;
            Number = number;
        }

        //Для сравнения
        public int CompareTo(object obj)
        {
            Employee tmp = obj as Employee;
            if (tmp != null)
            {
                if (this.Age > tmp.Age) return 1;
                else if (this.Age < tmp.Age) return -1;
                else return 0;
            }
            else return 0;
        }

        public override string ToString()
        {
            return $"Age = {Age}, Name = {Name}, Number = {Number}";
        }
    }
}
