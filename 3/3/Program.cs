using System;
using System.Linq;
public class program
{
    public class Node1
    {
        public static implicit operator Node1(double a) => new Node1(a);
        public static bool operator >(Node1 a, Node1 b) => a.value > b.value;
        public static bool operator <(Node1 a, Node1 b) => a.value < b.value;
        public Node1(double value = 0, long pos = 0)
        {
            this.value = value;
            this.pos = pos;
        }
        public Node1(Node1 x)
        {
            this.value = x.value;
            this.pos = pos;
        }
        public Node1 parent { get; set; } = null;
        public long pos { get; set; }
        public double value { get; set; }
        public override string ToString()
        {
            return $"{this.value}";
        }
    }
    public static Node1[] HeapConstruction(double[] node1z)
    {
        var result = new Node1[9999999];

        for (int i = 1; i < node1z.Length; i++)
        {
            if (node1z[i] != 0)
            {
                result[i] = node1z[i];
                result[i].pos = i;
                node1z[i] = 0;
            }
            if (2 * i < node1z.Length && node1z[2 * i] != 0)
            {

                result[2 * i] = node1z[2 * i];
                result[2 * i].parent = result[i];
                result[2 * i].pos = 2 * i;
                node1z[2 * i] = 0;
                result = Heapproperty(result[2 * i], result);

            }
            if (2 * i + 1 < node1z.Length && node1z[2 * i + 1] != 0)
            {

                result[2 * i + 1] = node1z[2 * i + 1];
                result[2 * i + 1].parent = result[i];
                result[2 * i + 1].pos = 2 * i + 1;
                node1z[2 * i + 1] = 0;
                result = Heapproperty(result[2 * i], result);

            }


        }

        return result;


    }
    public static Node1[] Heapproperty(Node1 x, Node1[] node1s)
    {
        Node1 p = x.parent;
        while (p != null && x != null)
        {
            if (!(x < x.parent))
            {
                Swap(x, x.parent, node1s);
            }
            x = x.parent;
            if (x != null)
                p = x.parent;

        }
        return node1s;
    }
    public static Node1[] Heapproperty_root(Node1 x, Node1[] node1s)
    {
        long i=x.pos;
        var state = true;
        while(2*i<node1s.Length && state)
        {
            state = false;
            i=x.pos;
            if(2*i+1<node1s.Length)
            {
                if(x<node1s[2*i] || x<node1s[2*i+1] )
                {
                    state = true;
                    if(node1s[2*i] >node1s[2*i+1])
                    {
                        node1s[2*i+1].parent = node1s[2*i];
                        Swap(node1s[2*i],x,node1s);

                    }
                    else if(!(node1s[2*i] >node1s[2*i+1]))
                    {
                        node1s[2*i].parent = node1s[2*i+1];
                        Swap(node1s[2*i+1],x,node1s);

                    }
                }
                if(2*x.pos<node1s.Length)
                {
                    node1s[2*x.pos].parent = x;
                    if(2*x.pos+1<node1s.Length)
                      node1s[2*x.pos+1].parent = x;  
                }
            }
            else if(2*i<node1s.Length)
            {
                if(x<node1s[2*i])
                {
                    state = true;
                    Swap(node1s[2*i],x,node1s);
                    if(2*x.pos<node1s.Length)
                    {
                        node1s[2*x.pos].parent = x;
                        if(2*x.pos+1<node1s.Length)
                            node1s[2*x.pos+1].parent = x;  
                    }
                }
            }
        }
        return node1s;
    }
    public static Node1[] Swap(Node1 x, Node1 y, Node1[] node1s)
    {
        var t = y.parent;
        var t1 = y.pos;
        y.parent = x;
        x.parent = t;
        y.pos = x.pos;
        x.pos = t1;
        node1s[x.pos] = x;
        node1s[y.pos] = y;
        return node1s;

    }
    public class maxHeap1
    {
        public Node1[] node1s { get; set; }
        public Node1 root { get; set; }
        public maxHeap1(double[] node1z)
        {
            this.node1s = HeapConstruction(node1z);
            this.root = node1s[1];
        }
        public void update()
        {
            this.node1s[1].value = Math.Floor(this.node1s[1].value/2);
            this.node1s = Heapproperty_root(this.node1s[1], node1s);
            this.root = node1s[1];
        }


    }
    private static double Alice(maxHeap1 x, long coins)
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







    class Node
    {
        public int value;
        public int id;
        public Node lChild;
        public Node rChild;
        public static int count = 0;
        public static Node[] nodes = new Node[1000000];

        public Node(int v)
        {
            value = v;
            lChild = null;
            rChild = null;
            nodes[++count] = this;
            id = count;

            if (count != 1)
            {
                if (id % 2 == 1)
                    nodes[id / 2].rChild = this;
                else
                    nodes[id / 2].lChild = this;
                

            }
        }



    }


    class Heap
    {
        public void Insert(Node newNode)
        {
            if (newNode.id == 1 || newNode.value <= Node.nodes[newNode.id / 2].value)
                return;

            SwapTwoNodesValues(Node.nodes[newNode.id / 2], newNode);

            Insert(Node.nodes[newNode.id / 2]);
        }

        public static void SwapTwoNodesValues(Node n1, Node n2)
        {
            int temp = n1.value;
            n1.value = n2.value;
            n2.value = temp;
        }

        public int DeleteRoot()
        {
            int rootvalue = Node.nodes[1].value;

            Node.nodes[1].value = Node.nodes[Node.count].value;

            if (Node.count % 2 == 1)
                Node.nodes[Node.count / 2].rChild = null;
            else
                Node.nodes[Node.count / 2].lChild = null;

            Node.count--;
            IsValidPosition(Node.nodes[1]);

            return rootvalue;
        }

        public static void IsValidPosition(Node n)
        {
            if (n.lChild == null && n.rChild == null)
                return;

            else if (n.lChild != null && n.rChild != null)
            {
                if (n.lChild.value > n.rChild.value)
                {
                    if (n.lChild.value > n.value)
                    {
                        SwapTwoNodesValues(n, n.lChild);

                        IsValidPosition(n.lChild);
                        return;
                    }
                }
                else
                {
                    if (n.rChild.value > n.value)
                    {
                        SwapTwoNodesValues(n, n.rChild);

                        IsValidPosition(n.rChild);
                        return;
                    }
                }
            }
            if (n.rChild == null && n.lChild.value > n.value)
            {
                SwapTwoNodesValues(n, n.lChild);

                IsValidPosition(n.lChild);
                return;
            }

            if (n.lChild == null && n.rChild.value > n.value)
            {
                SwapTwoNodesValues(n, n.rChild);

                IsValidPosition(n.rChild);
                return;
            }


        }

    }





    public static void Main()
    {

            var inputz = Console.ReadLine().Split(' ');
            var coin = int.Parse(Console.ReadLine());
            int[] vases = new int[inputz.Length];
            for (int i = 0; i < vases.Length; i++)
            {
                vases[i] = int.Parse(inputz[i]);
            }


            Heap heap = new Heap();

            for (int i = 0; i < vases.Length; i++)
            {
                heap.Insert(new Node(vases[i]));
            }

            int sum = 0;

            for (int i = 0; i < coin; i++)
            {
                int max = heap.DeleteRoot();
                sum += max % 1000000003;
                sum %= 1000000003;
                new Node(max / 2);
            }

            Console.WriteLine(sum);
        // var pots = Console.ReadLine().Split(' ');
        // var potz = new double[pots.Length + 1];
        // var coins = long.Parse(Console.ReadLine());
        // for (int i = 0; i < potz.Length - 1; i++)
        // {
        //     potz[i + 1] = double.Parse(pots[i]);
        // }
        // var x = new maxHeap1(potz);
        // Console.WriteLine(Alice(x, coins));
    }


}