using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;

namespace neetcode.Stack;
public static class GenerateParenthesis
{
    public static List<string> GenerateParenthesisBruteForce(int n)
    {
        List<string> res = new();

        bool ValidParenthesisString(string s)
        {
            int open = 0;
            foreach (char c in s)
            {
                open += open == '(' ? 1 : -1;
                if (open < 0) return false;
            }

            return open == 0;
        }

        void DfsGenerateValidParenthesis(string s)
        {
            if (s.Length == n * 2)
            {
                if (ValidParenthesisString(s))
                {
                    res.Add(s);
                    return;
                }
            }
            DfsGenerateValidParenthesis(s + '(');
            DfsGenerateValidParenthesis(s + ')');
        }

        DfsGenerateValidParenthesis("");
        return res;
    }


















    }
