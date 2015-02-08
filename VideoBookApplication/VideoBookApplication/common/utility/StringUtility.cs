using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using VideoBookApplication.library.model.database;

namespace VideoBookApplication.common.utility
{
    class StringUtility
    {

        private static string alfaPattern = "[^àèìòù'A-Za-z0-9 ]";

        public static string addSpaceAfterSpecialChar(string word)
        {
            if (word != null && !word.Equals(""))
            {
                word = word.Replace("'", "' ");
                word = word.Replace(",", ", ");
            }
            return word;
        }

        public static string setAccent(string word)
        {
            if (word != null && !word.Equals(""))
            {
                word = word.Replace("e' ", "è ");
                word = word.Replace("a' ", "à ");
                word = word.Replace("i' ", "ì ");
                word = word.Replace("o' ", "ò ");
                word = word.Replace("u' ", "ù ");
            }
            return word;
        }

        public static string setItalianAccent(string word)
        {
            if (word != null && !word.Equals(""))
            {
                word = word.Replace("á", "à");
                word = word.Replace("é", "è");
                word = word.Replace("í", "ì");
                word = word.Replace("ó", "ò");
                word = word.Replace("ú", "ù");
                word = word.Replace("ç", "c");
            }
            return word;
        }

        public static string collapseDot(string word)
        {
            if (word != null && !word.Equals(""))
            {
                word = word.Replace(".", "");

            }
            return word;
        }

        public static string stripNotAlfaChar(string word)
        {
            if (word != null && !word.Equals(""))
            {
                Regex rgx = new Regex(alfaPattern);
                word = rgx.Replace(word, "");
            }
            return word;
        }

        public static string capitalize(string value)
        {
            return System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value);
        }

        public static String getYear(string year)
        {
            if (year != null && year.Length > 4)
            {
                year = year.Substring(0, 4);
            }
            return year;
        }

        public static int levenshteinDistance (string s, string t)
        {
            int n = s.Length;
            int m = t.Length;
            int[,] d = new int[n + 1, m + 1];

            // Step 1
            if (n == 0)
            {
                return m;
            }

            if (m == 0)
            {
                return n;
            }

            // Step 2
            for (int i = 0; i <= n; d[i, 0] = i++)
            {
            }

            for (int j = 0; j <= m; d[0, j] = j++)
            {
            }

            // Step 3
            for (int i = 1; i <= n; i++)
            {
                //Step 4
                for (int j = 1; j <= m; j++)
                {
                    // Step 5
                    int cost = (t[j - 1] == s[i - 1]) ? 0 : 1;

                    // Step 6
                    d[i, j] = Math.Min(
                        Math.Min(d[i - 1, j] + 1, d[i, j - 1] + 1),
                        d[i - 1, j - 1] + cost);
                }
            }
            // Step 7
            return d[n, m];
        }


    }
}
