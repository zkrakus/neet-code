namespace neetcode.Backtracking;
public static class WordSearch
{
    // O(m * n * 4^word.len) 
    // S(word.len)
    public static bool Exists(char[][] board, string word)
    {
        if (board is null || board.Length == 0 || board[0].Length == 0 || word is null || word.Length == 0)
            return false;


        int rows = board.Length, cols = board[0].Length;
        HashSet<(int, int)> path = new();
        bool dfs(int row, int col, int i)
        {
            if (i == word.Length)
                return true;

            path.Add((row, col));
            if (row >= rows || col >= cols || row < 0 || col < 0 || // Bounds checks
                board[row][col] != word[i] || // Character comparison
                path.Contains((row, col))) // Check we aren't going back to a position we have been at already.
                return false;

            var res = dfs(row, col + 1, i + 1) || dfs(row, col - 1, i + 1) || dfs(row + 1, col, i + 1) || dfs(row - 1, col, i + 1); // Check other positions dfs style.
            path.Remove((row, col));

            return res;
        }

        //foreach (var row in Enumerable.Range(0, rows))
        //    foreach (var col in Enumerable.Range(0, cols))
        //        if (dfs(row, col, 0))
        //            return true;
        //return false;

        return Enumerable.Range(0, rows)
            .SelectMany((row) => Enumerable.Range(0, cols), (row, col) => (row, col)).
            Any(rc => dfs(rc.row, rc.col, 0));
    }
}
