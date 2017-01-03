using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackonacciMatrixRotations
{
    class Program
    {
        static void Main(string[] args) {
            string[] tokens_n = Console.ReadLine().Split(' ');
            long n = Convert.ToInt64(tokens_n[0]);
            long q = Convert.ToInt64(tokens_n[1]);

            
            
            for (long a0 = 0; a0 < q; a0++) {
                long angle = Convert.ToInt64(Console.ReadLine());
                char[][] arr = fillMatrix(n);
                

                long rotationCount = (angle % 360) / 90;


                if (rotationCount > 0) {
                    char[][] rotatedArr = arr.Select(a => a.ToArray()).ToArray();
                    Rotate(rotatedArr, rotationCount);
                    Console.WriteLine(CountDifference(arr, rotatedArr));
                }
                else
                    Console.WriteLine(0);
            }
            Console.Read();
        }
        
        static long getHackonacci(long n, Dictionary<long, long> memo) {
            if (n == 1)
                return 1;
            if (n == 2)
                return 2;
            if (n == 3)
                return 3;
            long t = n - 3;
            long sum = 0;
            long i = 1;
            while (n > t) {
                if (!memo.ContainsKey(n-1))
                    memo.Add(n-1, getHackonacci(n - 1, memo));
                sum = sum +  i * memo[n - 1];
                i++;
                n--;
            }

            return sum;
        }

        static char getChar(long x, long j, Dictionary<long, long> memo) {
            long num = (long)Math.Pow((x * j), 2);
            if (memo.ContainsKey(num))
                return memo[num] % 2 == 0 ? 'X' : 'Y';
            return (getHackonacci(num, memo) % 2 == 0 ? 'X' : 'Y');
        }

        static void Rotate(char[][] arr, long rotationCount) {
            long length = arr.Length;
            for (long i = 0; i < rotationCount; i++) {
                for (long layer = 0; layer < length / 2; layer++) {
                    long first = layer;
                    long last = length - 1 - layer;
                    for (long index = first; index < last; index++) {
                        long offset = index - first;
                        char top = arr[first][index];
                        arr[first][index] = arr[last - offset][first];
                        arr[last-offset][first] = arr[last][last-offset];
                        arr[last][last - offset] = arr[index][last];
                        arr[index][last] = top;
                    }
                }
            }
        }

        static long CountDifference(char[][] arr1, char[][] arr2) {
            long count = 0;
            for (long i = 0; i < arr1.Length; i++) {
                for (long j = 0; j < arr1.Length; j++) {
                    if (arr1[i][j] != arr2[i][j])
                        count++;
                }
            }
            return count;
        }

        static char[][] fillMatrix(long n) {
            char[][] arr = new char[n][];
            Dictionary<long, long> memo = new Dictionary<long, long>();
            for (long i = 1; i <= arr.Length; i++) {
                arr[i - 1] = new char[arr.Length];
                for(long j = 1; j<= arr.Length; j++) {
                    arr[i - 1][j - 1] = getChar(i, j, memo);
                }
            }

            return arr;
        }
        
    }
}
