using Iveonik.Stemmers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoBookApplication.common.controls;
using VideoBookApplication.common.enums;
using VideoBookApplication.common.utility;

namespace VideoBookApplication.common.operations
{
    public class Stemmer
    {

        private static Boolean isLoadStemmer = false;
        public ApplicationErrorType status { get; private set; }

        private Dictionary<string, string> forceStemmerArray;

        public Stemmer()
        {
            status = ApplicationErrorType.SUCCESS;
            if (!isLoadStemmer)
            {
                try
                {
                    StemmerControls controls = new StemmerControls();
                    forceStemmerArray = new Dictionary<string, string>();
                    forceStemmerArray = controls.getStemmerForced();
                    isLoadStemmer = true;
                }
                catch (VideoBookException e)
                {
                    status = ApplicationErrorType.LOAD_STEMMER_ERROR;
                    isLoadStemmer = false;
                } 
            }
        }

        public string stemWord(string word)
        {
            if (word != null && !word.Equals(""))
            {
                ItalianStemmer stemmer = new ItalianStemmer();
                string wordStem = stemmer.Stem(word);
                if (wordStem != null && !wordStem.Equals(""))
                {
                    return wordStem;
                }
                else
                {
                    return word;
                }
            }
            else
            {
                return "";
            }
        }
    }
}
