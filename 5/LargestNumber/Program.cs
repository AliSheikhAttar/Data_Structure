using System;
using System.Linq;
using System.Collections.Generic;
using static System.Collections.Generic.IEnumerable<string>;
public class Program
{
    public static Tuple<string,string>[] LongestNumber(Tuple<string,string>[] input, long max_length)
    {
        for(int j = 0;j<max_length;j++)
        {
            if(j==0)
                input = CountingSort(input,j,true);
            else 
                input = CountingSort(input,j,false);
        }
        return input;
    }  
    // public static bool mycompare(string x, string y)=> true ? false : long.Parse(x+y)>=long.Parse(y+x);
    public static Tuple<string,string>[] CountingSort(Tuple<string,string>[] input,int index,bool zero)
    {
        Tuple<string,string>[] B = input;
        long[] C;
        var size = 9;
        long jj = 2;
        if(zero)
        {
            size = 10;
            jj=1;
        }
        C = new long[size]; 
        for(long i=0;i<input.Length;i++)
        {
            C[long.Parse($"{input[i].Item2[index]}")]++;
        }
        for(long j=jj;j<10;j++)
        {
            C[j]+=C[j-1];
        }
        for(long i=input.Length-1;i>=0;i--)
        {
            B[C[long.Parse($"{input[i].Item2[index]}")]-1] = input[i];
            C[long.Parse($"{input[i].Item2[index]}")]-=1;

        }
        return B;
        
    }
    public static bool mycompare1(string x, string y)
    {
        var t = long.Parse(x+y);
        var t1 = long.Parse(y+x);
        return t>t1;
    }
    public static bool mycompare(Tuple<string,string> x,Tuple<string,string> y,int i)
    {
        if(int.Parse($"{x.Item2[i]}")!=int.Parse($"{y.Item2[i]}"))
            return int.Parse(x.Item2)>int.Parse(y.Item2);
        return x.Item1.Length<x.Item2.Length;
    }
    public static void Swap(Tuple<string,string>[] input, long x, long y)
    {
        Tuple<string,string> t;
        t = input[x];
        input[x] = input[y];
        input[y] = t;
    } 
    public static void Main()
    {
        var count = long.Parse(Console.ReadLine());
        var input = new Tuple<string,string>[count];
        while(count-->0)
            input[count] = new Tuple<string, string>(Console.ReadLine(),"");
        long max_length = 0;
        foreach(var x in input)
        {
            if(x.Item1.Length>max_length)
                max_length = x.Item1.Length;
        }
        for(long i = 0;i<input.Count();i++)
        {
            if(input[i].Item1.Length!=max_length)
            {
                var t = input[i].Item1;
                var t1 = t;
                while(t.Length!=max_length)
                {
                    t += t[t.Length-1];
                }
                input[i] = new Tuple<string, string>(t1,t);
            }
            else
            {
                input[i] = new Tuple<string, string>(input[i].Item1,input[i].Item1);
            }
        }
        var result = "";
        input = LongestNumber(input, max_length);
        long count1 = input.Length;
        while(count1--!=0)
            result += input[count1].Item1;
        Console.WriteLine(result);
    }

}