using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fibonacci
{
    class Program
    {
        static void Main(string[] args) {
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(FibonacciWithMemoization(n, new int[n + 1]));
            Console.Read();
        }

        public static int Fibonacci(int n) {
            if (n == 0)
                return 0;
            if (n == 1)
                return 1;

            return Fibonacci(n - 1) + Fibonacci(n - 2);
        }

        public static int FibonacciWithMemoization(int n, int[] memo) {
            if (n == 0)
                return 0;
            if (n == 1)
                return 1;
            if (memo[n] == 0)
                memo[n] = FibonacciWithMemoization(n - 1, memo) + FibonacciWithMemoization(n - 2, memo);
            return memo[n];
        }
    }
}
