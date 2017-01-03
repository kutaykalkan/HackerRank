using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunningMedian
{
    public class MinHeap { 
        private static int _capacity = 10;
        private int _size = 0;
        private int[] _arr = new int[_capacity];

        public void Push(int item) {
            EnsureCapacity();
            _arr[_size] = item;
            if (_size > 0)
                MoveUp(_size);
            _size++;
        }

        public int Peek() {
            if (_arr.Length > 0)
                return _arr[0];
            else
                return int.MinValue;
        }

        public int Pop() {
            if (_size < 1)
                return int.MinValue;
            int top = _arr[0];
            _arr[0] = _arr[_size - 1];
            _arr[_size - 1] = 0;
            _size--;
            MoveDown();
            return top;
        }

        public double GetMedian() {
            int size = _size;
            if (size == 0)
                return 0;
            else if (size == 1)
                return _arr[0];
            else {
                int[] tmpArr = new int[size];
                Array.Copy(_arr, tmpArr, size);
                int[] orderedArr = new int[size];

                for (int i = size, k = 0; i > 0; i--, k++) {
                    orderedArr[k] = Pop();
                }

                Array.Copy(tmpArr, _arr, size); //restore the original array.
                _size = size; // restore original size

                double median = 0;
                if (size % 2 == 1) {
                    median = Convert.ToDouble(orderedArr[(size - 1) / 2]);
                }
                else {
                    median = Convert.ToDouble(orderedArr[(size - 1) / 2] + orderedArr[((size - 1) / 2) + 1]) / 2;
                }

                return median;
            }
        }

        private void MoveUp(int index) {
            while (HasParentIndex(index)) {
                int parentIndex = GetParentIndex(index);
                if (_arr[parentIndex] > _arr[index]) {
                    Swap(parentIndex, index);
                    index = parentIndex;
                }
                else
                    break;
            }
        }

        private void MoveDown() {
            int topIndex = 0;
            
            while (HasLeftChild(topIndex)) {
                int leftChildIndex = GetLeftChildIndex(topIndex);
                int swapIndex = leftChildIndex;
                if (HasRightChild(topIndex) && _arr[GetRightChildIndex(topIndex)] < _arr[leftChildIndex])
                    swapIndex = GetRightChildIndex(topIndex);
                double top = _arr[topIndex];

                if (top > _arr[swapIndex]) {
                    Swap(topIndex, swapIndex);
                    topIndex = swapIndex;
                }
                else
                    break;
            }
        }

        private int GetParentIndex(int index) {
            return (index - 1) / 2;
        }

        private int GetLeftChildIndex(int index) {
            return index * 2 + 1;
        }

        private int GetRightChildIndex(int index) {
            return index * 2 + 2;
        }

        private bool HasLeftChild(int index) {
            return GetLeftChildIndex(index) < _size;
        }

        private bool HasRightChild(int index) {
            return GetRightChildIndex(index) < _size;
        }

        private bool HasParentIndex(int index) {
            return GetParentIndex(index) >= 0;
        }

        private void Swap(int index1, int index2) {
            int tmp = _arr[index1];
            _arr[index1] = _arr[index2];
            _arr[index2] = tmp;
        }

        private void EnsureCapacity() {
            if (_size == _capacity) {
                _capacity = _capacity * 2;
                Array.Resize(ref _arr, _capacity);
            }
        }


    }
}
