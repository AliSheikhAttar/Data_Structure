using System;
public class Program
{
    static long Merge(long[] input, long[] auxil, long left, long mid, long right)
    {
        long i = left;
        long j = mid;
        long k = left;
        long InversionCount = 0;
        while ((i <= mid - 1) && (j <= right)) 
        {
            if (input[i] <= input[j])
                auxil[k++] = input[i++];
            else 
            {
                auxil[k++] = input[j++];
                InversionCount = InversionCount + (mid - i);
            }
        }
        while (i <= mid - 1)
            auxil[k++] = input[i++];

        while (j <= right)
            auxil[k++] = input[j++];

        for (i = left; i <= right; i++)
            input[i] = auxil[i];
 
        return InversionCount;
    }
    static long MergeSort(long[] input, long[] auxil, long left, long right)
    {
        long mid = 0;
        long InversionCount = 0;
        if (right > left) 
        {
            mid = (right + left) / 2;
            InversionCount += MergeSort(input, auxil, left, mid);
            InversionCount += MergeSort(input, auxil, mid + 1, right);
            InversionCount += Merge(input, auxil, left, mid + 1, right);
        }
        return InversionCount;
    }
    public static void Main()
    {
        var count = long.Parse(Console.ReadLine());
        var inputs = new long[count];
        long[] auxil = new long[count];
        long i = -1;
        while(i++<count-1)
            inputs[i] = long.Parse(Console.ReadLine());
        Console.WriteLine(MergeSort(inputs,auxil,0,count-1));
    }
}