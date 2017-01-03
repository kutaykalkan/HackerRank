using IsBinarySearchTree;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsBinarySearchTreeTests
{
    [TestFixture]
    public class BSTTest
    {
        [Test]
        public void Test1() {
            BstVerifier v = new BstVerifier();


            Node LeftLeft = new Node(1, null, null);
            Node LeftRight = new Node(3, null, null);
            Node Left = new Node(2, LeftLeft, LeftRight);
            Node RightLeft = new Node(11, null, null);
            Node RightRight = new Node(13, null, null);
            Node Right = new Node(12, RightLeft, RightRight);
            Node root = new Node(10, Left, Right);

            Assert.True(v.isBst(root));
        }

        [Test]
        public void Test2() {
            BstVerifier v = new BstVerifier();


            Node LeftLeft = new Node(1, null, null);
            Node LeftRight = new Node(4, null, null);
            Node Left = new Node(2, LeftLeft, LeftRight);
            Node RightLeft = new Node(11, null, null);
            Node RightRight = new Node(13, null, null);
            Node Right = new Node(12, RightLeft, RightRight);
            Node root = new Node(3, Left, Right);

            Assert.False(v.isBst(root));
        }

        [Test]
        public void Test3() {
            BstVerifier v = new BstVerifier();

            Node LeftLeft = new Node(2, null, null);
            Node LeftRight = new Node(4, null, null);
            Node Left = new Node(2, LeftLeft, LeftRight);
            Node RightLeft = new Node(11, null, null);
            Node RightRight = new Node(13, null, null);
            Node Right = new Node(12, RightLeft, RightRight);
            Node root = new Node(3, Left, Right);

            Assert.False(v.isBst(root));
        }

        [Test]
        public void Test4() {
            BstVerifier v = new BstVerifier();

            Node LeftLeft = new Node(1, null, null);
            Node LeftRight = new Node(3, null, null);
            Node Left = new Node(2, LeftLeft, LeftRight);
            Node RightLeft = new Node(11, null, null);
            Node RightRight = new Node(12, null, null);
            Node Right = new Node(12, RightLeft, RightRight);
            Node root = new Node(4, Left, Right);

            Assert.False(v.isBst(root));
        }

        [Test]
        public void Test5() {
            BstVerifier v = new BstVerifier();

            Node LeftLeft = new Node(1, null, null);
            Node LeftRight = new Node(3, null, null);
            Node Left = new Node(2, LeftLeft, LeftRight);
            Node RightLeft = new Node(4, null, null);
            Node RightRight = new Node(7, null, null);
            Node Right = new Node(6, RightLeft, RightRight);
            Node root = new Node(5, Left, Right);

            Assert.False(v.isBst(root));
        }
    }
}
