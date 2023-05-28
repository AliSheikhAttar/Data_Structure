using System;

namespace ConsoloeApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] s = Console.ReadLine().Split(' ');

            int n = int.Parse(s[0]);
            int m = int.Parse(s[1]);

            Graph graph = new Graph(n); 

            for (int i = 0; i < m; i++)
            {
                s = Console.ReadLine().Split(' ');

                graph.AddEdge(int.Parse(s[0]),int.Parse(s[1]),int.Parse(s[2]));
            }

            Console.WriteLine(Math.Round(graph.LongestPath(), 3).ToString("N3"));
        }


    }

    class Graph
    {
        int[,] edges;

        int n;

        public Graph(int n)
        {
            this.n = n;

            edges = new int[n, n];
        }

        public void AddEdge(int n1, int n2,int w)
        {
            edges[n2, n1] = w;
            edges[n1, n2] = w;
        }

        public double LongestPath()
        {
            double[] d = new double[n];

            bool[] visited = new bool[n];

            for (int i = 1; i < n; i++)
            {
                d[i] = double.MinValue;
                visited[i] = false;
            }

            d[0] = 1.0;

            for (int count = 0; count < n - 1; count++)
            {
                int u = MaxDistance(d, visited);

                if (u == -1)
                    return 0;

                visited[u] = true;

                for (int v = 0; v < n; v++)

                    if (!visited[v] && edges[u, v] != 0
                        && d[u] != int.MinValue
                        && d[u] * edges[u, v]/100.0 > d[v])
                        d[v] = d[u] * edges[u, v] / 100.0;
            }

            if (d[n - 1] == double.MinValue)
                return 0;

            return d[n - 1];
        }

        int MaxDistance(double[] d, bool[] visited)
        {
            double max = double.MinValue;
            int max_index = -1;

            for (int v = 0; v < n; v++)
                if (!visited[v] && d[v] >= max)
                {
                    max = d[v];
                    max_index = v;
                }

            return max_index;
        }
    }
}