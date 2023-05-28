using System;
using System.Linq;
public class program1
{
    public class Node
    {
        public static implicit operator Node(double a) => new Node(a);
        public static bool operator >(Node a, Node b) => a.value > b.value;
        public static bool operator <(Node a, Node b) => a.value < b.value;
        public Node(double value = 0, long pos = 0)
        {
            this.value = value;
            this.pos = pos;
        }
        public Node(Node x)
        {
            this.value = x.value;
            this.pos = pos;
        }
        public Node parent { get; set; } = null;
        public long pos { get; set; }
        public double value { get; set; }
        public override string ToString()
        {
            return $"{this.value}";
        }
    }
    public static Node[] HeapConstruction(double[] nodez)
    {
        var result = new Node[9999999];

        for (int i = 1; i < nodez.Length; i++)
        {
            if (nodez[i] != 0)
            {
                result[i] = nodez[i];
                result[i].pos = i;
                nodez[i] = 0;
            }
            if (2 * i < nodez.Length && nodez[2 * i] != 0)
            {

                result[2 * i] = nodez[2 * i];
                result[2 * i].parent = result[i];
                result[2 * i].pos = 2 * i;
                nodez[2 * i] = 0;
                result = Heapproperty(result[2 * i], result);

            }
            if (2 * i + 1 < nodez.Length && nodez[2 * i + 1] != 0)
            {

                result[2 * i + 1] = nodez[2 * i + 1];
                result[2 * i + 1].parent = result[i];
                result[2 * i + 1].pos = 2 * i + 1;
                nodez[2 * i + 1] = 0;
                result = Heapproperty(result[2 * i], result);

            }


        }

        return result;


    }
    public static Node[] Heapproperty(Node x, Node[] nodes)
    {
        Node p = x.parent;
        while (p != null && x != null)
        {
            if (!(x < x.parent))
            {
                Swap(x, x.parent, nodes);
            }
            x = x.parent;
            if (x != null)
                p = x.parent;

        }
        return nodes;
    }
    public static Node[] Heapproperty_root(Node x, Node[] nodes)
    {
        long i=x.pos;
        var state = true;
        while(2*i<nodes.Length && state)
        {
            state = false;
            i=x.pos;
            if(2*i+1<nodes.Length)
            {
                if(x<nodes[2*i] || x<nodes[2*i+1] )
                {
                    state = true;
                    if(nodes[2*i] >nodes[2*i+1])
                    {
                        nodes[2*i+1].parent = nodes[2*i];
                        Swap(nodes[2*i],x,nodes);

                    }
                    else if(!(nodes[2*i] >nodes[2*i+1]))
                    {
                        nodes[2*i].parent = nodes[2*i+1];
                        Swap(nodes[2*i+1],x,nodes);

                    }
                }
                if(2*x.pos<nodes.Length)
                {
                    nodes[2*x.pos].parent = x;
                    if(2*x.pos+1<nodes.Length)
                      nodes[2*x.pos+1].parent = x;  
                }
            }
            else if(2*i<nodes.Length)
            {
                if(x<nodes[2*i])
                {
                    state = true;
                    Swap(nodes[2*i],x,nodes);
                    if(2*x.pos<nodes.Length)
                    {
                        nodes[2*x.pos].parent = x;
                        if(2*x.pos+1<nodes.Length)
                            nodes[2*x.pos+1].parent = x;  
                    }
                }
            }
        }
        return nodes;
    }
    public static Node[] Swap(Node x, Node y, Node[] nodes)
    {
        var t = y.parent;
        var t1 = y.pos;
        y.parent = x;
        x.parent = t;
        y.pos = x.pos;
        x.pos = t1;
        nodes[x.pos] = x;
        nodes[y.pos] = y;
        return nodes;

    }
    public class maxHeap
    {
        public Node[] nodes { get; set; }
        public Node root { get; set; }
        public maxHeap(double[] nodez)
        {
            this.nodes = HeapConstruction(nodez);
            this.root = nodes[1];
        }
        public void update()
        {
            this.nodes[1].value = Math.Floor(this.nodes[1].value/2);
            this.nodes = Heapproperty_root(this.nodes[1], nodes);
            this.root = nodes[1];
        }


    }
    private static double Alice(maxHeap x, long coins)
    {
        double result = 0;
        while (coins != 0)
        {
            result += x.root.value%1000000003;
            result %= 1000000003;
            x.update();
            coins--;
        }
        return result;

    }
    public static void Main1()
    {
        var pots = Console.ReadLine().Split(' ');
        var potz = new double[pots.Length + 1];
        var coins = long.Parse(Console.ReadLine());
        for (int i = 0; i < potz.Length - 1; i++)
        {
            potz[i + 1] = double.Parse(pots[i]);
        }
        var x = new maxHeap(potz);
        Console.WriteLine(Alice(x, coins));
    }


}