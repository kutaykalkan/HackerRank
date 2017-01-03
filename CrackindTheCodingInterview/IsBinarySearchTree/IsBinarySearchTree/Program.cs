using System;
using System.Collections.Generic;

namespace IsBinarySearchTree
{
    class Program
    {
        static void Main(string[] args) {
            BstVerifier v = new BstVerifier();
            
            
            Node LeftLeft = new Node(1, null, null);
            Node LeftRight = new Node(3, null, null);
            Node Left = new Node(2, LeftLeft, LeftRight);
            Node RightLeft = new Node(11, null, null);
            Node RightRight = new Node(13, null, null);
            Node Right = new Node(12, RightLeft, RightRight);
            Node main = new Node(10, Left, Right);

            Console.WriteLine(v.isBst(main));
            Console.Read();
        }
    }
}
