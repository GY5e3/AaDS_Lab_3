using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AaDS_Lab_3
{
    internal class DijkstraAlgorithm
    {
        public static int[] GetShortestPaths(IList<IList<(int adjVertex, int Weight)>> adj, int vertexStart)// На вход принимаем список смежности и вершину, для которой считаем кратчайшие расстояния
        {
            bool[] isVisited = new bool[adj.Count]; //Отмечаем вершины, которые уже обошли
            PriorityQueue<int, int> queue = new PriorityQueue<int, int>(); // Для выбора вершины, до которой расстояние в данный момент меньше всего 
            int[] shortestPaths = new int[adj.Count - 1]; // Кратчайшие расстояния от vertexStart до всех остальных вершин
            for (int i = 1; i < shortestPaths.Length; i++)
            {
                shortestPaths[i] = int.MaxValue;
            }
            shortestPaths[vertexStart - 1] = 0;
            queue.Enqueue(vertexStart, 0);
            while (queue.Count > 0) //Пока в очереди остались необойденные вершины, цикл будет продолжаться
            {
                int vertex = queue.Dequeue();
                isVisited[vertex] = true; //Отмечаем текущую вершину
                for (int i = 0; i < adj[vertex].Count; i++) //Считаем расстояние до смежных вершин
                {
                    if (isVisited[adj[vertex][i].adjVertex] == false) // Если вершина не отмечена, как посещенная определяем для нее кратчайшее расстояние
                    {
                        shortestPaths[adj[vertex][i].adjVertex - 1] = Math.Min(shortestPaths[adj[vertex][i].adjVertex - 1], 
                            shortestPaths[vertex - 1] + adj[vertex][i].Weight);  
                        queue.Enqueue(adj[vertex][i].adjVertex, shortestPaths[adj[vertex][i].adjVertex - 1]);
                    }                   
                }
            }
            return shortestPaths;
        }
    }
}
