using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * Tinin A
 * 
 * 1. *Количество маршрутов с препятствиями. Реализовать чтение массива с препятствием и нахождение количество маршрутов.
Например, карта:

1 1 1
0 1 0
0 1 0
 * 
 * 
 * 2. Решить задачу о нахождении длины максимальной последовательности с помощью матрицы.

 */
namespace Homework_Lesson4_TininA
{
    class Program
    {
        static void Main(string[] args)
        {

            //1. Количество маршрутов с препятствиями. Реализовать чтение массива с препятствием и нахождение количество маршрутов.
            int[][] Map = new int[][]
            {
                new int[] {1,1,1},
                new int[] {0,1,0},
                new int[] {0,1,0}
            };

            //В переменной max количество маршрутов
            CountWays(Map,out int max);
            Console.WriteLine(max);

            //2.Решить задачу о нахождении длины максимальной последовательности с помощью матрицы.
            Console.WriteLine(MaxSequenceLength("1528974", "1529803764")); // 1, 5, 2, 8, 9, 7, 4


           Console.ReadLine();
        }

     
        //Количество маршрутов с препятствиями. Реализовать чтение массива с препятствием и нахождение количество маршрутов.
        private static void CountWays(int[][] map,out int max)
        {
            //в переменной max предлагается хранить максимальное количество маршрутов
            max = 0;

            for (int i = 1; i <= map.GetUpperBound(0); i++)
            {
                for (int j = 1; j <= map[i].GetUpperBound(0); j++)
                {
                    if (map[i][j] == 0) continue;    

                    map[i][j] = map[i][j - 1] + map[i - 1][j];
                    max = map[i][j] > max ? map[i][j] : max;
                 
                }
            }
        }

        //2.Решить задачу о нахождении длины максимальной последовательности с помощью матрицы.
        private static int MaxSequenceLength(string FirstSequence, string SecondSequence)
        {
            //Создаю матрицу. в первой колонке и первой строке будут расположены переданные последовательности, за исключением ячейки [0][0] (чтобы не пересекались последовательности)

            //Инициализация матрицы
            string[][] SequenceMatrix = new string[FirstSequence.Length + 2][];

            for(int i = 0; i <= FirstSequence.Length+1; i++)
            {
                SequenceMatrix[i] = new string[SecondSequence.Length + 2];
            }

            //Расположим последовательности в первой строке и первой колонке
            for (int i = 2; i <= FirstSequence.Length+1; i++) SequenceMatrix[i][0] = FirstSequence[i - 2].ToString();
            
            for (int j = 2; j <= SecondSequence.Length+1; j++) SequenceMatrix[0][j] = SecondSequence[j - 2].ToString();

            //заполним матрицу нулями
            for (int i = 1; i <= FirstSequence.Length + 1; i++)
            { 
                for (int j = 1; j <= SecondSequence.Length + 1; j++) SequenceMatrix[i][j] = "0"; 
            }
  
            //механизм подсчета начиная со второй значимой колонки и второй значимой строки
            for (int i = 2; i <= SequenceMatrix.GetUpperBound(0); i++)
            {
                for (int j = 2; j <= SequenceMatrix[i].GetUpperBound(0); j++)
                {
                    //если совпадение найдено, берем последние рассчитаное количество совпадений и прибавляем 1
                    if (SequenceMatrix[i][0] == SequenceMatrix[0][j])
                    {
                        SequenceMatrix[i][j] = (int.Parse(SequenceMatrix[i - 1][j - 1]) + 1).ToString();
                      
                    }
                    //если совпадение НЕ найдено, берем максимальное рассчитаное количество совпадений на текущий момент
                    else SequenceMatrix[i][j] = Max(SequenceMatrix[i - 1][j], SequenceMatrix[i][j - 1]);
                }
            }

        
            //Максимальная длина последовательности должна находиться в последней ячейке. 
            int i_max = SequenceMatrix.GetUpperBound(0);
            int j_max = SequenceMatrix[i_max].GetUpperBound(0);


            return int.Parse(SequenceMatrix[i_max][j_max]);

        }

        private static string Max(string v1, string v2)
        {
            return int.Parse(v1) > int.Parse(v2) ? v1 : v2;
        }
    }
}
