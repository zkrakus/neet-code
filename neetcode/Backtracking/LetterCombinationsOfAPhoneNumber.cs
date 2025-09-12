namespace neetcode.Backtracking;
public static class LetterCombinationsOfAPhoneNumber
{
    private static Dictionary<char, char[]> digitToCharMap = new() { 
        { '2', new char[] { 'a', 'b', 'c' } },
        { '3', new char[] { 'd', 'e', 'f' } },
        { '4', new char[] { 'g', 'h', 'i' } },
        { '5', new char[] { 'j', 'k', 'l' } },
        { '6', new char[] { 'm', 'n', 'o' } },
        { '7', new char[] { 'p', 'q', 'r', 's' } },
        { '8', new char[] { 't', 'u', 'v' } },
        { '9', new char[] { 'w', 'x', 'y', 'z' } },
    };

    public static List<string> LetterCombinations(string digits)
    {
        if (digits is null || digits.Length == 0)
            return new();

        var result = new List<string>();
        var letters = "";
        void DfsLetterCombinations(int i)
        {
            if (i == digits.Length)
            {
                result.Add(letters);
                return;
            }

            foreach (char c in digitToCharMap[digits[i]])
            {
                letters += c;
                DfsLetterCombinations(i + 1);
                letters = letters[..^1];
            }
        }

        DfsLetterCombinations(0);

        return result;
    }
}
