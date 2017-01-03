using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tries
{
    class Program
    {
        static void Main(string[] args) {
            Contacts contacts = new Contacts();
            
            int n = Convert.ToInt32(Console.ReadLine());
            for (int a0 = 0; a0 < n; a0++) {
                string[] tokens_op = Console.ReadLine().Split(' ');
                string op = tokens_op[0];
                string contact = tokens_op[1];
                switch (op) {
                    case "add":
                        contacts.AddName(contact);
                        break;
                    case "find":
                        Console.WriteLine(contacts.Find(contact));
                        break;
                    default:
                        Console.WriteLine("Invalid Operation!");
                        break;
                        
                }
            }
            

            Console.ReadKey();
        }
    }
}
