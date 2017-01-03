using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pangrams
{
    public class Solution2
    {
        private String s;

        public Solution2(String s) {
            this.s = s;
        }

        public string IsPangram() {
            s = s.ToLower();
            HashSet<char> alphabet = new HashSet<char>();
            int count = 0;
            string result = "";
            for (int i = 0; i < s.Length; i++) {
                if (!alphabet.Contains(s[i])) {
                    if (s[i] >= 'a' && s[i] <= 'z') {
                        alphabet.Add(s[i]);
                        count++;
                    }
                }
                if (count == 26) {
                    result = "pangram";
                    break;
                }
            }
            if (result.Length == 0)
                result = "not pangram";

            return result;
        }
    }
}
