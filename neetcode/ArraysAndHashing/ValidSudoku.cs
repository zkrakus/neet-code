namespace neetcode.ArraysAndHashing;
public static class ValidSudoku
{
    public bool IsValidSudoku(char[][] board)
    {
        int rows = board.Length, cols = board[0].Length;
        char emptyCell = '.';

        bool IsValidSudo(int r, int c)
        {
            char curCell = board[r][c];
            if (curCell == emptyCell)
                return true;

            for (int cc = 0; cc < cols; cc++)
                if (board[r][cc] == curCell && c != cc) // Check if duplicate, but don't compare to self.
                    return false;

            for (int cr = 0; cr < cols; cr++)
                if (cr != r && board[cr][c] == curCell) // Check if duplicate, but don't compare to self. 
                    return false;

            int rowStart = r - r % 3, colStart = c - c % 3;
            for (int cc = colStart; cc < colStart + 3; cc++)
                for (int cr = rowStart; cr < rowStart + 3; cr++)
                    if ((cr, cc) != (r, c) && board[cr][cc] == curCell)
                        return false;

            return true;
        }

        foreach (var row in Enumerable.Range(0, rows))
            foreach (var col in Enumerable.Range(0, cols))
                if (!IsValidSudo(row, col))
                    return false;

        return true;
    }
}
