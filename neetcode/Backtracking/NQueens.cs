namespace neetcode.Backtracking;
public static class NQueens
{
    public static List<List<string>> SolveNQueens(int n)
    {
        var result = new List<List<string>>();
        char[][] board = new char[n][];
        for (int i = 0; i < n; i++)
            board[i] = Enumerable.Repeat('.', n).ToArray();

        HashSet<int> occupiedCols = new();
        HashSet<int> posDiag = new();
        HashSet<int> negDiag = new();
        void SolveNQueensRecur(int row)
        {
            // N queens have been placed
            if (row == n)
            {
                var boardSnapshot = new List<string>();
                for (int i = 0; i < n; i++)
                    boardSnapshot.Add(new string(board[i]));

                result.Add(boardSnapshot);
                return;
            }

            for (int col = 0; col < n; col++) // for each of the columns on the current row, recursively check all solutions
            {
                // Bound Checks && occupation checks
                // Note: We always ensure row is unique by how we traverse the board so we don't need to check if there is only 1 queen per row.
                if (occupiedCols.Contains(col) 
                    || negDiag.Contains(row - col) 
                    || posDiag.Contains(row + col))
                    continue;

                board[row][col] = 'Q';
                occupiedCols.Add(col);
                posDiag.Add(row + col);
                negDiag.Add(row - col);

                SolveNQueensRecur(row + 1);

                board[row][col] = '.';
                occupiedCols.Remove(col);
                posDiag.Remove(row + col);
                negDiag.Remove(row - col);
            }
        }

        SolveNQueensRecur(0);

        return result;
    }
}
