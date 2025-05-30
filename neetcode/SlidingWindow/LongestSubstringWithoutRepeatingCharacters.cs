using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neetcode.SlidingWindow;
public static class LongestSubstringWithoutRepeatingCharacters
{
    public static int LengthOfLongestSubstring(string s)
    {
        if (s is null)
            return 0;

        int left = 0, right = 0, result = 0;
        HashSet<char> characterSet = new();
        while (right < s.Length)
        {
            if (!characterSet.Contains(s[right]))
            {
                characterSet.Add(s[right]);
                result = Math.Max(result, right - left + 1);
                right++;
            }
            else
            {
                characterSet.Remove(s[left]);
                left++;
            }
        }

        return result;
    }
}
