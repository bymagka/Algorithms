using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*Tinin A
 * 
 * 5. **Реализовать алгоритм перевода из инфиксной записи арифметического выражения в постфиксную.
 * 
 */
namespace Homework_Lesson5_TininA_Task5
{
    class Program
    {
        static void Main(string[] args)
        {

            string InputLine = Console.ReadLine();

            Console.WriteLine(TurnToPostFix(InputLine));

            Console.ReadLine();
        }

        static string TurnToPostFix(string inputLine)
        {
            //создаем стек для операндов

            Stack<string> stackForOperators = new Stack<string>();

            string returnLine = String.Empty;
            string stackHead = String.Empty;

            foreach(char symbol in inputLine)
            {
                //число сразу добавляем к выходной строке
                if (char.IsDigit(symbol)) returnLine += symbol.ToString();
                //открывающую скобку отправляем в стек
                else if (symbol.Equals('(')) stackForOperators.Push(symbol.ToString());

                //если это какой то операнд, то мы выталкиваем в строку операнды в порядке приоритета до ближайшей открывающейся скобки. После добавляем в стек операнд
                else if (Priority(symbol) != 0)
                {
                    if (stackForOperators.Count > 0)
                    {
                        //смотрим на начало стека
                        stackHead = stackForOperators.Peek();


                        while (stackForOperators.Count > 0 && stackHead != "(")
                        {
                            //пока приоритет операции ниже приоритета операции в стеке - выталкиваем операнд в строку
                            if (Priority(symbol) <= Priority(char.Parse(stackHead))) returnLine += stackForOperators.Pop();
                            else break;
                        }

                    }
                    stackForOperators.Push(symbol.ToString());
                }
                //сюда должно попасть ветвление, когда символ в строке - ")". Выталкиваем тогда операции до "("
                else
                {
                    
                    //смотрим на начало стека
                    stackHead = stackForOperators.Peek();

                    while(!stackHead.Equals("("))
                    {
                        //пока не встретим в начале стека "(", выталкиваем операнды. саму скобку не выталкиваем
                        returnLine += stackForOperators.Pop();
                        stackHead = stackForOperators.Peek();

                        if (stackHead.Equals("(")) stackForOperators.Pop();
                    }      
                }
            }  

            //выталкиваем оставшиеся операнды
            while(stackForOperators.Count != 0)
            {
                returnLine += stackForOperators.Pop();
            }

            return returnLine;
        }

        //метод определяет приоритет операций, от которого зависит порядок вывода в строку
        static int Priority(char inputSymbol)
        {
            switch (inputSymbol)
            {
                case '*':
                    return 4;
                case '/':
                    return 3;
                case '%':
                    return 2;
                case '+':
                    return 1;
                case '-':
                    return 1;
                default:
                    return 0;                  
            };
        }
    }
}
