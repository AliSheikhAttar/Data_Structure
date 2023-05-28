using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
public class Program1
{  
    public class Node
    {
        public static implicit operator Node(string a) => new Node(a);
        public Node(string value = "")
        {
            this.value = value;
        }
        public Node(Node x)
        {
            this.value = x.value;
            this.left = x.left;
            this.right = x.right;
        }
        public Node left { get; set; } = null;
        public Node right { get; set; } = null;
        public Node parent { get; set; } = null;
        public string value { get; set; }
        public override string ToString()
        {
            return $"{this.value}";
        }
    }
    public static Node[] TreeConstructor(int RootIndex, string[] nodes, List<Tuple<int,int>> edges)
    {
        Node[] tree = new Node[99999999];
        tree[1] = nodes[RootIndex];
        Tuple<int,int> t1;
        Tuple<int,int> t2;
        int i = 1;
        // Node root = nodes[RootIndex];
        while(edges.Count!=0)
        {
            t1 = null;
            t2 = null;
            foreach(var x in edges)
            {
                if(t1!= null && t2!=null)
                    break;
                if(tree[i].value == nodes[x.Item1])
                {
                    if(tree[i].left==null)
                    {
                        // root.left = nodes[x.Item2];
                        // root.left.parent = root;
                        tree[i].left = nodes[x.Item2];
                        tree[i].left.parent = tree[i];
                        tree[2*i] = nodes[x.Item2];
                        tree[2*i].parent = tree[i];
                        t1 = x;
                    }
                    else if(tree[i].right==null)
                    {
                        // root.right= nodes[x.Item2];
                        // root.right.parent = root;
                        tree[i].right = nodes[x.Item2];
                        tree[i].right.parent = tree[i];
                        tree[2*i+1] = nodes[x.Item2];
                        tree[2*i+1].parent = tree[i];

                        t2 = x;
                    }
                    
                }
                // else if(result[i].value == nodes[x.Item2])
                // {
                //     if(result[i].left==null)
                //     {
                //         result[i].left = nodes[x.Item1];
                //         result[2*i] = nodes[x.Item1];
                //         t1 = x;
                //     }
                //     else if(result[i].right==null)
                //     {
                //         result[i].right = nodes[x.Item1];
                //         result[2*i+1] = nodes[x.Item1];
                //         t2 = x;
                //     }
                //     else
                //     {
                //         edges.Remove(t1);
                //         edges.Remove(t2);
                //         break;
                //     }
                    
                // }
            }
            edges.Remove(t1);
            edges.Remove(t2);
            i++;
            // if(i%2==0)
            // {
            //     if(i!=2)
            //     {
            //         root = root.parent;
            //         root = root.left;
            //     }
            //     else
            //         root = root.left;

            // }
            // else
            // {
            //     root = root.parent;
            //     root = root.right;
            // }
            
        }
        return tree;
    }

    public class Tree
    {
        public Node[] tree{get;set;}
        public string prefix{get;set;}
        public string infix{get;set;}
        public string postfix{get;set;}
        public Stack<string> stack;
        public Tree(Node[] tree)
        {
            this.tree = tree;
            this.stack = new Stack<string>();
        }
        public void prefixfun(int i)
        {
            
            prefix+=this.tree[i];
            if(this.tree[2*i]!=null)
            {
                prefixfun(2*i);
            }
            if(this.tree[2*i+1]!=null)
            {
                prefixfun(2*i+1);
            }
                
        
        }
        public void infixfun(int i)
        {
                      
            if(this.tree[2*i]!=null)
            {
                infixfun(2*i);
            }
            infix+=this.tree[i];
            if(this.tree[2*i+1]!=null)
            {
                infixfun(2*i+1);
            }
            
        }   
        public void postfixfun(int i)
        {
            if(this.tree[2*i]!=null)
            {
                postfixfun(2*i);
            }
            if(this.tree[2*i+1]!=null)
            {
                postfixfun(2*i+1);
            } 
            postfix+=this.tree[i];
            stack.Push(this.tree[i].value);
        }
        public double Calculate(string operatorr)
        {
            stack.Pop();
            var x = this.stack.Peek();
            double num1 = 0;
            double num2 = 0;
            string[] numbs = {"1", "2", "3", "4", "5", "6", "7", "8", "9", "0"};
            if(!numbs.Contains(x))
            {
                Calculate(x);
            }

            num1 = double.Parse(stack.Peek());
            stack.Pop();
            if(!numbs.Contains(stack.Peek()))
                Calculate(stack.Peek());
            num2 = double.Parse(stack.Peek());
            stack.Pop();
  
            switch (operatorr)
            {
                case "+":
                    stack.Push(String.Format("{0:F2}", num1+num2));
                    break;
                case "-":
                    stack.Push(String.Format("{0:F2}", num1-num2));
                    break;
                case "*":
                    stack.Push(String.Format("{0:F2}", num1*num2));
                    break;
                case "/":
                    stack.Push(String.Format("{0:F2}", num1/num2));
                    break;
            }
            return double.Parse(stack.Peek());

        }
    }

    public static void Main1()
    {
        var count = long.Parse(Console.ReadLine());
        var nodes = new string[count];
        for(int i=0;i<count;i++)
        {
            nodes[i] = Console.ReadLine().Split(' ')[1];
        }
        var RootIndex = int.Parse(Console.ReadLine());
        var edges = new List<Tuple<int,int>>();
        for(int i=0;i<count-1;i++)
        {
            var read = Console.ReadLine().Split(' ');
            edges.Add(Tuple.Create(int.Parse(read[0]),int.Parse(read[1])));
        }
        Tree mine = new Tree(TreeConstructor(RootIndex,nodes,edges));
        mine.postfixfun(1);
        mine.infixfun(1);
        mine.prefixfun(1);
        Console.WriteLine(mine.postfix);
        Console.WriteLine(mine.infix);
        Console.WriteLine(mine.prefix);
        double result1 = (mine.Calculate(mine.stack.Peek()));
        var result = double .Parse(mine.stack.Peek());
        Console.WriteLine(String.Format("{0:F2}",result1));
        // double t1 = 0;
        // double t2 = 0;
        // t1 = 4;
        // t2 = 5;
        // double t3 = t1*t2;
        // string t4 = String.Format("{0:F2}",t3);
        // Console.WriteLine(String.Format("{0:F2}",t3));
        // Console.WriteLine(t4);
        // Console.WriteLine(String.Format("{0:F2}",t4));
    }
}