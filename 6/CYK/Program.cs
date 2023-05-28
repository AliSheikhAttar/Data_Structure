using System;
using System.Collections.Generic;
public class Program
{

    public static List<String> CYK(string input, Dictionary<string, List<String>> dict)
    {
        if(dict.ContainsKey(input))
            return dict[input];
        int i=1;
        for(;i<input.Length;i++)
        {
            var x =  CYK(input.Substring(0,i), dict);
            var y = CYK(input.Substring(i),dict);
            if(dict.ContainsKey(x[0]+y[0]))
                dict[input.Substring(0,i)+input.Substring(i)] = CYK(x[0]+y[0],dict);
            if(dict.ContainsKey(input.Substring(0,i)+input.Substring(i)))
                return dict[input.Substring(0,i)+input.Substring(i)];
        }

    
        return new List<string>(){""};

    }
    public static void Main()
    {
        var dict = new Dictionary<string, List<string>>();
        dict["AB"] = new List<string>(){"B","S"};
        dict["BB"] = new List<string>(){"A"};
        dict["a"] = new List<string>(){"A"};
        dict["b"] = new List<string>(){"B"};
        var input = Console.ReadLine();
        CYK(input,dict);
        if(dict.ContainsKey(input))
        {
            if(dict[input].Contains("S"))
                Console.WriteLine("Accepted");
            else
                Console.WriteLine("Rejected");

        }
        else
            Console.WriteLine("Rejected");
    }
}