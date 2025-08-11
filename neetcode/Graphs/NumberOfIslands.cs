using System.ComponentModel;

namespace neetcode.Graphs;
public class NumberOfIslands
{
    public static int NumIslands(char[][] grid)
    {
        if (grid is null || grid.Length == 0 || grid[0] is null || grid[0].Length == 0)
            return 0;

        int rows = grid.Length, cols = grid[0].Length;
        (int r, int c)[] dirs = { (1, 0), (-1, 0), (0, 1), (0, -1) };
        HashSet<(int r, int c)> visited = new();
        void BfsVisitIsland(int sr, int sc)
        {
            Queue<(int r, int c)> bfsQ = new();
            visited.Add((sr, sc));
            bfsQ.Enqueue((sr, sc));

            while (bfsQ.Count > 0)
            {
                (int cr, int cc) = bfsQ.Dequeue();
                foreach ((int dr, int dc) in dirs)
                {
                    int nr = cr + dr, nc = cc + dc;
                    if (nr < rows && nc < cols && nr >= 0 && nc >= 0 && // Grid bounds checks
                        !visited.Contains((nr, nc)) && grid[nr][nc] == '1' // New islands coordinate that hasn't been visited.
                        )
                    {
                        visited.Add((nr, nc));
                        bfsQ.Enqueue((nr, nc));
                    }
                }
            }
        }

        int islands = 0;
        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                if (grid[r][c] == '1' && !visited.Contains((r, c)))
                {
                    BfsVisitIsland(r, c);
                    islands++;
                }
            }
        }

        return islands;
    }


    // You can also practive depth first search using recursion.

    // You can also figure out and practice union find.
}












