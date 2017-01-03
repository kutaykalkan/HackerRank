using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerLandRadioTransmitters
{
    class Program
    {
        static void Main(String[] args) {
            string[] tokens_n = Console.ReadLine().Split(' ');
            int n = Convert.ToInt32(tokens_n[0]);
            int k = Convert.ToInt32(tokens_n[1]);
            string[] x_temp = Console.ReadLine().Split(' ');
            int[] arr = Array.ConvertAll(x_temp, Int32.Parse);

            Array.Sort(arr);
            int i = 0;
            int count = 1;
            int transmitter = arr[0];
            if (n > 1) {
                while (i < n) {
                    if (i == 0) {
                        int val = Array.BinarySearch(arr, arr[i] + k);
                        if (val >= 0) {
                            transmitter = val;
                            Console.WriteLine(transmitter);
                        }
                        else {
                            if (~val != n)
                                transmitter = arr[~val - 1];
                        }

                    }
                    else {
                        if (!IsInRange(arr[i], transmitter, k)) {
                            int val = Array.BinarySearch(arr, arr[i] + k);
                            if (val >= 0) {
                                transmitter = val;
                            }
                            else {
                                if (~val != n)
                                    transmitter = arr[~val - 1];
                                else
                                    transmitter = arr[i];
                            }
                            
                            count++;
                            Console.WriteLine(transmitter);
                        }
                    }
                    i++;
                }
            }
            Console.WriteLine(count);
            Console.Read();
        }

        static bool IsInRange(int a, int b, int k) {
            if (Math.Abs(a - b) <= k)
                return true;
            else
                return false;
        }
    }
}
