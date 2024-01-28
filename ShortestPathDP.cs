namespace AaDS_Lab_3
{
    internal class ShortestPathDP
    {
        public static int GetShortestPath(IList<IList<(int adjVertex,int Weight)>> adj, int vertexStart, int vertexEnd)// На вход принимаем список смежности и вершины, между которыми необходимо найти кратчайшее расстояние
        {
            vertexMapping = new List<int>();
            Count = adj.Count; 
            int[] dp = new int[Count];
            for (int i = 1; i < Count; i++)
            {
                dp[i] = 100000; //В идеале массив dp надо заполнить Math.Inf, но мне было лень приводить к double и обратно
            }
            dp[vertexStart] = 0;
            TopologicalSort(adj);
            //Ищем в отосортированном списке вершин начальную вершину
            for (int i = 1; i < adj.Count; i++)
            {
                if (vertexMapping[i] == vertexStart)
                {
                    vertexStart = i;
                    break;
                }
            }
            //Пока в отсортированном списке не наткнемся на конечную вершину, выполняем алгоритм выбора кратчайшего пути
            for (int i = vertexStart; vertexMapping[i] != vertexEnd; i++)
            {
                for (int j = 0; j < adj[vertexMapping[i]].Count; j++)
                {
                    dp[adj[vertexMapping[i]][j].adjVertex] = Math.Min(dp[adj[vertexMapping[i]][j].adjVertex],
                        Math.Abs(dp[vertexMapping[i]] + adj[vertexMapping[i]][j].Weight));//Запишем в массив dp минимум из текущего значения в ячейке или суммы кратчайшего расстояния до вершины, выбранной в верхнем цикле, и ребра соединяющего эти две вершины
                }
            }
            return dp[Count - 1];
        }
        private static int Count;
        private static List<int> vertexMapping;//Отображение нового порядка обхода графа
        //Зададим правильный порядок обхода вершин с помощью топопологической сортировки - из вершины с меньшим номером следуют вершины с большим номером
        private static void TopologicalSort(IList<IList<(int adjVertex, int Weight)>> adjList)
        {
            bool[] visited = new bool[Count];
            for (int i = 1; i < Count; i++)
            {
                if (!visited[i])
                    DFS(i);
            }
            vertexMapping.Add(0);
            vertexMapping.Reverse();
            void DFS(int vertex) 
            {
                visited[vertex] = true;
                for (int i = 0; i < adjList[vertex].Count; i++)
                {
                    if (!visited[adjList[vertex][i].adjVertex])
                        DFS(adjList[vertex][i].adjVertex);
                }
                vertexMapping.Add(vertex);
            }
        }
    }
}
