using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitManipulation
{
    class Program
    {
        static void Main(string[] args) {
            int n = Convert.ToInt32(Console.ReadLine());
            string[] a_temp = Console.ReadLine().Split(' ');
            int[] a = Array.ConvertAll(a_temp, Int32.Parse);
            Console.WriteLine(findLonelyInt(a, n));
            Console.Read();
        }

        static int findLonelyInt(int[] arr, int n) {
            int sum = 0;
            for (int i = 0; i < n ; i++) {
                sum = sum ^ arr[i];
            }
            return sum;
        }
    }
}
