namespace neetcode.TwoPointers;
internal static class ValidPalindrome
{
    public static bool IsPalindrome(string s)
    {
        if (s is null)
            return false;

        int l = 0, r = s.Length - 1;


        while (r > l) 
        {
            if (s[l] != s[r])
                return false;
            r--;
            l++;
        }

        return true;
    }
}
