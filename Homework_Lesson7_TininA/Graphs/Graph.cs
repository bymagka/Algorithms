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
        string way = String.Empty;

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

        //печать матрицы смежности
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

        //печатает путь обхода с вершины А
        public string PrintDFS()
        {
            way = String.Empty;
            //здесь храним актуальную вершину
            Stack<int> actualPosition = new Stack<int>();

            actualPosition.Push(3);

            //здесь храним те вершины, в которых мы уже были
            bool[] nodes = new bool[matrix.Length];
            nodes[3] = true;

            

            dfs(actualPosition, nodes);

            return way;
        }

        private void dfs(Stack<int> actualPosition,  bool[] nodes)
        {
            int node = actualPosition.Pop();

            for(int i = 0; i < matrix[node].Length; i++)
            {
                //если в этой вершине уже были, то сюда не надо
                if (nodes[i]) continue;

                if(matrix[node][i] != 0)
                {
                    //если есть номер, значит есть маршрут в эту вершину. передаем эту вершину в рекурсию и дописываем путь обхода.
                    actualPosition.Push(i);
                    nodes[i] = true;
                    way += matrix[node][i].ToString();
                    dfs(actualPosition, nodes);
                }
            }
            
        }
    }
}
