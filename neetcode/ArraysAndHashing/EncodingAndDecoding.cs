using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neetcode.ArraysAndHashing;
public static class EncodingAndDecoding
{
    public static string Encode(IList<string> strs)
    {
        StringBuilder sb = new StringBuilder();

        foreach (string str in strs)
            sb.Append($"{str.Length}|{str}");

        return sb.ToString();
    }

    public static List<string> Decode(string s)
    {
        List<string> decodedList = new();
        List<char> numericChars = new();
        for(int i = 0; i < s.Length; i++)
        {
            char c = s[i];
            if (char.IsDigit(c))
            {
                numericChars.Add(c);
                continue;
            } 
            
            if (c == '|')
            {
                int stringLength = int.Parse(new string(numericChars.ToArray()));
                numericChars.Clear();

                int startIndex = i + 1;
                var decodedStr = s.Substring(startIndex, stringLength);
                decodedList.Add(decodedStr);

                i = startIndex + stringLength - 1;
            }
        }

        return decodedList;
    }
}
