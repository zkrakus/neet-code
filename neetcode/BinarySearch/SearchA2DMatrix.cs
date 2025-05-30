using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neetcode.BinarySearch;
public static class SearchA2DMatrix
{
    public static bool SearchMatrix(int[][] matrix, int target)
    {
        if (matrix.Length == 0)
            return false;

        int i = 0, j = matrix.Length - 1;
        while (i <= j)
        {
            int mid = i + (j - i) / 2;
            if (target >= matrix[mid][0] && target <= matrix[mid][^1])
            {
                int k = 0, m = matrix[mid].Length - 1;
                while (k <= m)
                {
                    int mid2 = k + (m - k) / 2;
                    if (target == matrix[mid][mid2])
                    {
                        return true;
                    }
                    else if (target < matrix[mid][mid2])
                    {
                        m = mid2 - 1;
                    }
                    else if (target > matrix[mid][mid2])
                    {
                        k = mid2 + 1;
                    }
                }


            }
            else if (target < matrix[mid][0])
            {
                j = mid - 1;
            }
            else if (target > matrix[mid][^1])
            {
                i = mid + 1;
            }
        }

        return false;
    }

    public static bool SearchMatrixFlattened(int[][] matrix, int target)
    {
        if (matrix == null || matrix.Length == 0)
            return false;

        int rows = matrix.Length;
        int cols = matrix[0].Length;
        int left = 0;
        int right = rows * cols - 1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            int value = matrix[mid / cols][mid % cols]; // mid / cols givs us the row, mid % cols gives us the remainer which is the column.

            if (value == target)
                return true;
            if (value < target)
                left = mid + 1;
            if (value > target)
                right = mid - 1;
        }

        return false;
    }
}
