using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsBinarySearchTree
{
    public class BstVerifier
    {
        private int? _previous;
        private bool _result = true;
        public bool isBst(Node root) {
            if (root == null)
                return false;

            return TraverseInOrder(root);
        }

        private bool TraverseInOrder(Node root) {
            if (root.left != null) {
                if (root.data <= root.left.data)
                    _result = false;
                if (_result)
                    TraverseInOrder(root.left);
                if (!AddData(root.data))
                    _result = false;

            }
            if (root.right != null) {
                if (root.data >= root.right.data)
                    _result = false;
                if (_result)
                    TraverseInOrder(root.right);
            }
            else {//leaf node.
                if (!AddData(root.data)) 
                    _result = false;
            }

            return _result;
        }
        


        private bool AddData(int i) {
            if (!_result)
                return false;
            if (_previous != null) {
                if (i <= _previous)
                    return false;
            }
            
            _previous = i;
            return true;
        }
    }

    public class Node
    {
        public Node(int data, Node left, Node right) {
            this.data = data;
            this.left = left;
            this.right = right;
        }
        public int data { get; set; }
        public Node left { get; set; }
        public Node right { get; set; }
    }
}
