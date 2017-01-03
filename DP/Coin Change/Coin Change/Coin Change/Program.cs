using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coin_Change
{
    class Program
    {
        static void Main(string[] args) {
            string[] line1 = Console.ReadLine().Split(' ');
            int n = Int32.Parse(line1[0]);
            int coinCount = Int32.Parse(line1[1]);

            int[] coins = Array.ConvertAll(Console.ReadLine().Split(' '), Int32.Parse);
            Console.WriteLine(GetNumberOfWays(coins, coinCount, n));
            Console.Read();
        }

        static long GetNumberOfWays(int[] coins, int coinCount, int n) {
            long[] memo = new long[n + 1];

            memo[0] = 1;

            for (int i = 0; i < coinCount; i++) {
                int coin = coins[i];
                for (int j = coin; j <= n; j++)
                    memo[j] = memo[j] + memo[j - coin];
            }

            return memo[n];
        }
    }
}
