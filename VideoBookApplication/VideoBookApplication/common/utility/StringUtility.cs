using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

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
    }
}
