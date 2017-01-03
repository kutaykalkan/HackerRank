using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pangrams
{
    class Program
    {
        static void Main(string[] args) {
            Console.WriteLine("Please Enter a String");
            string s = Console.ReadLine();
            Stopwatch watch = new Stopwatch();
            Solution1 s1 = new Solution1(s);
            Solution2 s2 = new Solution2(s);

            long elapsed1;
            long elapsed2;

            watch.Start();
            string res1 = s1.IsPangram();
            watch.Stop();
            elapsed1 = watch.ElapsedMilliseconds;

            watch.Reset();

            watch.Start();
            string res2 = s2.IsPangram();
            watch.Stop();
            elapsed2 = watch.ElapsedMilliseconds;

            Console.WriteLine(elapsed1 + "\n" + elapsed2);

            Console.Write(res1 + "\n" + res2);
            Console.Read();
        }
    }
}
