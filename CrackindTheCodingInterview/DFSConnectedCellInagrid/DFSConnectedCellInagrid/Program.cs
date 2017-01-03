using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFSConnectedCellInagrid
{
    class Program
    {
        static void Main(string[] args) {
            int n = Convert.ToInt32(Console.ReadLine());
            int m = Convert.ToInt32(Console.ReadLine());
            int[][] grid = new int[n][];
            for (int grid_i = 0; grid_i < n; grid_i++) {
                string[] grid_temp = Console.ReadLine().Split(' ');
                grid[grid_i] = Array.ConvertAll(grid_temp, Int32.Parse);
            }

            Console.WriteLine(GetMaxRegionSize(grid, n, m));
            Console.Read();

        }

        static int GetMaxRegionSize(int[][] grid, int rowCount, int columnCount) {
            int maxCount = 0;
            for(int r = 0; r < rowCount; r++) {
                for(int c = 0; c < columnCount; c++) {
                    if (grid[r][c] == 1) {
                        int count = 0;
                        HashSet<string> isVisited = new HashSet<string>();
                        GetDFSCount(grid, r, c, rowCount, columnCount, ref count, isVisited);
                        if (count > maxCount)
                            maxCount = count;
                    }
                }
            }

            return maxCount;
        }

        static void GetDFSCount(int[][] grid, int row, int col, int rowCount, int columnCount, ref int count, HashSet<string> visited) {
            string key = row.ToString() + col.ToString();
            if (visited.Contains(key))
                return;

            visited.Add(key);
            count++;

            if (row + 1 < rowCount && grid[row + 1][col] == 1) {
                GetDFSCount(grid, row + 1, col, rowCount, columnCount, ref count, visited);
            }
            if (col + 1 < columnCount && grid[row][col + 1] == 1) {
                GetDFSCount(grid, row, col + 1, rowCount, columnCount, ref count, visited);
            }
            if (row - 1 < rowCount && row - 1 >= 0 && grid[row - 1][col] == 1) {
                GetDFSCount(grid, row - 1, col, rowCount, columnCount, ref count, visited);
            }
            if (col - 1 < columnCount && col - 1 >= 0 && grid[row][col - 1] == 1) {
                GetDFSCount(grid, row, col - 1, rowCount, columnCount, ref count, visited);
            }
            if (col + 1 < columnCount && row + 1 < rowCount && grid[row + 1][col + 1] == 1) {
                GetDFSCount(grid, row + 1, col + 1, rowCount, columnCount, ref count, visited);
            }
            if (col - 1 < columnCount && col - 1 >= 0 && row - 1 < rowCount && row - 1 >= 0 && grid[row - 1][col - 1] == 1) {
                GetDFSCount(grid, row - 1, col - 1, rowCount, columnCount, ref count, visited);
            }
            if (col - 1 < columnCount && col - 1 >= 0 && row + 1 < rowCount && grid[row + 1][col - 1] == 1) {
                GetDFSCount(grid, row + 1, col - 1, rowCount, columnCount, ref count, visited);
            }
            if (col + 1 < columnCount && row - 1 < rowCount && row - 1 >= 0 && grid[row - 1][col + 1] == 1) {
                GetDFSCount(grid, row - 1, col + 1, rowCount, columnCount, ref count, visited);
            }
        }
    }
}
