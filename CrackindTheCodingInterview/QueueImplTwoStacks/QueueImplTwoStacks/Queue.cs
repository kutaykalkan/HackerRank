using System.Collections.Generic;

namespace QueueImplTwoStacks
{
    public class Queue<T>
    {
        private Stack<T> EnqueueStack = new Stack<T>();
        public Stack<T> DequeueStack = new Stack<T>();

        public void Enqueue(T item) {
            EnqueueStack.Push(item);
        }

        /// <summary>
        /// Removes an item from the head of the queue if there is at least one item.
        /// </summary>
        /// <returns></returns>
        public T Dequeue() {
            if (DequeueStack.Count > 0)
                return DequeueStack.Pop();
            while(EnqueueStack.Count > 0) {
                DequeueStack.Push(EnqueueStack.Pop());
            }
            return DequeueStack.Pop();
        }

        public T Peek() {
            if (DequeueStack.Count > 0)
                return DequeueStack.Peek();
            while (EnqueueStack.Count > 0) {
                DequeueStack.Push(EnqueueStack.Pop());
            }

            return DequeueStack.Peek();
        }
    }

    public class Queue
    {
        private Stack<int> EnqueueStack = new Stack<int>();
        public Stack<int> DequeueStack = new Stack<int>();

        public void Enqueue(int item) {
            if (DequeueStack.Count == 0) {
                EnqueueStack.Push(item);
            }
            else {
                while (DequeueStack.Count > 0) {
                    EnqueueStack.Push(DequeueStack.Pop());
                }
                EnqueueStack.Push(item);
            }
        }

        /// <summary>
        /// Removes an item from the head of the queue if there is at least one item.
        /// </summary>
        /// <returns></returns>
        public int Dequeue() {
            if (EnqueueStack.Count == 0) {
                if (DequeueStack.Count > 0)
                    return DequeueStack.Pop();
                else
                    return 0;
            }
            else {
                while (EnqueueStack.Count > 0) {
                    DequeueStack.Push(EnqueueStack.Pop());
                }
                if (DequeueStack.Count > 0)
                    return DequeueStack.Pop();
                else
                    return 0;
            }
        }

        public int Peek() {
            while (EnqueueStack.Count > 0) {
                DequeueStack.Push(EnqueueStack.Pop());
            }
            if (DequeueStack.Count > 0)
                return DequeueStack.Peek();
            else
                return 0;
        }
    }
}
