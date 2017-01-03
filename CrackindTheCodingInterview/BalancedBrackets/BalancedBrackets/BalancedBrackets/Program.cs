using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalancedBrackets
{
    class Program
    {
        static void Main(string[] args) {
            int t = Convert.ToInt32(Console.ReadLine());
            for (int a0 = 0; a0 < t; a0++) {
                string expression = Console.ReadLine();
                Console.WriteLine(IsBalanced(expression) ? "YES" : "NO");
            }
            Console.Read();
        }

        private static bool IsBalanced(string expression) {
            if (expression == null)
                return false;
            int length = expression.Length;
            if (length % 2 != 0)
                return false;
            Dictionary<char, int> left = new Dictionary<char, int>();
            left.Add('{', 1);
            left.Add('(', 2);
            left.Add('[', 3);
            Dictionary<char, int> right = new Dictionary<char, int>();
            right.Add('}', 1);
            right.Add(')', 2);
            right.Add(']', 3);
            Stack<char> stack = new Stack<char>();

            foreach (char c in expression) {
                if (left.ContainsKey(c))
                    stack.Push(c);
                else if (right.ContainsKey(c)) {
                    if (stack.Count > 0) {
                        if (left[stack.Peek()] == right[c])
                            stack.Pop();
                    }
                    else
                        return false;
                }
                else
                    return false;
            }

            if (stack.Count == 0)
                return true;
            else
                return false;
            
        }
    }
}
