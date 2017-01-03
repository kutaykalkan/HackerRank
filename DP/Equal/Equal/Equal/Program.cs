using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equal
{
    class Program
    {
        static void Main(string[] args) {
            int t = Int32.Parse(Console.ReadLine());Array.BinarySearch
            for (int count = 0; count < t; count++) {
                int n = Int32.Parse(Console.ReadLine());
                int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), Int32.Parse);

                int totalCount = 0;
                Array.Sort(arr);
                while (true) {
                    int counter = 0;
                    Array.Sort(arr);
                    int max = arr[n - 1];
                    for (int i = 0; i < n; i++) {
                        int maxDiff = max - arr[i];
                        if (maxDiff == 0) {
                            counter++;
                            continue;
                        }
                        if (maxDiff > 2)
                            maxDiff = 5;
                        arr[i] = arr[i] + maxDiff;
                    }
                    if (counter == n)
                        break;
                    totalCount++;
                }
                Console.WriteLine(totalCount);
            }
            
        Console.Read();
        }
    }
}
