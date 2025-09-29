namespace neetcode.Backtracking;

/// <summary>
/// You are playing the following Flip Game with your friend: Given a string that contains
/// only these two characters: + and -, you and your friend take turns to flip two
/// consecutive ++ into --. The game ends when a person can no longer make a move and therefore
/// the other person will be the winner.
/// 
/// Write a function to determine if the starting player can guarantee a win.
/// </summary>
public static class FlipGame2
{
    public static bool CanWinBruteForce(string s)
    {
        for (int i = 0; i + 1 < s.Length; i++)
        {
            if (s[i] == '+' && s[i + 1] == '+')
            {
                var charArr = s.ToCharArray();
                charArr[i] = charArr[i + 1] = '-';

                if (!CanWinBruteForce(new string(charArr)))
                    return true;
            }
        }

        return false;
    }

    public static bool CanWinMemoized(string s)
    {
        var memo = new Dictionary<string, bool>();
        bool CanWinMemoizedRecur(string s)
        {
            if(memo.TryGetValue(s, out bool val))
                return val;

            for (int i = 0; i + 1 < s.Length; i++)
            {
                if (s[i] == '+' && s[i + 1] == '+')
                {
                    var charArr = s.ToCharArray();
                    charArr[i] = charArr[i + 1] = '-';

                    if (!CanWinMemoizedRecur(new string(charArr)))
                        return memo[s] = true;
                }
            }

            return memo[s] = false;
        }

        return CanWinMemoizedRecur(s);
    }
}
