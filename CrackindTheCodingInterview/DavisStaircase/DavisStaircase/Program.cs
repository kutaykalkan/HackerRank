using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DavisStaircase
{
    class Program
    {
        static void Main(string[] args) {
            int s = Convert.ToInt32(Console.ReadLine());
            for (int a0 = 0; a0 < s; a0++) {
                int n = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine(CountPathsMemo(n));
            }
            
            Console.Read();
        }

        static int CountPaths(int n) {
            if (n < 0)
                return 0;
            else if (n == 0)
                return 1;

            return CountPaths(n - 3) + CountPaths(n - 2) + CountPaths(n - 1);
        }

        static int CountPathsMemo(int n) {
            return CountPathsMemo(n, new int[n + 1]);
        }

        static int CountPathsMemo(int n, int[] memo) {
            if (n < 0)
                return 0;
            else if (n == 0)
                return 1;
            if (memo[n] == 0)
                memo[n] = CountPathsMemo(n - 3, memo) + CountPathsMemo(n - 2, memo) + CountPathsMemo(n - 1, memo);
            return memo[n];
        }
    }
}
