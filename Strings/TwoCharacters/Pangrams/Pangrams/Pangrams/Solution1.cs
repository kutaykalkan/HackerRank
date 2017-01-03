using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pangrams
{
    public class Solution1
    {
        private String s;

        public Solution1(String s) {
            this.s = s;
        }

        public string IsPangram() {
            s = s.ToLower();
            string result;
            bool[] alphabet = new bool[26];

            int offSet = 'a';
            int count = 0;
            for (int i = 0; i < s.Length; i++) {
                int index = s[i] - offSet;
                if (index >= 0 && index <= 25) {
                    if (!alphabet[index]) {
                        alphabet[index] = true;
                        count++;
                    }
                }
                if (count == 26)
                    break;
            }

            if (count == 26)
                result = "pangram";
            else
                result = "not pangram";
            return result;
        }
    }
}
