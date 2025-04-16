using System.Security.Cryptography.X509Certificates;

namespace neetcode.ArraysAndHashing;
public static class ValidAnagram
{

    /// <summary>
    /// s : O(n + m)
    /// t: O(max(n,m) + n*log(n))
    /// </summary>
    public static bool IsAnagram1(string s, string t)
    {
        if (s.Length != t.Length) return false;

        var sa = s.ToCharArray();
        var ta = t.ToCharArray();
        Array.Sort(sa);
        Array.Sort(ta);

        return sa.SequenceEqual(ta);
    }

    /// <summary>
    /// s: O(n + m) 
    /// t: O(n)
    /// </summary>
    public static bool IsAnagram2(string s, string t)
    {
        if (s.Length != t.Length) return false;

        var dictCharCountS = new Dictionary<char, int>();
        var dictCharCountT = new Dictionary<char, int>();

        for (int i = 0; i < s.Length; i++)
        {
            dictCharCountS[s[i]] = dictCharCountS.GetValueOrDefault(s[i], 0) + 1;
            dictCharCountT[t[i]] = dictCharCountT.GetValueOrDefault(t[i], 0) + 1;
        }

        // Count to check same amount of keys. Since we have the same keys, just gotta check if they are all the same KVP.
        // Without count we would have to do except both ways.
        return dictCharCountS.Count == dictCharCountT.Count && !dictCharCountS.Except(dictCharCountT).Any();
    }

    /// <summary>
    /// s: O(n)
    /// t: O(n)
    /// </summary>
    public static bool IsAnagram3(string s, string t)
    {
        if (s.Length != t.Length) return false;

        var dictCharCountS = new Dictionary<char, int>();

        for (int i = 0; i < s.Length; i++)
        {
            dictCharCountS[s[i]] = dictCharCountS.GetValueOrDefault(s[i], 0) + 1;
            dictCharCountS[t[i]] = dictCharCountS.GetValueOrDefault(t[i], 0) - 1;
        }

        foreach(var count in dictCharCountS.Values) {
            if (count != 0) return false;
        }

        return true;
    }

    /// <summary>
    /// s: O(1)
    /// t: O(n)
    /// </summary>
    public static bool IsAnagram4(string s, string t)
    {
        if (s.Length != t.Length) return false;

        var charArray = new int[52];

        for (int i = 0; i < s.Length; i++)
        {
            charArray[getIndex(s[i])]++;
            charArray[getIndex(t[i])]--;
        }

        foreach (var i in charArray)
        {
            if(i != 0) return false;
        }

        return true;
    }

    private static int getIndex(char c)
    {
        if (char.IsLower(c)) return c - 'a';
        if (char.IsUpper(c)) return c - 'A' + 26;

        throw new ArgumentException("Input contains invalid characters.");
    }
}