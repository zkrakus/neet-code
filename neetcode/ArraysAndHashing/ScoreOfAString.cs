using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neetcode.ArraysAndHashing;
public static class ScoreOfAString
{
    public static int ScoreOfString(string s)
    {
        if (s is null || s.Length < 2)
            return 0;

        char prev = s[0];
        int sum = 0;
        for(int i = 1; i < s.Length; i++)
        {
            var cur = s[i];
            sum += Math.Abs(cur - prev);
            prev = cur;
        }

        return sum;
    }
}
