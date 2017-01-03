using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunningMedian
{
    class Program
    {
        static void Main(string[] args) {
            int n = Convert.ToInt32(Console.ReadLine());
            int[] a = new int[n];
            for (int i = 0; i < n; i++) {
                string temp = Console.ReadLine();
                a[i] = int.Parse(temp);
            }

            MinHeap heap = new MinHeap();

            foreach(int item in a) {
                heap.Push(item);
                Console.WriteLine(heap.GetMedian().ToString("N1"));
            }

            Console.ReadKey();
        }
    }
}
