using System;

public class Program
{    
    public static int highestP(int V, double[] d, bool[] VisitedIslands)
    {

        var Best_index = -1;
        double Best = double.MinValue;

        int v = -1;
        while(v++<V-1)
        {
            if (d[v] >= Best && !VisitedIslands[v])
            {
                Best_index = v;
                Best = d[v];
            }
        }
        return Best_index;
    }

    public static double BestPath(int V, int[,] Edges)
    {
        int BestIsland;
        int v;
        var probabilities = new double[V];
        var VisitedIslands = new bool[V];
        probabilities[0] = 1.0;

        
        int i = 0;

        while(i++<V-1)
        {
            VisitedIslands[i] = false;
            probabilities[i] = double.MinValue;
        }

        int counter = 0;
        for (;counter < V - 1; counter++)
        {
            
            BestIsland = highestP(V, probabilities, VisitedIslands);

            VisitedIslands[BestIsland] = true;

            if (BestIsland == -1)
                return 0;

            for (v = 0; v < V; v++)
            {
                if ((Edges[BestIsland, v] != 0) &&( probabilities[v] < probabilities[BestIsland] * Edges[BestIsland, v] / 100.0 ) && (!VisitedIslands[v]) && (probabilities[BestIsland] != int.MinValue))
                    probabilities[v] =  probabilities[BestIsland] * Edges[BestIsland, v] / 100.0;
            }
        }

        if (probabilities[V - 1] == double.MinValue)
            return 0;

        return probabilities[V - 1];
    }


    public static void Main(string[] args)
    {
        string[] VnE = Console.ReadLine().Split(' ');

        var V = int.Parse(VnE[0]);
        var E = int.Parse(VnE[1]);

        var Edges = new int[V, V];

        string[] islandnvalue;
        int i=-1;

        while(i++<E-1)
        {
            islandnvalue = Console.ReadLine().Split(' ');
            Edges[int.Parse(islandnvalue[0]), int.Parse(islandnvalue[1])] = int.Parse(islandnvalue[2]);
            Edges[int.Parse(islandnvalue[1]), int.Parse(islandnvalue[0])] = int.Parse(islandnvalue[2]);
        }
        
        var result = BestPath(V, Edges);
        result = Math.Round(result, 3);
        Console.WriteLine(result.ToString("N3"));
    }
}
