namespace neetcode.Backtracking;
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

    enum Outcome { Lose = -1, Draw = 0, Win = 1 }

    public static string Solve2(int n, int p, int m, int x)
    {
        // DFS over states (position, turn), with a stack set for cycle ⇒ Draw
        var onStack = new HashSet<(int pos, int turn)>(); // turn: 0=Steve, 1=Harvey

        Outcome Invert(Outcome o) => (Outcome)(-(int)o); // opponent's result → mine

        Outcome Dfs(int pos, int turn)
        {
            var state = (pos, turn);
            if (onStack.Contains(state)) return Outcome.Draw; // loop reachable now ⇒ draw
            onStack.Add(state);

            // enumerate all legal windows [L..R] (length m) that contain pos
            int Lmin = Math.Max(1, pos - (m - 1));
            int Lmax = Math.Min(pos, n - m + 1);

            Outcome best = Outcome.Lose; // maximize over my moves: Win > Draw > Lose
            bool anyMove = false;

            for (int L = Lmin; L <= Lmax; L++)
            {
                anyMove = true;
                int R = L + m - 1;
                int next = L + R - pos;          // coin mirrors within [L..R]

                // if I can land on x right now, I win immediately
                if (next == x) { onStack.Remove(state); return Outcome.Win; }

                // otherwise, evaluate opponent's outcome from child, then invert it to mine
                var child = Dfs(next, 1 - turn);
                var mine = Invert(child);

                if ((int)mine > (int)best) best = mine;
                if (best == Outcome.Win) { onStack.Remove(state); return Outcome.Win; } // prune
            }

            onStack.Remove(state);

            if (!anyMove) return Outcome.Lose;    // (edge case) no legal window
            return best;                          // Win>Draw>Lose chosen optimally
        }

        var outc = Dfs(p, 0); // Steve starts
        return outc == Outcome.Win ? "Steve"
             : outc == Outcome.Lose ? "Harvey"
             : "Draw";
    }

    //public static string Solve(int n, int p, int m, int x)
    //{
    //    // 1) Steve immediate win?
    //    if (InOne(n, m, p, x)) return "Steve";

    //    // If parity(x) != parity(p), step (2) can never hold; it's a Draw.
    //    if (((x ^ p) & 1) != 0) return "Draw";

    //    // 2) Does Harvey always have a one-move win after any Steve move?
    //    // Compute endpoints of N(p)
    //    int qminP = Qmin(n, m, p);
    //    int qmaxP = Qmax(n, m, p);

    //    // Tight intersection of Harvey's one-move neighborhoods over q in N(p)
    //    // reduces to checking the extremes qminP and qmaxP.
    //    bool harveyForces =
    //        InOne(n, m, qminP, x) &&
    //        InOne(n, m, qmaxP, x);

    //    return harveyForces ? "Harvey" : "Draw";
    //}

    //// Is x reachable from y in exactly one reversal?
    //private static bool InOne(int n, int m, int y, int x)
    //{
    //    int Lmin = Math.Max(1, y - (m - 1));
    //    int Lmax = Math.Min(y, n - m + 1);
    //    if (Lmin > Lmax) return false;

    //    int numer = x + y - (m - 1);
    //    if ((numer & 1) != 0) return false; // parity mismatch

    //    int L = numer / 2;
    //    return L >= Lmin && L <= Lmax;
    //}

    //// Endpoints of N(y)
    //private static int Qmin(int n, int m, int y)
    //{
    //    int Lmin = Math.Max(1, y - (m - 1));
    //    return 2 * Lmin + (m - 1) - y;
    //}
    //private static int Qmax(int n, int m, int y)
    //{
    //    int Lmax = Math.Min(y, n - m + 1);
    //    return 2 * Lmax + (m - 1) - y;
    //}
}