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
public static class StoneGameIII
{
    public static string MaxAdvantage(int[] stoneValues)
    {
        int n = stoneValues.Length;
        int DfsMaxStoneAdvantage(int l)
        {
            if (l >= n)
                return 0;

            int myBestAdvantage = int.MinValue;
            int currentStoneSum = 0;
            for(int x = l; x < n && x < l + 3; x++)
            {
                currentStoneSum += stoneValues[x];
                int opponentAdvantage = DfsMaxStoneAdvantage(x + 1);
                int myAdvantage = currentStoneSum - opponentAdvantage;
                myBestAdvantage = Math.Max(myBestAdvantage, myAdvantage);
            }

            return myBestAdvantage;
        }

        int advantage = DfsMaxStoneAdvantage(0);

        if (advantage == 0)
            return "Draw";
        else if (advantage > 0)
            return "Alice";
        else
            return "Bob";
    }
}
