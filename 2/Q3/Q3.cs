using System;
public class Program
{
    public class Node
    {
        public Node(int data=0)
        {
            Data = data;
        }
        public static implicit operator Node(int x)
        {
            return new Node(x);
        }
        public int Data{get; set;}=0;
        public Node Previous{get; set;}=null;
        public Node After{get; set;}=null;
        public override string ToString()
        {
            return $"{Data}";
        }
    }
    public class MyStack
    {
        public MyStack()
        {

        }

        public Node Head{get;set;}
        public Node Middle{get;set;}
        public long Count{get;set;}
        
        public void Push(Node input)
        {
            if(this.Count==0)
            {
                Head = new Node();
                Middle = new Node();
            }
            input.After = Head;
            Head.Previous = input;
            Head = input;
            Count++;
            if((Count!=1) && Count%2==1)
                Middle = Middle.Previous;
            else if(Count==1)
                Middle = Head;
        }
        public void Pop()
        {
            Count--;
            if(Count==0)
            {
                throw new System.InvalidOperationException();
            }
            Head = Head.After;
            if(Count%2==0)
                Middle = Middle.After;
        }
        public void DeleteMiddle()
        {
            if(this.Count==0)
                throw new System.InvalidOperationException();
            else if(this.Count==1)
                Middle = null;
            else if(this.Count==2)
                Middle = Head;
            else if(this.Count%2==0)
            {
                Middle.After.Previous = Middle.Previous;
                Middle.Previous.After = Middle.After;
                Middle = Middle.Previous;
                this.Count--;
            }
            else if(this.Count%2==1)
            {
                Middle.After.Previous = Middle.Previous;
                Middle.Previous.After = Middle.After;
                Middle = Middle.After;
                this.Count--;
            }

        }

        


    }
    public static void Main()
    {

    }
    
}