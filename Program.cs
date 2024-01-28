namespace AaDS_Lab_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            IList<IList<(int, int)>> adj = new List<IList<(int adjVertex, int Weight)>>();//Граф задан в списке смежности: (Смежная вершина, вес ребра)

            //Граф для поиска кратчайшего пути методом динамического программирования
            adj.Add(new List<(int, int)>());
            adj.Add(new List<(int, int)>() { (2, 1), (4,8), (5,25), (7, 20) });
            adj.Add(new List<(int, int)>() { (3, 2), (7, 15)});
            adj.Add(new List<(int, int)>() { (6, 3)});
            adj.Add(new List<(int, int)>() { (5, 9)});
            adj.Add(new List<(int, int)>() { (7, 6)});
            adj.Add(new List<(int, int)>() { (7, 4)});
            adj.Add(new List<(int, int)>());

            Console.WriteLine(ShortestPathDP.GetShortestPath(adj, 1, 7));

            //Граф для поиска кратчайших путей до каждой вершины с помощью Алгоритма Дейкстры
            adj = new List<IList<(int, int)>>();
            adj.Add(new List<(int, int)>());
            adj.Add(new List<(int, int)>() {(2,18),(4,4), (7, 9), (8,22) });
            adj.Add(new List<(int, int)>() { (1,18), (3, 1), (5, 3), (8, 1)});
            adj.Add(new List<(int, int)>() { (2, 1), (5, 13)});
            adj.Add(new List<(int, int)>() { (1, 4), (6,5), (7, 7)    });
            adj.Add(new List<(int, int)>() { (3, 13), (2, 3), (8,9), (7,2)});
            adj.Add(new List<(int, int)>() { (4, 5), (7, 5)});
            adj.Add(new List<(int, int)>() { (1,9),(4, 7), (6,5), (5,2), (8, 10)});
            adj.Add(new List<(int, int)>() { (1, 22), (2,1), (5, 9), (7, 10)});
            int[] answer = DijkstraAlgorithm.GetShortestPaths(adj, 1);
            foreach (var now in answer)
            {
                Console.Write(now + " ");
            }
        }
    }
}