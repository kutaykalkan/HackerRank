using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueImplTwoStacks
{
    class Program
    {
        static void Main(string[] args) {
            int q = int.Parse(Console.ReadLine());

            Queue<int> queue = new Queue<int>();

            for (int i = 0; i < q; i++) {
                string line = Console.ReadLine();
                if (line.Length < 1)
                    break;
                int command = int.Parse(line[0].ToString());
                switch (command) {
                    case 1:
                        if (line[1] != ' ' && line.Length < 3)
                            break;
                        int n;
                        bool result = int.TryParse(line.Split(' ')[1].ToString(), out n);
                        if (!result)
                            break;
                        queue.Enqueue(n);
                        break;
                    case 2:
                        queue.Dequeue();
                        break;
                    case 3:
                        int val = queue.Peek();
                        if (val == 0)
                            Console.WriteLine("No elements found!");
                        else
                            Console.WriteLine(val);
                        break;
                    default:
                        break;
                }

            }

            Console.Read();
        }
    }
}
