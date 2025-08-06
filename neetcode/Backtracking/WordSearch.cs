namespace neetcode.Backtracking;
public static class WordSearch
{
    // O(n * m * 4^word.len) 
    public static bool Exist(char[][] board, string word)
    {
        int rows = board.Length, cols = board[0].Length;
        var path = new HashSet<(int, int)>();

        bool dfs(int row, int col, int i)
        {
            if (i == word.Length)
            {
                return true;
            }

            if (
                (row < 0 || col < 0 || row >= rows || col >= cols) // Out of bounds
                || word[i] != board[row][col] // Not the character we are searching for.
                || !path.Contains((row, col))
                )
            {
                return false;
            }

            path.Add((row, col));
            var res = (dfs(row + 1, col, i + 1) ||
                dfs(row - 1, col, i + 1) ||
                dfs(row, col, i + 1) ||
                dfs(row, col + 1, i + 1) ||
                dfs(row, col - 1, i + 1));

            path.Remove((row, col));

            return res;
        }

        foreach (var row in Enumerable.Range(0, rows - 1))
            foreach (var col in Enumerable.Range(0, cols - 1))
                if (dfs(row, col, 0))
                    return true;

        return false;
    }
}
