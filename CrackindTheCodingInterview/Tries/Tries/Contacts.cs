using System;
using System.Collections.Generic;

namespace Tries
{
    public class Contacts
    {
        private Node _head;

        public Contacts() {
            _head = null;
        }

        public void AddName(string name) {
            if (name.Length < 1)
                return;
            if (_head == null) {
                _head = new Node('*');
                Add(_head, name, 0, name.Length);
            }
            else {
                Tuple<Node, int> n = GetStartingNode(_head, name, 0, name.Length);
                Add(n.Item1, name, n.Item2, name.Length);
            }
            
        }

        public int Find(string s) {
            if (_head == null)
                return 0;
            if (s.Length < 1)
                return 0;

            Tuple<Node, int> t = GetStartingNode(_head, s, 0, s.Length);
            Node n = t.Item1;
            if (t.Item2 != s.Length)
                return 0;

            int count = 0;
            if (n.IsComplete)
                count++;

            return GetCount(n, ref count);
        }

        private int GetCount(Node start, ref int count) {
            if (start.Children.Count > 0) {
                foreach(KeyValuePair<char, Node> kvp in start.Children) {
                    if (kvp.Value.IsComplete == true)
                        count++;
                    GetCount(kvp.Value, ref count);
                }
            }

            return count;
        }

        private Tuple<Node, int> GetStartingNode(Node n, string s, int curIndex, int length) {
            if (curIndex != length) {
                char c = s[curIndex];
                if (n.Children.ContainsKey(c)) {
                    return GetStartingNode(n.Children[c], s, ++curIndex, length);
                }
                else
                    return Tuple.Create(n, curIndex);
            }
            else
                return Tuple.Create(n, curIndex);
        }

        private void Add(Node start, string s, int curIndex, int length) {
            Node n = new Node(s[curIndex]);
            if (!start.Children.ContainsKey(n.Value))
                start.Children.Add(n.Value, n);
            if (curIndex == length - 1) {
                start.Children[n.Value].IsComplete = true;
                return;
            }
            Add(n, s, ++curIndex, length);
        }

    }

    public class Node
    {
        private Dictionary<char, Node> _children;

        public Node(char value) {
            Value = value;
        }

        public char Value { get; set; }
        
        public Dictionary<char, Node> Children {
            get {
                if (_children == null)
                    _children = new Dictionary<char, Node>();
                return _children;
            }
            set {
                _children = value;
            }
        }
        
        public bool IsComplete { get; set; }
    }
}
