using System.Collections.Generic;
using System.Text;

namespace neetcode.ArraysAndHashing;
public static class GroupAnagrams
{
    public static List<List<string>> DoGroupAnagramsWithSort(string[] strs)
    {
        var result = new List<List<string>>();
        Dictionary<string, List<string>> anagramDictionary = new();

        foreach (string str in strs)
        {
            var stringArray = str.ToCharArray();
            Array.Sort(stringArray);
            var sortedAnagram = new string(stringArray);

            if (anagramDictionary.TryGetValue(sortedAnagram, out var anagrams))
            {
                anagrams.Add(str);
                anagramDictionary[sortedAnagram] = anagrams;
            }
            else
            {
                anagramDictionary.Add(sortedAnagram, new List<string>() { str });
            }
        }

        result = anagramDictionary.Select(pair => pair.Value).ToList();

        return result;
    }

    public static List<List<string>> DoGroupAnagramsWithCharacterMap(string[] strs)
    {
        Dictionary<string, List<string>> anagramDictionary = new();
        Span<int> tmpArrayCharMap = stackalloc int[26];
        foreach (string str in strs)
        {
            tmpArrayCharMap.Clear();

            foreach (char c in str)
                tmpArrayCharMap[c - 'a']++;

            // 25 Seperators + ~2 digit numbers ~75-100 character buffer to prevent sb recurring heap allocations. 
            var sb = new StringBuilder(100);
            for (int i = 0; i < 26; i++)
            {
                sb.Append(tmpArrayCharMap[i]);
                sb.Append('|');
            }
            string key = sb.ToString();

            if (!anagramDictionary.TryGetValue(key, out var group))
                anagramDictionary[key] = group = new List<string>();

            group.Add(str);
        }

        return anagramDictionary.Values.ToList();
    }
}
