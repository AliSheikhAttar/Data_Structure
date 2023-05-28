using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static long Hashing(string str, int m)
    {
        long result = 0;
        long x = 263;

        for (int i = str.Length - 1; i >= 0; i--)
        {
            result = (result * x + str[i]) % 1000000007;
        }
        return result % m;
    }
    public static void Operate(MyHash HashTable)
    {
    try
    {
        var cp = Console.ReadLine().Split(' ');
        var command = cp[0];
        var parameter = cp[1];
        switch (command)
        {
            case "add":
                HashTable.Add(parameter);
                break;
            case "del":
                HashTable.del(parameter);
                break;
            case "find":
                Console.WriteLine(HashTable.find(parameter));
                break;
            case "check":
                Console.WriteLine(HashTable.check(int.Parse(parameter)));
                break;
            default : 
                break;
        }
    }
    catch(System.IndexOutOfRangeException){}
    }
    public class Node
    {
        public static implicit operator Node(string str)=> new Node(str);
        public string value{get;set;}
        public Node next{get;set;}=null;
        public Node(string value)
        {
            this.value = value;
        }   
        public override string ToString()
        {
            return $"{this.value}";
        }

    }
    public class MyLinkedList
    {
        public Node First{get;set;}
        public void Insert(string str)
        {
            if(First==null)
                First = new Node(str);
            else
            {
                var new_first = new Node(str);
                new_first.next = First;
                First = new_first;
            }

        }
    }

    public class MyHash
    {
        public MyLinkedList[] HashTable{get;set;}
        public int m{get;set;}
        public long index2use{get;set;}
        public MyHash(int size)
        {
            HashTable = new MyLinkedList[size];
            m = size;
        }
        public void Add(string str)
        {
            if(find(str)=="no")
            {
                if(HashTable[index2use] == null)
                    HashTable[index2use] = new MyLinkedList();
                HashTable[index2use].Insert(str);
            }
        }
        public void del(string str)
        {
            if(find(str)=="yes")
            {
                var x = HashTable[index2use].First;
                if(x.value==str)
                    HashTable[index2use].First = HashTable[index2use].First.next;
                else
                {
                    while(x.next != null)
                    {
                        if(x.next.value == str)
                        {
                            x.next = x.next.next;
                            break;
                        }
                        x = x.next;
                    }
                }
            }
        }
        public string find(string str)
        {
            index2use = Hashing(str, m);
            if(!(HashTable[index2use]==null))
            {
                var x = HashTable[index2use].First;
                while(x!=null)
                {
                    if(x.value == str)
                        return "yes";
                    x = x.next;
                }
            }
            return "no";

        }
        public string check(int i)
        {
            var result = "";
            if(i>=m || i<0)
                return result;
            if(HashTable[i]!=null)
            {
                var x = HashTable[i].First;
                while(x!=null)
                {
                    result += x + " "; 
                    x = x.next;
                }
            }
            return result.Trim(' ');
        }
    } 
    public static void Main()
    {
        int size = int.Parse(Console.ReadLine());
        int howmany = int.Parse(Console.ReadLine());
        var HashTable = new MyHash(size);
        while(howmany-->0)
            Operate(HashTable);
    }

}

