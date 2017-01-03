using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DetectCycleLinkedList
{
    class Program
    {
        static void Main(string[] args) {
            /*
            LinkedList<int> ll = new LinkedList<int>();
            ll.AddFirst(1);
            Console.WriteLine(HasCycle(ll));
            Console.Read();
            */
            Node head = new Node();
            head.data = 1;
            Node n1 = new Node();
            n1.data = 1;
            Node n2 = new Node();
            n2.data = 1;
            head.next = n1;
            n1.next = n2;
            n2.next = head;

            Console.Write(HasCycle(head).ToString());
            Console.Read();
        }

        static bool HasCycle(LinkedList<int> ll) {
            if (ll.Count < 2)
                return false;

            LinkedListNode<int> last = ll.Last;
            if (last.Next == ll.First)
                return true;
            else return false;
        }

        static bool HasCycle(Node head) {
            if (head == null)
                return false;
            HashSet<Node> visited = new HashSet<Node>();
            visited.Add(head);
            Node cur = head;
            while (cur.next != null) {
                if (!visited.Contains(cur.next))
                    visited.Add(cur.next);
                else
                    return true;
                cur = cur.next;
            }
            return false;
        }
    }

    class Node
    {
        public int data;
        public Node next;
    }
}
