using System;
using System.Linq;
public class Program1
{

    public class Node
    {
        public static implicit operator Node(long a) => new Node(a);
        public static bool operator >(Node a, Node b) => a.value > b.value;
        public static bool operator <(Node a, Node b) => a.value < b.value;
        public Node(long value = 0)
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
    public static Node Root(long[] values)
    {
        long idx = values.Length - 1;
        if (values.Length == 0)
            return null;
        long i;
        var root = new Node(values[idx]);
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
    public static Node treemaximum(Node root)
    {
        if(root.right==null)
            return root;
        return treemaximum(root.right);
    }
    public static Node Predecessor(Node x)
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
    public static Node Rooot(Node node)
    {
        while(node.parent!=null)
        {
            node = node.parent;
        }
        return node;
    }

    public class BST
    {
        public Node root { get; set; }
        public long[] values { get; set; }
        public string preorder = "";
        public BST(Node root, long[] values)
        {
            this.values = values;
            this.root = new Node(root);
        }
        public void Insert(Node root, Node input)
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
        public Node deleteNode(Node root, long input)
        {
            Node found = null;
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
                    deleteNode(Predecessor(found),Predecessor(found).value);
                    return Rooot(found);
                }
            }
            else
                return this.root;
        }


        public Node deleteNode1(Node root, long k)
        {

            // Base case
            if (root == null)
                return root;

            // Recursive calls for ancestors of
            // node to be deleted
            if (root.value > k)
            {
                root.left = deleteNode1(root.left, k);
                return root;
            }
            else if (root.value < k)
            {
                root.right = deleteNode1(root.right, k);
                return root;
            }
            else if (root.value == k)
            {
                this.values = this.values.Where(x => x != k).ToArray();
                this.root = Root(this.values);
                return Root(this.values);
            }

            // We reach here when root is the node
            // to be deleted.

            // If one of the children is empty
            if (root.left == null)
            {
                Node temp = root.right;
                return temp;
            }
            else if (root.right == null)
            {
                Node temp = root.left;
                return temp;
            }

            // If both children exist
            else
            {
                Node succParent = root;

                // Find successor
                Node succ = root.right;

                while (succ.left != null)
                {
                    succParent = succ;
                    succ = succ.left;
                }

                // Delete successor. Since successor
                // is always left child of its parent
                // we can safely make successor's right
                // right child as left of its parent.
                // If there is no succ, then assign
                // succ->right to succParent->right
                if (succParent != root)
                    succParent.left = succ.right;
                else
                    succParent.right = succ.right;

                // Copy Successor Data to root
                root.value = succ.value;
                return root;
            }
        }


        public bool Search(Node input)
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
        public void preorderfun(Node root)
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
    // public static void Main()
    // {
    //     long length = long.Parse(Console.ReadLine()); //length
    //     var nodez = Console.ReadLine(); //nodes postorder
    //     var nodes = nodez.Split(' ');
    //     long[] inputz = new long[length];
    //     for (long i = 0; i < length; i++)
    //     {
    //         inputz[i] = long.Parse(nodes[i]);
    //     }
    //     var todelete = long.Parse(Console.ReadLine()); //2delete
    //     var toinsert = long.Parse(Console.ReadLine()); //2insert
    //     var tosearch = long.Parse(Console.ReadLine()); //2search
    //     BST mine = new BST(Root(inputz), inputz);
    //     var newroot = mine.deleteNode(mine.root, todelete);
    //     mine.root = newroot;
    //     mine.Insert(mine.root,toinsert);
    //     Console.WriteLine(mine.Search(tosearch));
    //     mine.preorderfun(mine.root);
    //     Console.WriteLine(mine.preorder);
    // }

}
