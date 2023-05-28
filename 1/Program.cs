using System;
using System.Linq;
namespace Assingment1{
public class Program
{

    static long Cut_tree(long size,long[] input_list)
    {
        long mabna = (input_list[size-1]-input_list[0])/(size);
        long count = mabna;
        long i = 0;
        while(count==mabna)
        {
            count = input_list[i+1]-input_list[i];
            i+=1;
        }
        return input_list[i]-mabna;
    }
    public static void Main()
    {
        long size = long.Parse(Console.ReadLine());
        string[] str_array = Console.ReadLine().Split(' ');
        long[] input_list = new long[size];
        for(long i=0;i<size;i++)
        {
            input_list[i] = long.Parse(str_array[i]);
        }
        var toprint = Cut_tree(size,input_list);
        Console.WriteLine(toprint);

    }
}
}