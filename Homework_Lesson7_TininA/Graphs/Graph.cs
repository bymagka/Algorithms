using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
/*
 * Tinin A
 * 
 *  1. Написать функции, которые считывают матрицу смежности из файла и выводят ее на экран.
    2. Написать рекурсивную функцию обхода графа в глубину.
    3. Написать функцию обхода графа в ширину.
    4. *Создать библиотеку функций для работы с графами.
 * 
 * 
 * 
 */

namespace Graphs
{
    public class Graph
    {
        int[][] matrix;

        public Graph(string filename)
        {
            StreamReader matrixReader = new StreamReader(filename);

            int count = int.Parse(matrixReader.ReadLine());

            matrix = new int[count][];

            int currentPosition = 0;

            while (!matrixReader.EndOfStream)
            {
                
                matrix[currentPosition] = new int[count];

                string[] lineSymbols = matrixReader.ReadLine().Split(' ');

                for(int i = 0; i < count; i++)
                {
                    matrix[currentPosition][i] = int.Parse(lineSymbols[i]);
                }

                currentPosition++;
            }

            matrixReader.Close();

        }

        public void Print()
        {
            for(int i = 0; i < matrix.Length; i++)
            {
                Console.Write("\n");

                for(int j = 0; j < matrix.Length; j++)
                {
                    Console.Write($" {matrix[i][j]}");
                }
            }
        }
    }
}
