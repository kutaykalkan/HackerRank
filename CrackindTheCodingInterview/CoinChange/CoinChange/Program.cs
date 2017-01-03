using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinChange
{
    class Program
    {
        static void Main(string[] args) {
            string[] tokens_n = Console.ReadLine().Split(' ');
            int n = Convert.ToInt32(tokens_n[0]);
            int m = Convert.ToInt32(tokens_n[1]);
            string[] coins_temp = Console.ReadLine().Split(' ');
            int[] coins = Array.ConvertAll(coins_temp, Int32.Parse);

            Console.WriteLine(CalculateCombinationDP(n, coins));
            Console.Read();
        }
        
        static int CalculateCombination(int target, int[] values, int[] memo) {
            
            if (target < 0)
                return 0;

            if (target == 0) {
                return 1; 
            }
                
            //int sum = 0;

            for (int i = 0; i < values.Length; i++) {
                if (memo[i] == 0)
                    memo[i] = CalculateCombination(target - values[i], values, memo);
                else//sum = sum + memo[i];
                    memo[i]++;
            }
            int sum = 0;
            foreach(int item in memo) {
                sum = sum + item;
            }

            return sum;
        }
        
        
        static long CalculateCombinationDP(int money, int[] coins) {
            long[] DP = new long[money + 1]; // O(N) space.
            DP[0] = (long)1;    // n == 0 case.
            for (int i = 0; i < coins.Length; i++) {
                int coin = coins[i];
                for (int j = coin; j < DP.Length; j++) {
                    // The only tricky step.
                    DP[j] += DP[j - coin];
                }
            }
            return DP[money];
        }
        
    }
}
