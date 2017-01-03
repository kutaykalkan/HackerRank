using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merge_Sort_Counting_Inversions
{
    class Program
    {
        static void Main(string[] args) {
            int[] arr = new int[] { 2,1,3,1,2 };
            Console.Write(CountInversions(arr));
            Console.Read();
        }

        static long CountInversions(int[] arr) {
            return MergeSort(arr, 0, arr.Length - 1, new int[arr.Length]); 
        }

        static long MergeSort(int[] arr, int left, int right, int[] result) {
            if (left >= right)
                return 0;
            int middle = (left + right) / 2;
            long count = 0;
            count = count + MergeSort(arr, left, middle, result);
            count = count + MergeSort(arr, middle + 1, right, result);
            count = count + Merge(arr, left, right);
            return count;
        }

        public static long Merge(int[] arr, int start, int end) {
            int mid = (start + end) / 2;
            int[] newArr = new int[end - start + 1];
            int curr = 0;
            int i = start;
            int j = mid + 1;
            long count = 0;
            while (i <= mid && j <= end) {
                if (arr[i] > arr[j]) {
                    newArr[curr++] = arr[j++];
                    count += mid - i + 1;
                }
                else
                    newArr[curr++] = arr[i++];
            }
            
            while (i <= mid) {
                newArr[curr++] = arr[i++];
            }

            while (j <= end) {
                newArr[curr++] = arr[j++];
            }

            Array.Copy(newArr, 0, arr, start, end - start + 1); 
            return count;
        }
    }
}
