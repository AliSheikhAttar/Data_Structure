using System;
using System.Collections.Generic;
using System.Linq;
public class Program1
{
    public static int bracket_check(string S)
    {
        Stack<char> chars = new Stack<char>();
        List<int> chars_indexes = new List<int>();
        var open = ' ';
        for(int i=0;i<S.Length;i++)
        {
            if( (S[i]=='(') || (S[i]=='[') || (S[i]=='{') )
            {
                chars.Push(S[i]);
                chars_indexes.Add(i);
            }
            else if((S[i] == ')') || ( S[i] == ']') || (S[i] == '}') )
            {
                if(chars.Count() !=0)
                {
                    switch (S[i])
                    {
                        case ')':
                            open = '(';
                            break;
                        case '}':
                            open = '{';
                            break;
                        case ']':
                            open = '[';
                            break;
                    }
                    if(chars.Peek() == open)
                    {
                        chars.Pop();
                        chars_indexes.RemoveAt(chars_indexes.Count()-1);
                    }
                    else
                        return i+1;
                }
                else
                    return i+1;
            }
        }

        return chars_indexes.Count()!=0 ? chars_indexes.First()+1:-1;

    }
    public static void Main()
    {
        var input = Console.ReadLine();
        Console.WriteLine(bracket_check(input));
    }
}