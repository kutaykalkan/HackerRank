using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anagrams
{
    class Program
    {
        static void Main(string[] args) {
            string a = Console.ReadLine();
            string b = Console.ReadLine();

            Dictionary<char, int> countsa = new Dictionary<char, int>();
            Dictionary<char, int> countsb = new Dictionary<char, int>();

            if (a.Length < 1 || b.Length < 1)
                return;

            for (int i = 0; i < a.Length; i++) {
                if (countsa.ContainsKey(a[i]))
                    countsa[a[i]]++;
                else
                    countsa.Add(a[i], 1);
            }

            for (int i = 0; i < b.Length; i++) {
                if (countsb.ContainsKey(b[i]))
                    countsb[b[i]]++;
                else
                    countsb.Add(b[i], 1);
            }

            int count = 0;

            foreach (KeyValuePair<char, int> kvp in countsa) {
                if (!countsb.ContainsKey(kvp.Key)) {
                    count = count + kvp.Value;
                }
                else
                    count = count + Math.Abs(kvp.Value - countsb[kvp.Key]);
            }

            foreach (KeyValuePair<char, int> kvp in countsb) {
                if (!countsa.ContainsKey(kvp.Key)) {
                    count = count + kvp.Value;
                }
                else
                    count = count + Math.Abs(kvp.Value - countsb[kvp.Key]);
            }

            Console.WriteLine(count);
            Console.ReadKey();
        }
    }
}
