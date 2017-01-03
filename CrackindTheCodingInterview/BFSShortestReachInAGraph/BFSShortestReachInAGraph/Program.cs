using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFSShortestReachInAGraph
{
    class Program
    {
        const int DISTANCE = 6;
        static void Main(string[] args) {
            int q = int.Parse(Console.ReadLine());
            for (int i = 0; i < q; i++) {
                string[] pieces = Console.ReadLine().Split(' ');
                int n = int.Parse(pieces[0]);
                int m = int.Parse(pieces[1]);
                Node[] Nodes = new Node[n + 1];
                for (int i2 = 1; i2 <= n; i2++) {
                    Nodes[i2] = new Node(i2);
                }
                for (int i3 = 0; i3 < m; i3++) {
                    string[] pieces2 = Console.ReadLine().Split(' ');
                    int start = int.Parse(pieces2[0]);
                    int end = int.Parse(pieces2[1]);

                    Nodes[start].AdjList.Add(Nodes[end]);
                    Nodes[end].AdjList.Add(Nodes[start]);
                }

                int startNodeIndex = int.Parse(Console.ReadLine());
                Node first = Nodes[startNodeIndex];
                int[] distances = GetDistances(first, n);
                StringBuilder s = new StringBuilder();
                for (int i4 = 1; i4 <= n; i4++) {
                    if (startNodeIndex != i4)
                        s.Append((distances[i4] == 0 ? -1 : distances[i4]) + " ");
                }
                Console.WriteLine(s);
            }

            Console.Read();
        }

        static int[] GetDistances(Node start, int nodeCount) {
            Queue<Node> queue = new Queue<Node>();
            bool[] isVisited = new bool[nodeCount + 1];
            int[] distances = new int[nodeCount + 1];
            queue.Enqueue(start);

            while(queue.Count > 0) {
                Node n = queue.Dequeue();
                if (isVisited[n.Value])
                    continue;
                isVisited[n.Value] = true;
                
                foreach (Node node in n.AdjList) {
                    if (node.Value == start.Value)
                        continue;
                    int newValue = distances[n.Value] + DISTANCE;
                    if (distances[node.Value] == 0)
                        distances[node.Value] = newValue;
                    else {
                        distances[node.Value] = (newValue < distances[node.Value] ? newValue : distances[node.Value]);
                    }
                        
                    queue.Enqueue(node);
                }
            }

            return distances;
        }
    }

    class Node
    {
        public int Value { get; set; }
        public List<Node> AdjList { get; set; } = new List<Node>();
        public Node(int value) {
            Value = value;
        }
    }
}
