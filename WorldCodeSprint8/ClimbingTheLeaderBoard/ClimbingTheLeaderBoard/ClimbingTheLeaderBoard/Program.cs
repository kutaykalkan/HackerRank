using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimbingTheLeaderBoard
{
    class Program
    {
        static void Main(string[] args) {
            int n = Convert.ToInt32(Console.ReadLine());
            string[] scores_temp = Console.ReadLine().Split(' ');
            int[] scores = Array.ConvertAll(scores_temp, Int32.Parse);
            int m = Convert.ToInt32(Console.ReadLine());
            string[] alice_temp = Console.ReadLine().Split(' ');
            int[] alice = Array.ConvertAll(alice_temp, Int32.Parse);
            Dictionary<int, int> counts = new Dictionary<int, int>();

            
            counts.Add(0, 0);
            int k = 1;
            while (k < n) {
                if (scores[k] == scores[k - 1])
                    counts.Add(k, counts[k - 1] + 1);
                else
                    counts.Add(k, counts[k - 1]);
                k++;
            }


            for (int i = 0; i < m; i++) {
                int index = 0;
                if (alice[i] < scores[n - 1])
                    index = n - 1;
                else if (alice[i] <= scores[0] || alice[i] >= scores[n-1])
                    index = BinarySearchReversed(scores, alice[i], 0, n - 1);
                int result = index;
                if (result >= 0) {
                    if (scores[result] != alice[i])
                        result = result + 1 - counts[result] + 1;
                    else
                        result = result + 1 - counts[result];
                }
                else {
                    result = 1;
                }
                Console.WriteLine(result);
            }
            Console.Read();
        }

        static int BinarySearchReversed(int[] arr, int number, int start, int end) {
            while (start <= end) {
                int mid = (start + end) / 2;
                if (number == arr[mid])
                    return mid;
                else if (number < arr[mid])
                    start = mid + 1;
                else
                    end = mid - 1;
            }
            return start - 1;
        }
    }
}
