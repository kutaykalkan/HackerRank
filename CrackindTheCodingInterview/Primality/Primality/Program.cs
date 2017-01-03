using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Primality
{
    class Program
    {
        static void Main(string[] args) {
            int p = Convert.ToInt32(Console.ReadLine());
            for (int a0 = 0; a0 < p; a0++) {
                int n = Convert.ToInt32(Console.ReadLine());
                bool prime = isPrime(n);
                Console.WriteLine(prime ? "Prime" : "Not prime");
            }
            Console.Read();
        }

        static bool isPrime(int n) {
            if (n == 2)
                return true;

            if (n == 0 || n == 1 || (n % 2 == 0))
                return false;
            
            bool isPrime = true;
            for (int i = 3; i <= Math.Sqrt(n); i = i + 2) {
                if (n % i == 0) {
                    isPrime = false;
                    break;
                }
            }
            return isPrime;
        }
    }
}
