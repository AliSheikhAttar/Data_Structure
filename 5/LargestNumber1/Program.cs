using System;
using System.Linq;
public class Program
{
    public static string[] LongestNumber(string[] input)
    {
        var Swaped = true;
        for(long j = input.Count(); j>-1;j--)
        {
            if(!Swaped)
                break;
            Swaped = false;
            for(long i=0;i<j-1;i++)
            {    
                if(mycompare(input[i],input[i+1]))
                {
                    Swaped = true;
                    Swap(input,i,i+1);
                }
            }
        }
        return input;
    }  
    // public static bool mycompare(string x, string y)=> true ? false : long.Parse(x+y)>=long.Parse(y+x);
    public static bool mycompare(string xs, string ys)
    {
        var x = long.Parse(xs);
        var y = long.Parse(ys);
        long xy = x;
        long yx = y;
    
        // Count length of x and y
        long countx = 0;
        long county = 0;
    
        // Count length of X
        while (x > 0) 
        {
        countx++;
        x /= 10;
        }
    
        // Count length of Y
        while (y > 0) {
        county++;
        y /= 10;
        }
    
        x = xy;
        y = yx;
    
        while (countx > 0) {
        countx--;
        yx *= 10;
        }
    
        while (county > 0) {
        county--;
        xy *= 10;
        }
    
        // Append x to y
        yx += x;
    
        // Append y to x
        xy += y;
        if(-xy + yx<0)
            return true;
        return false;   

    
    }
    public static void Swap(string[] input, long x, long y)
    {
        string t = "";
        t = input[x];
        input[x] = input[y];
        input[y] = t;
    } 
    public static void Main()
    {
        var count = long.Parse(Console.ReadLine());
        var input = new string[count];
        while(count-->0)
            input[count] = Console.ReadLine();
        var result = "";
        input = LongestNumber(input);
        long count1 = input.Length;
        while(count1--!=0)
            result += input[count1];
        Console.WriteLine(result);
    }

}