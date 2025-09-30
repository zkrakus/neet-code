namespace neetcode.Backtracking;

/// <summary>
/// Alice and Bob play a game with piles of stones.There are an even number of piles arranged in a row, 
/// and each pile has a positive integer number of stones piles[i].
/// 
/// The objective of the game is to end with the most stones. 
/// The total number of stones across all the piles is odd, so there are no ties.
/// Alice and Bob take turns, with Alice starting first. 
/// Each turn, a player takes the entire pile of stones either from the beginning or from the end of the row.
/// This continues until there are no more piles left, at which point the person with the most stones wins.
/// 
/// Assuming Alice and Bob play optimally, return true if Alice wins the game, or false if Bob wins.
/// 
/// ## Constraints ##
/// 2 <= piles.length <= 500
/// piles.length is even.
/// 1 <= piles[i] <= 500
/// sum(piles[i]) is odd.
/// 
/// </summary>

public static class StoneGame
{
    public static bool CanWinStoneGame(int[] piles)
    {

        Dictionary<(int, int), int> advantageMemo = new();
        int DfsRecursiveMaximumAdvantage(int l, int r)
        {
            if (l == r)
                return piles[l];

            if (advantageMemo.TryGetValue((l,r), out int value))
                return value;

            int leftAdvantage = piles[l] - DfsRecursiveMaximumAdvantage(l + 1, r);
            int rightAdvantage = piles[r] - DfsRecursiveMaximumAdvantage(l, r - 1);
            int maxAdvantage = Math.Max(leftAdvantage, rightAdvantage);

            advantageMemo[(l,r)] = maxAdvantage;

            return maxAdvantage;
        }

        return DfsRecursiveMaximumAdvantage(0, piles.Length - 1) > 0;
    }
}
