using System.Collections.Generic;

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
        foreach (string str in strs)
        {
            var tmpArrayCharMap = new int[26];
            foreach (char c in str)
                tmpArrayCharMap[c - 'a']++;

            // Use string builder instead of join since join continually rebuilds and recopies strings instead of doing it once.
            var key = string.Join("|", tmpArrayCharMap);
            if (anagramDictionary.TryGetValue(key, out var anagrams))
                anagrams.Add(str);
            else
                anagramDictionary.Add(key, new List<string>() { str });
        }

        return anagramDictionary.Values.ToList();
    }
}
