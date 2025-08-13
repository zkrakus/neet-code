using System.Runtime.ExceptionServices;

namespace neetcode.ArraysAndHashing;
public static class ValidSudoku
{
    public static bool IsValidSudoku(char[][] board)
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

    public static bool IsValidSudoku2(char[][] board)
    {
        for (int row = 0; row < 9; row++)
        {
            HashSet<char> seen = new();
            for (int c = 0; c < 9; c++)
            {
                if (board[row][c] == '.') continue;
                if (seen.Contains(board[row][c])) return false;
                seen.Add(board[row][c]);
            }
        }


        for (int col = 0; col < 9; col++)
        {
            HashSet<char> seen = new();
            for (int r = 0; r < 9; r++)
            {
                if (board[r][col] == '.') continue;
                if (seen.Contains(board[r][col])) return false;
                seen.Add(board[r][col]);
            }
        }

        for (int square = 0; square < 9; square++)
        {
            HashSet<char> seen = new();
            for (int m = 0; m < 3; m++)
            {
                for (int n = 0; n < 3; n++)
                {
                    int col = (((square / 3) * 3)) + m;
                    int row = (((square % 3) * 3)) + n;
                    if (board[row][col] == '.') continue;
                    if (seen.Contains(board[row][col])) return false;
                    seen.Add(board[row][col]);
                }
            }
        }

        return true;
    }
}
