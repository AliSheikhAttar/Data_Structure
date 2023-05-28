using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
public class Program
{  
    public class Node1
    {
        public static implicit operator Node1(string a) => new Node1(a);
        public Node1(string value = "")
        {
            this.value = value;
        }
        public Node1(Node1 x)
        {
            this.value = x.value;
            this.left = x.left;
            this.right = x.right;
        }
        public Node1 left { get; set; } = null;
        public Node1 right { get; set; } = null;
        public Node1 parent { get; set; } = null;
        public string value { get; set; }
        public override string ToString()
        {
            return $"{this.value}";
        }
    }
    public static Node1[] Tree1Constructor(int RootIndex, string[] node1s, List<Tuple<int,int>> edges)
    {
        Node1[] tree1 = new Node1[99999999];
        tree1[1] = node1s[RootIndex];
        Tuple<int,int> t1;
        Tuple<int,int> t2;
        int i = 1;
        // Node1 root = node1s[RootIndex];
        while(edges.Count!=0)
        {
            t1 = null;
            t2 = null;
            foreach(var x in edges)
            {
                if(t1!= null && t2!=null)
                    break;
                if(tree1[i].value == node1s[x.Item1])
                {
                    if(tree1[i].left==null)
                    {
                        // root.left = node1s[x.Item2];
                        // root.left.parent = root;
                        tree1[i].left = node1s[x.Item2];
                        tree1[i].left.parent = tree1[i];
                        tree1[2*i] = node1s[x.Item2];
                        tree1[2*i].parent = tree1[i];
                        t1 = x;
                    }
                    else if(tree1[i].right==null)
                    {
                        // root.right= node1s[x.Item2];
                        // root.right.parent = root;
                        tree1[i].right = node1s[x.Item2];
                        tree1[i].right.parent = tree1[i];
                        tree1[2*i+1] = node1s[x.Item2];
                        tree1[2*i+1].parent = tree1[i];

                        t2 = x;
                    }
                    
                }
                // else if(result[i].value == node1s[x.Item2])
                // {
                //     if(result[i].left==null)
                //     {
                //         result[i].left = node1s[x.Item1];
                //         result[2*i] = node1s[x.Item1];
                //         t1 = x;
                //     }
                //     else if(result[i].right==null)
                //     {
                //         result[i].right = node1s[x.Item1];
                //         result[2*i+1] = node1s[x.Item1];
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
        return tree1;
    }

    public class Tree1
    {
        public Node1[] tree1{get;set;}
        public string prefix{get;set;}
        public string infix{get;set;}
        public string postfix{get;set;}
        public Stack<string> stack;
        public Tree1(Node1[] tree1)
        {
            this.tree1 = tree1;
            this.stack = new Stack<string>();
        }
        public void prefixfun(int i)
        {
            
            prefix+=this.tree1[i];
            if(this.tree1[2*i]!=null)
            {
                prefixfun(2*i);
            }
            if(this.tree1[2*i+1]!=null)
            {
                prefixfun(2*i+1);
            }
                
        
        }
        public void infixfun(int i)
        {
                      
            if(this.tree1[2*i]!=null)
            {
                infixfun(2*i);
            }
            infix+=this.tree1[i];
            if(this.tree1[2*i+1]!=null)
            {
                infixfun(2*i+1);
            }
            
        }   
        public void postfixfun(int i)
        {
            if(this.tree1[2*i]!=null)
            {
                postfixfun(2*i);
            }
            if(this.tree1[2*i+1]!=null)
            {
                postfixfun(2*i+1);
            } 
            postfix+=this.tree1[i];
            stack.Push(this.tree1[i].value);
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









    class Node
    {
        public string value;

        public Node lChild;

        public Node rChild;

        public Node(string v)
        {
            value = v;
        }
    }

    class Tree
    {
        public Node root;

        public Tree(Node n)
        {
            root = n;
        }

        public void SetEdge(Node father, Node child)
        {
            if (father.lChild == null)
                father.lChild = child;

            else
                father.rChild = child;
        }
        public string Preorder(Node root)
        {
            string output = "";

            if (root == null)
                return output;

            output += root.value;

            output += Preorder(root.lChild);

            output += Preorder(root.rChild);

            return output;
        }
        public string Postorder(Node root)
        {
            string output = "";

            if (root == null)
                return output;

            output += Postorder(root.lChild);

            output += Postorder(root.rChild);

            output += root.value;

            return output;
        }
        public string Inorder(Node root)
        {
            string output = "";

            if (root == null)
                return output;

            output += Inorder(root.lChild);

            output += root.value;

            output += Inorder(root.rChild);

            return output;
        }

        public double CalculatePostFix(string postfix)
        {
            Stack<double> st = new Stack<double>();

            for (int i = 0; i < postfix.Length; i++)
            {
                if (postfix[i] == '+' || postfix[i] == '-' || postfix[i] == '*' || postfix[i] == '/' || postfix[i] == '^')
                {
                    char ch = postfix[i];

                    double m = st.Pop();
                    double n = st.Pop();

                    if (ch == '+')
                        st.Push(m + n);
                    else if (ch == '-')
                        st.Push(n-m);
                    if (ch == '*')
                        st.Push(m * n);
                    if (ch == '/')
                        st.Push(n/m);
                    if (ch == '^')
                        st.Push(Math.Pow(n, m));
                }

                else
                {
                    st.Push(double.Parse(postfix[i].ToString()));
                }
            }

            return st.Pop();
        }
    }






    public static void Main()
    {



            int v = int.Parse(Console.ReadLine());

            Node[] nodes = new Node[v];

            for (int i = 0; i < v; i++)
            {
                string[] input = Console.ReadLine().Split(' ');

                nodes[int.Parse(input[0])] = new Node(input[1]);
            }

            int root = int.Parse(Console.ReadLine());

            Tree tree = new Tree(nodes[root]);

            for (int i = 0; i < v - 1; i++)
            {
                var inputs = Console.ReadLine().Split(' ');
                int[] input = Array.ConvertAll(inputs, int.Parse);

                tree.SetEdge(nodes[input[0]], nodes[input[1]]);

            }

            string postorder = tree.Postorder(tree.root);

            Console.WriteLine(postorder);
            Console.WriteLine(tree.Inorder(tree.root));
            Console.WriteLine(tree.Preorder(tree.root));


            Console.WriteLine(String.Format("{0:0.00}", tree.CalculatePostFix(postorder)));
            // var v = int.Parse(Console.ReadLine());
        // var node1s = new string[count];
        // for(int i=0;i<count;i++)
        // {
        //     node1s[i] = Console.ReadLine().Split(' ')[1];
        // }
        // var RootIndex = int.Parse(Console.ReadLine());
        // var edges = new List<Tuple<int,int>>();
        // for(int i=0;i<count-1;i++)
        // {
        //     var read = Console.ReadLine().Split(' ');
        //     edges.Add(Tuple.Create(int.Parse(read[0]),int.Parse(read[1])));
        // }
        // Tree1 mine = new Tree1(Tree1Constructor(RootIndex,node1s,edges));
        // mine.postfixfun(1);
        // mine.infixfun(1);
        // mine.prefixfun(1);
        // Console.WriteLine(mine.postfix);
        // Console.WriteLine(mine.infix);
        // Console.WriteLine(mine.prefix);
        // double result1 = (mine.Calculate(mine.stack.Peek()));
        // var result = double .Parse(mine.stack.Peek());
        // Console.WriteLine(String.Format("{0:F2}",result1));
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