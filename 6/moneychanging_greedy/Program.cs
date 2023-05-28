using System;
public class Program
{
    public static long MoneyChangingGreedy(long n)
    {
        long count = 0;
        while(n!=0)
        {
            if(n>=10)
            {
                n-=10;
                count++;
            }
            else if(n>=5)
            {
                n-=5;
                count++;
            }
            else
            {
                n-=1;
                count++;
            }
        }
        return count;
    }
    public static void Main()
    {
        var n = long.Parse(Console.ReadLine());
        Console.WriteLine(MoneyChangingGreedy(n));

    }
}