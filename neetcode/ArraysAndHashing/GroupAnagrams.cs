using System.Collections.Generic;

namespace neetcode.ArraysAndHashing;
public static class GroupAnagrams
{
    public static List<List<string>> DoGroupAnagrams(string[] strs)
    {
        var result = new List<List<string>>();
        Dictionary<string, List<string>> anagramDictionary = new();

        foreach(string str in strs)
        {
            var stringArray = str.ToCharArray();
            Array.Sort(stringArray);
            var sortedAnagram = new string(stringArray);

            if(anagramDictionary.TryGetValue(sortedAnagram, out var anagrams)){
                anagrams.Add(str);
                anagramDictionary[sortedAnagram] = anagrams;
            } else
            {
                anagramDictionary.Add(sortedAnagram, new List<string>() { str });
            }
        }

        result = anagramDictionary.Select(pair => pair.Value).ToList();

        return result;
    }
}
