using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Tinin A
//6. *Реализовать очередь.
namespace Homework_Lesson5_TininA_Task6
{
    //делаю в одном файле, т.к. кажется что так легче проверять, чем когда будет создан отдельный файл класса под очередь
    class Program
    {
        static void Main(string[] args)
        {
            //разные всякие манипуляции с очередью и с типами для очереди. Проверка переполнения очереди, пик при пустой очереди и т.д.

            MyQueue<string> myQueueString = new MyQueue<string>();

            myQueueString.Enqueue("firstElement");

            for (int i =0; i < 101; i++)
            {
                myQueueString.Enqueue("other element"); 
            }

            Console.WriteLine(myQueueString.Peek());
            Console.WriteLine(myQueueString.Peek());

            //попробуем сделать очередь с инт и получить элемент с пустой очереди
            MyQueue<int> myQueueInt = new MyQueue<int>();
            myQueueInt.Enqueue(1);

            try
            {
                Console.WriteLine(myQueueInt.Peek());
                Console.WriteLine(myQueueInt.Peek());
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
           
            Console.ReadLine();
        }
    }

    //пускай очередь будет максимум 100 элементов. Сделал необобщенной - захотел попрактиковаться в этом.
    class MyQueue<T>
    {
        T[] queueArray;
        int tale;
        int head;

        public MyQueue()
        {
            queueArray = new T[100];
            tale = 0;
            head = 0;
        }

        //метод добавления элемента в очередь. Если уже добавлено максимальное количество элементов (100) - добавить не получится. Фразу из методички про "Если значение front становится больше n, то мы как бы циклически обходим массив, и значение переменной становится равным 0" вообще не понял, поэтому ограничил очередь по количеству элементов.  
        public void Enqueue(T member)
        {
            if (head == 100)
            {
                Console.WriteLine("Queue is over! New member cannot be added");
                return;
            }

            queueArray[head] = member;
            head++;
        }

        //метод получения элемента из очереди
        public T Peek()
        {
            if(tale == head) throw new InvalidOperationException("Queue is empty!");

            T returnableMember = queueArray[tale];
            tale++;

            return returnableMember;
        }

    }
}
