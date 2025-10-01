namespace neetcode.Backtracking;

/// <summary>
/// Alice and Bob continue their games with piles of stones. 
/// There are several stones arranged in a row, and each stone has an associated value which is an integer given in the array stoneValue.
/// Alice and Bob take turns, with Alice starting first.On each player's turn, that player can take 1, 2, or 3 stones from the first remaining stones in the row.
/// 
/// The score of each player is the sum of the values of the stones taken.The score of each player is 0 initially.
/// 
/// The objective of the game is to end with the highest score, and the winner is the player with the highest score and there could be a tie. The game continues until all the stones have been taken.
/// 
/// Assume Alice and Bob play optimally.
/// 
/// Return "Alice" if Alice will win, "Bob" if Bob will win, or "Tie" if they will end the game with the same score.
/// </summary>
public static class GoldCoinGame
{
    public static string Solve(int n, int p, int m, int x)
    {
        // If Steve has no legal move, he loses immediately
        var nexts = NextPositions(n, m, p);
        if (nexts.Count == 0) return "Harvey";

        // 1) Immediate win?
        if (CanReachInOne(n, m, p, x)) return "Steve";

        // 2) If EVERY Steve move lets Harvey win in 1, Harvey forces a win.
        bool harveyForces = true;
        foreach (int q in nexts)
        {
            if (!CanReachInOne(n, m, q, x)) { harveyForces = false; break; }
        }
        return harveyForces ? "Harvey" : "Draw";
    }

    // Check if from position 'y' you can reach 'x' in ONE legal reversal.
    // Window [L, R] of length m must contain y; after reversing, coin goes to (L+R - y).
    private static bool CanReachInOne(int n, int m, int y, int x)
    {
        int Lmin = Math.Max(1, y - (m - 1));
        int Lmax = Math.Min(y, n - m + 1);
        if (Lmin > Lmax) return false; // no legal window

        // Solve x = (2L + m - 1) - y  =>  L = (x + y - (m - 1)) / 2
        int numer = x + y - (m - 1);
        if ((numer & 1) != 0) return false;          // parity mismatch
        int L = numer / 2;
        return L >= Lmin && L <= Lmax;
    }

    // All positions reachable from 'y' in ONE move (at most m, clamped at edges).
    private static List<int> NextPositions(int n, int m, int y)
    {
        var list = new List<int>();
        int Lmin = Math.Max(1, y - (m - 1));
        int Lmax = Math.Min(y, n - m + 1);
        for (int L = Lmin; L <= Lmax; L++)
        {
            int R = L + m - 1;
            list.Add(L + R - y); // mirror of y in [L..R]
        }
        return list;
    }
}
