namespace neetcode.Backtracking;

/// <summary>
/// You are playing a Flip Game with your friend.
/// 
/// You are given a string 'currentState' that contains only '+' and '-'. You and your friend
/// take turns to flip two consecutive ++ into --. The game ends when a person can no longer 
/// make a move, and therefore the other person will be the winner.
/// 
/// Return all possible states of the string 'currentState' after one valid move. 
/// You may return the answer in any order. If there is no valid move, return an empty list [].
/// 
/// e.g. 
/// input: currentState = "++++"
/// output: "--++","+--+","++--"
/// 
/// Did it with backtracking implementation instead of loop to get ready for flip game 2.
/// </summary>
public class FlipGame
{
    public List<string> Solve(string currentState)
    {
        var result = new List<string>();
        if (currentState.Length < 2)
            return result;


        void SolveRecur(int i)
        {
            if (i + 1 == currentState.Length) // Bounds check
                return;
            
            if(currentState[i] == '+' && currentState[i + 1] == '+')
            {
                var currentStateChars = currentState.ToCharArray();
                currentStateChars[i] = '-';
                currentStateChars[i - 1] = '-';
                result.Add(new string(currentStateChars));
            }

            SolveRecur(i + 1);
        }


        return result;
    }
}
