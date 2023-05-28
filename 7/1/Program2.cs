// using System;
// using System.Linq;
// using System.Collections.Generic;
// using System.Linq.Expressions;
// using System.Collections;

// public class HW1
// {
//     public static double Find_Distance(Tuple<int , int >x , Tuple<int , int >y)
//     {
//         return Math.Abs(x.Item1 - y.Item1) + Math.Abs(x.Item2 - y.Item2) ;
//     }
    
//     public class Node
//     {
//         public Tuple<int , int > Point ;
//         public bool IsVisited = false ;

//         public Node(Tuple<int, int> point)
//         {
//             this.Point = point ;
//         }

//         public Type ElementType => typeof(Tuple<int,int>);

//     }

//     public class Edge
//     {
//         public Tuple<int, int> head ; 
//         public Tuple<int, int> tail ; 
//         public double value ;

//         public Edge(Tuple<int, int> head, Tuple<int, int> tail)
//         {
//             this.head = head;
//             this.tail = tail;
//             this.value = Find_Distance(head , tail);
//         }
//     }

//     public static void Main()
//     {
//         var n = int.Parse(Console.ReadLine());
//         var nodes = new Tuple<int, int>[n] ;
//         var list = new List<Tuple<int, int>>();
//         var cycles = new List<Tuple<int, int>>();
//         var result = new List<Tuple<int, int>>();
//         var result_edge = new List<Edge>();
//         var edges = new Edge[(n * ( n-1 ))/2] ;
//         int inedx = 0 ;

//         //making node from each point 
//         for(int i = 0 ; i < n ; i ++ )
//         {
//             var toks = Array.ConvertAll( Console.ReadLine().Split(' ') , int.Parse ) ;
//             var node = new Tuple<int, int>(toks[0] , toks[1]) ; 
//             nodes[i] = node ; 
//             list.Add(node);           
//         }
        
//         //finding all the edges in a complement graph
//         for(int i = 0 ; i < n-1 ; i++)
//             for(int j = i+1 ; j < n ; j++)
//             {   
//                 edges[inedx ++ ] = new Edge(nodes[i] , nodes[j]) ;

//             }
        
//         //finding cost using kruskal algorithm
//         edges = edges.OrderBy( x => x.value).ToArray();
//         double cost = 0 ;

//         while(result.Count != n )
//             {
//                 var edge  =  edges.OrderBy(x=>x.value).FirstOrDefault();
//                 // 
//                 if(result.Contains(edge.head))
//                 {
//                     foreach (var t in result_edge)
//                     {
//                         if(t.head==edge.head || t.tail==edge.head)
//                         {
//                             cycles.Add(t.head);
//                             cycles.Add(t.tail);
//                         }
//                     }
//                     cycles.Add(edge.tail);
//                 }
//                 if(result.Contains(edge.tail))
//                 {
//                     foreach (var t in result_edge)
//                     {
//                         if(t.head==edge.tail || t.tail==edge.tail)
//                         {
//                             cycles.Add(t.head);
//                             cycles.Add(t.tail);
//                         }
//                     }
//                     cycles.Add(edge.head);

//                 }
//                 if(!(result.Contains(edge.head) && result.Contains(edge.tail)))
//                     cost+=edge.value;
//                 edge.value = double.MaxValue;    
//                 if(result.Contains(edge.head)&&result.Contains(edge.tail))
//                     continue;
//                 else if(result.Contains(edge.tail))
//                     result.Add(edge.head);
//                 else if(result.Contains(edge.head))
//                     result.Add(edge.tail);
//                 else
//                 {
//                 result.Add(edge.head);
//                 result.Add(edge.tail);
//                 }
//                 result_edge.Add(edge);
                

         
//             }
        
//         Console.WriteLine (cost) ; 

//     }
// }