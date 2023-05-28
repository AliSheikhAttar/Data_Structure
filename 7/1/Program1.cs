using System;
public class Program
{
    public static long[,] get_edges(long ncounts, long[,] nodes)
    {
        var edges = new long[ncounts, ncounts];
        for (int i = 0; i < ncounts; i++)
        {
            for (int j = 0; j < ncounts; j++)
                edges[i, j] = Math.Abs(nodes[j, 1] - nodes[i, 1]) + Math.Abs(nodes[j, 0] - nodes[i, 0]);
        }
        return edges;
    }

    public static long MinSpanningTree(int n, long[,] edges)
    {
        long result = 0;
        var visited = new short[n];
        int countvisited = 1;

        visited[0] = 1;

        while (countvisited++ != n)
        {
            long min = long.MaxValue;
            int toVisit = -1;

            for (int i = 0; i < n; i++)
            {
                if (visited[i] == 0)
                    continue;
                int j = 0;
                while(j++<n-1)
                {
                    if(visited[j] == 1)
                        continue;
                    else if(edges[i, j] < min)
                    {
                        min = edges[i, j];
                        toVisit = j;
                    }
                }
            }

            result += min;
            visited[toVisit] = 1;
        }
        return result;
    }
    public static void Main()
    {


        var ncounts = int.Parse(Console.ReadLine());

        var nodes = new long[ncounts, 2];

        for (int i = 0; i < ncounts; i++)
        {
            string[] node = Console.ReadLine().Split(' ');
            nodes[i, 0] = long.Parse(node[0]);
            nodes[i, 1] = long.Parse(node[1]);
        }

        var edges = get_edges(ncounts, nodes);

        Console.WriteLine(MinSpanningTree(ncounts, edges));

    }
}


