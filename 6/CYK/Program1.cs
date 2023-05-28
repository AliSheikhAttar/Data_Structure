// using System;
// using System.Collections.Generic;
// public class Program
// {

//     public static List<String> CYK(string input, Dictionary<string, List<String>> dict)
//     {
//         if(dict.ContainsKey(input))
//             return dict[input];
//         if(input.Length>2)
//         {
//             var x =  CYK(input.Substring(0,1), dict);
//             var y = CYK(input.Substring(1),dict);
//             if(dict.ContainsKey(x[0]+y[0]))
//             {
//                 dict[input.Substring(0,1)+input.Substring(1)] = CYK(x[0]+y[0],dict);
//                 return dict[input.Substring(0,1)+input.Substring(1)];
//             }
//             x =  CYK(input.Substring(0,input.Length-1), dict);
//             y = CYK(input.Substring(input.Length-1),dict);
//             if(dict.ContainsKey(x[0]+y[0]))
//                 dict[input.Substring(0,input.Length-1)+input.Substring(input.Length-1)] = CYK(x[0]+y[0],dict);
//             if(dict.ContainsKey(input.Substring(0,input.Length-1)+input.Substring(input.Length-1)))
//                 return dict[input.Substring(0,input.Length-1)+input.Substring(input.Length-1)];
//         }
//         else
//         {
//             var x =  CYK(input.Substring(0,1), dict);
//             var y = CYK(input.Substring(1),dict);
//             if(dict.ContainsKey(x[0]+y[0]))
//                 dict[input.Substring(0,1)+input.Substring(1)] = CYK(x[0]+y[0],dict);
//             if(dict.ContainsKey(input.Substring(0,1)+input.Substring(1)))
//                 return dict[input.Substring(0,1)+input.Substring(1)];
//         }
//         // if(dict.ContainsKey(input.Substring(0,1)+input.Substring(1)))
//         //     return dict[input.Substring(0,1)+input.Substring(1)];
//         // else
//         //     return dict[input.Substring(0,input.Length-1)+input.Substring(input.Length-1)];

//         return new List<string>(){""};

//     }
//     public static void Main()
//     {
//         var dict = new Dictionary<string, List<string>>();
//         dict["AB"] = new List<string>(){"B","S"};
//         dict["BB"] = new List<string>(){"A"};
//         dict["a"] = new List<string>(){"A"};
//         dict["b"] = new List<string>(){"B"};
//         var input = Console.ReadLine();
//         CYK(input,dict);
//         if(dict.ContainsKey(input))
//         {
//             if(dict[input].Contains("S"))
//                 Console.WriteLine("Accepted");
//             else
//                 Console.WriteLine("Rejected");

//         }
//         else
//             Console.WriteLine("Rejected");
//     }
// }