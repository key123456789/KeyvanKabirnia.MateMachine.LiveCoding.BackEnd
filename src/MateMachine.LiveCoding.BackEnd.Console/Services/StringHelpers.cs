using System.Security.Cryptography.X509Certificates;

namespace MateMachine.LiveCoding.BackEnd.Console.Services;

public class StringHelpers
{
    public static bool IsPalindromeWithLinq(string str)
    {
        return str == str.Reverse().Aggregate(string.Empty, (a, b) => a + b);
    }

    public static bool IsPalindromeNoLinq(string str)
    {
        int halfLength = str.Length / 2;
        string firstHalf = str[0..halfLength];
        //string secondHalf = Reverse(str)[0..halfLength];
        string secondHalf = Reverse(str[^halfLength..]);

        return firstHalf == secondHalf;
    }

    public static string SortByWordLengthWithLinq(string sentence)
    {
        List<string> wordArray = sentence.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
        wordArray = wordArray.OrderBy(w => w.Length).ToList();

        return string.Join(" ", wordArray);
    }

    public static string SortByWordLengthNoLinq(string sentence)
    {
        List<string> wordArray = sentence.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
        wordArray.Sort((a, b) => a.Length.CompareTo(b.Length));

        return string.Join(" ", wordArray);
    }

    public static bool AreIsomorphic(string str1, string str2)
    {
        Dictionary<char, char> char_cypher = new();

        bool result = false;

        if (str1.Length == str2.Length)
        {
            for (int i = 0; i < str1.Length; i++)
            {
                char c = str1[i];
                char s = str2[i];

                if (char_cypher.ContainsKey(c))
                {
                    if (char_cypher[c] != s)
                    {
                        result = false;
                        break;
                    }
                    else
                    {
                        result = true;
                    }
                }
                else
                {
                    char_cypher[c] = s;
                    result = true;
                }
            }
        }

        return result;
    }

    public static string Reverse(string s)
    {
        char[] charArray = s.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }
}
