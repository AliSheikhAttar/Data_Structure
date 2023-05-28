using System;
using System.Linq;
public class Program
{

    public class Node1
    {
        public static implicit operator Node1(long a) => new Node1(a);
        public static bool operator >(Node1 a, Node1 b) => a.value > b.value;
        public static bool operator <(Node1 a, Node1 b) => a.value < b.value;
        public Node1(long value = 0)
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
        public long value { get; set; }
        public override string ToString()
        {
            return $"{this.value}";
        }
    }
    public static long[] Slice(long[] input, long start, long end)
    {
        if (start > end)
            return new long[0];
        var result = new long[end - start + 1];
        for (long i = start; i < end + 1; i++)
        {
            result[i - start] = input[i];
        }
        return result;
    }
    public static Node1 Root(long[] values)
    {
        long idx = values.Length - 1;
        if (values.Length == 0)
            return null;
        long i;
        var root = new Node1(values[idx]);
        for (i = idx - 1; i >= 0; i--)
        {
            if (values[i] < values[idx])
            {
                root.left = Root(Slice(values, 0, i));
                break;
            }
        }
        root.right = Root(Slice(values, i + 1, idx - 1));
        if (root.left != null)
            root.left.parent = root;
        if (root.right != null)
            root.right.parent = root;

        return root;

    }
    public static Node1 treemaximum(Node1 root)
    {
        if(root.right==null)
            return root;
        return treemaximum(root.right);
    }
    public static Node1 Predecessor(Node1 x)
    {
        if(x.left!=null)
            return treemaximum(x.left);
        else
        {
            var p = x.parent;
            while(p.left==x && p!=null)
            {
                x = p;
                p = p.parent;
            }
            return p;
        }
    }
    public static Node1 Rooot(Node1 node1)
    {
        while(node1.parent!=null)
        {
            node1 = node1.parent;
        }
        return node1;
    }

    public class BST1
    {
        public Node1 root { get; set; }
        public long[] values { get; set; }
        public string preorder = "";
        public BST1(Node1 root, long[] values)
        {
            this.values = values;
            this.root = new Node1(root);
        }
        public void Insert(Node1 root, Node1 input)
        {

            if (input < root)
            {
                if (root.left == null)
                {
                    root.left = input;
                    root.left.parent = root;
                    return;
                }
                Insert(root.left, input);
            }

            else if (input > root)
            {
                if (root.right == null)
                {
                    root.right = input;
                    root.right.parent = root;
                    return;
                }
                Insert(root.right, input);
            }
            else if(input == null)
                return;


        }
        public Node1 todelete12(Node1 root, long input)
        {
            Node1 found = null;
            var root1 = root;
            // if (input == null)
            //     return this.root;
            while (found==null && root1 != null)
            {
                if (input == root1.value)
                    found = root1;
                else if (input < root1.value)
                    root1 = root1.left;
                else if (input > root1.value)
                    root1 = root1.right;
            }
            if (found != null)
            {
                if (found.left == null && found.right == null)
                {
                    if (found > found.parent)
                        found.parent.right = null;
                    else
                        found.parent.left = null;
                    return Rooot(found);
                }
                else if (found.left == null)
                {
                    if (found > found.parent)
                        found.parent.right = found.right;
                    else
                        found.parent.left = found.right;
                    return Rooot(found);
                }
                else if (found.right == null)
                {
                    if (found > found.parent)
                        found.parent.right = found.left;
                    else
                        found.parent.left = found.left;
                    return Rooot(found);
                }
                else
                {
                    found.value = Predecessor(found).value;
                    // !(Predecessor(found).parent==null || Predecessor(found).parent>found)
              
                    if(Predecessor(found).left==null)
                        Predecessor(found).parent.right=null;
                    else
                        Predecessor(found).parent.right = Predecessor(found).left;
                
                    return Rooot(found);
                }
            }
            else
                return this.root;
        }


        public Node1 todelete1(Node1 root, long input)
        {
            Node1 found = null;
            var root1 = root;
            Node1 y;
            Node1 x;
            while (found==null && root1 != null)
            {
                if (input == root1.value)
                    found = root1;
                else if (input < root1.value)
                    root1 = root1.left;
                else if (input > root1.value)
                    root1 = root1.right;
            }
            if (found != null)
            {
                if (found.left == null && found.right == null)
                {
                    y = found;
                }
                else
                {
                    y = Predecessor(found);
                }
                if(y.left!=null)
                {
                    x = y.left;
                }
                else
                {
                    x = y.right;
                }
                if(x!=null)
                {
                    
                    x.parent = y.parent;
                }
                if(y.parent==null)
                {
                    root = x;
                }
                else if(y==y.parent.left)
                {
                    y.parent.left = x;
                }
                else
                {
                    y.parent.right = x;
                }
                if(y.value!=input)
                {
                    found.value = y.value;
                }
                return Rooot(y);
            }
            return null;
    }
      

        public bool Search(Node1 input)
        {
            if(root==null)
                return false;
            var root1 = root;
            if (input == null)
                return false;
            while (root1 != null)
            {
                if (input < root1)
                    root1 = root1.left;
                else if (input > root1)
                    root1 = root1.right;
                else if (input.value == root1.value)
                    return true;
            }
            return false;
        }
        public void preorderfun(Node1 root)
        {
            preorder += $"{root} ";
            if (root.left != null)
            {
                preorderfun(root.left);
            }
            if (root.right != null)
            {
                preorderfun(root.right);
            }

        }

    }











    class Node
    {
        public int value;
        public Node lChild;
        public Node rChild;

        public Node(int v)
        {
            value = v;
            lChild = null;
            rChild = null;
        }   

    }

    class BST
    {
        public Node root;

        public BST(Node n)
        {
            root = n;
        }

        public void Insert(Node newNode, Node root)
        {
            if (newNode.value < root.value)
            {
                if (root.lChild == null)
                {
                    root.lChild = newNode;
                    return;
                }
                Insert(newNode, root.lChild);
            }

            else
            {
                if (root.rChild == null)
                {
                    root.rChild = newNode;
                    return;
                }
                Insert(newNode, root.rChild);
            }
        }

        public bool Search(int value, Node root)
        {

            if (root == null)
                return false;

            if (root.value == value)
                return true;

            if (value < root.value)
            {
                if (root.lChild == null)
                    return false;
                if (root.lChild.value == value)
                    return true;
                return
                    Search(value, root.lChild);
            }

            else
            {
                if (root.rChild == null)
                    return false;
                if (root.rChild.value == value)
                    return true;

                return
                    Search(value, root.rChild);
            }
        }

        public void Delete(int value, Node root)
        {
            if (value < root.value)
            {
                if (value != root.lChild.value)
                    Delete(value, root.lChild);
                else
                {
                    if (root.lChild.lChild == null && root.lChild.rChild != null)
                        root.lChild = root.lChild.rChild;

                    else if (root.lChild.rChild == null && root.lChild.lChild != null)
                        root.lChild = root.lChild.lChild;

                    else if (root.lChild.rChild != null && root.lChild.lChild != null)
                    {
                        int predecessor = Predecessor(root.lChild.lChild);
                        Delete(predecessor, root);

                        Node predecessorNode = new Node(predecessor);

                        Node temp = root.lChild;
                        root.lChild = predecessorNode;

                        if (temp.lChild != null)
                            predecessorNode.lChild = temp.lChild;

                        if (temp.rChild != null)
                            predecessorNode.rChild = temp.rChild;
                    }

                    else
                        root.lChild = null;

                }
            }

            else if (value > root.value)
            {
                if (value != root.rChild.value)
                    Delete(value, root.rChild);
                else
                {
                    if (root.rChild.lChild == null && root.rChild.rChild != null)
                        root.rChild = root.rChild.rChild;

                    else if (root.rChild.rChild == null && root.rChild.lChild != null)
                        root.rChild = root.rChild.lChild;

                    else if (root.rChild.rChild != null && root.rChild.lChild != null)
                    {
                        int predecessor = Predecessor(root.rChild.lChild);
                        Delete(predecessor, root);

                        Node predecessorNode = new Node(predecessor);

                        Node temp = root.rChild;
                        root.rChild = predecessorNode;

                        if (temp.lChild != null)
                            predecessorNode.lChild = temp.lChild;

                        if (temp.rChild != null)
                            predecessorNode.rChild = temp.rChild;
                    }

                    else
                        root.rChild = null;

                }
            }


        }

        private static int Predecessor(Node root)
        {
            if (root.rChild == null)
                return root.value;

            return Predecessor(root.rChild);
        }

        public string Preorder(Node root)
        {
            string output = "";

            if (root == null)
                return "";

            output += root.value + " ";

            if (root.lChild != null)
                output += Preorder(root.lChild);

            if (root.rChild != null)
                output += Preorder(root.rChild);

            return output;
        }


        public void DeleteRoot(Node root)
        {
            if (root.lChild == null & root.rChild != null)
            {
                this.root = root.rChild;
            }

            else if (root.rChild == null & root.lChild != null)
            {
                this.root = root.lChild;
            }

            else if (root.rChild != null & root.lChild != null)
            {
                int predecessor = Predecessor(root.lChild);
                Delete(predecessor, root);

                Node predecessorNode = new Node(predecessor);


                if (root.lChild != null)
                    predecessorNode.lChild = root.lChild;

                if (root.rChild != null)
                    predecessorNode.rChild = root.rChild;

                this.root = predecessorNode;
            }

            else
                this.root = null;
        }
    }








    public static void Main()
    {
        // long length = long.Parse(Console.ReadLine()); //length
        // var node1z = Console.ReadLine(); //node1s postorder
        // var node1s = node1z.Split(' ');
        // long[] inputz = new long[length];
        // for (long i = 0; i < length; i++)
        // {
        //     inputz[i] = long.Parse(node1s[i]);
        // }
        // var todelete = long.Parse(Console.ReadLine()); //2delete
        // var toinsert = long.Parse(Console.ReadLine()); //2insert
        // var tosearch = long.Parse(Console.ReadLine()); //2search
        // BST1 mine = new BST1(Root(inputz), inputz);
        // var newroot = mine.todelete1(mine.root, todelete);
        // mine.root = newroot;
        // mine.Insert(mine.root,toinsert);
        // Console.WriteLine(mine.Search(tosearch));
        // mine.preorderfun(mine.root);
        // Console.WriteLine(mine.preorder);

            var n = int.Parse(Console.ReadLine());

            var s = Console.ReadLine().Split(' ');
            int[] nodesValue = Array.ConvertAll(s, int.Parse);

            Node r = new Node(nodesValue[nodesValue.Length - 1]);

            BST bst = new BST(r);

            for (int i = nodesValue.Length - 2; i >= 0; i--)
            {
                Node newNode = new Node(nodesValue[i]);

                bst.Insert(newNode, bst.root);
            }

            var todelete = int.Parse(Console.ReadLine());

            if (todelete == bst.root.value)
                bst.DeleteRoot(bst.root);
            else
                bst.Delete(todelete, bst.root);

            var toinsert = int.Parse(Console.ReadLine());

            Node insertNode = new Node(toinsert);

            bst.Insert(insertNode, bst.root);

            var tosearch = int.Parse(Console.ReadLine());

            Console.WriteLine(bst.Search(tosearch, bst.root));

            Console.WriteLine(bst.Preorder(bst.root));
    }

}
