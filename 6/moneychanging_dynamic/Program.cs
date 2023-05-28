using System;
using System.Collections.Generic;
public class Program
{
    public static long Moneychangingdynamic(long n)
    {
        var dict = new long[n+1];
        dict[1] = 1;
        dict[2] = 2;
        dict[3] = 1;
        dict[4] = 1;
        for(long i=5;i<=n;i++)
        {
            long a4 = dict[i-4];
            long a3 = dict[i-3];
            long a1 = dict[i-1];
            var min13 = Math.Min(a1,a3);
            var min134 = Math.Min(a4,min13);
            dict[i] = min134+1;
        }
        return dict[n];
    }
    public static void Main()
    {
        Console.WriteLine(Moneychangingdynamic(long.Parse(Console.ReadLine())));
    }
}