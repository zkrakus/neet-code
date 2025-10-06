namespace neetcode.Backtracking;
public static class NQueens
{
    public static List<List<string>> SolveNQueens(int n)
    {
        var result = new List<List<string>>();
        char[][] board = new char[n][];
        for (int i = 0; i < n; i++)
            board[i] = Enumerable.Repeat('.', n).ToArray();

        HashSet<int> occupiedRows = new();
        HashSet<int> occupiedCols = new();
        HashSet<int> posDiag = new();
        HashSet<int> negDiag = new();
        void SolveNQueensRecur(int row, int col)
        {
            // Bound Checks && occupation checks
            if (row < 0 || row >= n || col < 0 || col >= n
                || occupiedRows.Contains(row) || occupiedCols.Contains(col) || negDiag.Contains(row - col) || posDiag.Contains(row + col))
                return;

            // If it's a valid move, and we are on the last row, we found a solution.
            if (row == n - 1)
            {
                var newBoard = new List<string>();
                for (int i = 0; i < n; i++)
                    newBoard[i] = new string(board[i]);

                result.Add(newBoard);
                return;
            }


            // for each of the columns on the current row, recursively check all solutions
            occupiedRows.Add(row);
            for (int i = 0; i < n; i++)
            {
                occupiedCols.Add(i);
                posDiag.Add(row + i);
                occupiedRows.Add(row - i);
                board[row][col] = 'i';

                SolveNQueensRecur(row + 1, 0);


                occupiedCols.Remove(i);
                occupiedRows.Remove(row);
                posDiag.Remove(row + i);
                occupiedRows.Remove(row - i);
                board[row][col] = '.';
            }
        }

        SolveNQueensRecur(0, 0);

        return result;
    }
}
