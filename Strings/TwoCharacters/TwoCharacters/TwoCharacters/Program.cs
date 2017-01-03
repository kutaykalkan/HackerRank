using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwoCharacters
{
    class Program
    {
        static void Main(string[] args) {
            string s = Console.ReadLine();

            HashSet<char> characters = new HashSet<char>();
            for (int i = 0; i < s.Length; i++) {
                if (!characters.Contains(s[i]))
                    characters.Add(s[i]);
            }
            List<char> chars = characters.ToList();

            String finalResult = "";
            for (int i = 0; i < chars.Count; i++) {
                for (int k = 0; k < chars.Count; k++) {
                    if (i == k)
                        continue;
                    StringBuilder result = new StringBuilder();
                    for (int n = 0; n < s.Length; n++) {
                        if (s[n] == chars[i] || s[n] == chars[k]) {
                            result.Append(s[n]);
                        }
                    }
                    
                    bool isAlternating = true;
                    if (result.Length > 1) {
                        char previous = result[0];
                        for (int m = 1; m < result.Length; m++) {
                            if (result[m] != previous)
                                previous = result[m];
                            else {
                                isAlternating = false;
                                break;
                            }
                        }
                    }
                    if (isAlternating) {
                        if (result.Length > finalResult.Length)
                            finalResult = result.ToString();
                    }
                }
            }

            Console.WriteLine(finalResult.Length);
            Console.Read();
        }
    }
}
