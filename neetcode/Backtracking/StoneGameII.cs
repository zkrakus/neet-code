namespace neetcode.Backtracking;


/// <summary>
/// Alice and Bob continue their games with piles of stones. 
/// There are a number of piles arranged in a row, and each pile has a positive integer number of stones piles[x]. 
/// The objective of the game is to end with the most stones.
/// 
/// Alice and Bob take turns, with Alice starting first.
/// On each player's turn, that player can take all the stones in the first X remaining piles, where 1 <= X <= 2M. Then, we set M = max(M, X). Initially, M = 1.
/// 
/// The game continues until all the stones have been taken.
/// 
/// Assuming Alice and Bob play optimally, return the maximum number of stones Alice can get.
/// </summary>
public static class StoneGameII
{
    public static int MaxStones(int[] piles)
    {
        int n = piles.Length;

        var pilesPrefixSum = new int[n + 1];
        for(int i = 0; i < n; i++)
            pilesPrefixSum[i + 1] = pilesPrefixSum[i] + piles[i];

        Dictionary<(int l, int m), int> dfsMemo = new();
        int DfsMaxStonesFrom(int l, int m)
        {
            if (l >= n) // Nothing left to take, we are beyond the bounds of the piles.
                return 0;

            if (dfsMemo.TryGetValue((l, m), out int val)) // Already solved.
                return val;

            int remainingSum = piles.Skip(l).Sum();
            if (n - l <= 2 * m) // If we can select all remaining piles, when playing optimally we should do so.
                return piles.Skip(l).Sum();

            int opponentsWorstMove = int.MaxValue;
            for(int x = 1; x <= 2 * m; x++) // Apply minimax for all possible ... your best move is the worst move for the opponent.
            {
                int opponentsBestMove = DfsMaxStonesFrom(l + x, Math.Max(m, x));
                opponentsWorstMove = Math.Min(opponentsWorstMove, opponentsBestMove);
            }

            int yourOptimalMove = remainingSum - opponentsWorstMove; // Your optimal move is one in which the oppenent takes the least stones from the remaining sum.
            dfsMemo[(l, m)] = yourOptimalMove;

            return yourOptimalMove;
        }

        return DfsMaxStonesFrom(0, 1);
    }

    public static int MaxStonesMemoPrefixSum(int[] piles)
    {
        int n = piles.Length;
        var pilesPrefixSum = new int[n + 1];
        for (int i = 0; i < n; i++)
            pilesPrefixSum[i + 1] = pilesPrefixSum[i] + piles[i];

        Dictionary<(int l, int m), int> dfsMemo = new();
        int DfsMaxStonesFrom(int l, int m)
        {
            if (l >= n) // Nothing left to take, we are beyond the bounds of the piles.
                return 0;

            if (dfsMemo.TryGetValue((l, m), out int val)) // Already solved.
                return val;

            int remainingSum = piles.Skip(l).Sum();
            if (n - l <= 2 * m) // If we can select all remaining piles, when playing optimally we should do so.
                return piles.Skip(l).Sum();

            int opponentsWorstMove = int.MaxValue;
            for (int x = 1; x <= 2 * m; x++) // Apply minimax for all possible ... your best move is the worst move for the opponent.
            {
                int opponentsBestMove = DfsMaxStonesFrom(l + x, Math.Max(m, x));
                opponentsWorstMove = Math.Min(opponentsWorstMove, opponentsBestMove);
            }

            int yourOptimalMove = remainingSum - opponentsWorstMove; // Your optimal move is one in which the oppenent takes the least stones from the remaining sum.
            dfsMemo[(l, m)] = yourOptimalMove;

            return yourOptimalMove;
        }

        return DfsMaxStonesFrom(0, 1);
    }
}
