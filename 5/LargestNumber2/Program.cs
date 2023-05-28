using System;
using System.Linq;
using System.Collections.Generic;
using static System.Collections.Generic.IEnumerable<string>;
public class Program
{
    public static Tuple<string,string>[] LongestNumber(Tuple<string,string>[] input)
    {
        var Swaped = true;
        for(long j = input.Count(); j>-1;j--)
        {
            if(!Swaped)
                break;
            Swaped = false;
            for(long i=0;i<j-1;i++)
            {    
                if(long.Parse(input[i].Item2)>long.Parse(input[i+1].Item2))
                {
                    Swaped = true;
                    Swap(input,i,i+1);
                }
            }
        }
        return input;
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
            if(input[i].Item2.Length!=max_length)
            {
                var t = input[i].Item1;
                var t1 = t;
                while(t.Length!=max_length)
                {
                    t += t[0];
                }
                input[i] = new Tuple<string, string>(t1,t);
            }
        }
        var result = "";
        input = LongestNumber(input);
        long count1 = input.Length;
        while(count1--!=0)
            result += input[count1].Item1;
        result = result.TrimStart('0');
        if(result =="")
            result = "0";
        Console.WriteLine(result);
    }

}