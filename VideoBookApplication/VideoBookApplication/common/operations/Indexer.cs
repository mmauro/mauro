using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using VideoBookApplication.common.controls;
using VideoBookApplication.common.dao;
using VideoBookApplication.common.enums;
using VideoBookApplication.common.utility;

namespace VideoBookApplication.common.operations
{
    class Indexer
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private IndexerType indexerType;
        public string value { get; private set; }

        public List<String> words { get; private set; }

        public ApplicationErrorType status { get; private set; }

        private List<String> reserved = new List<string>();
        private ReservedControl controls = new ReservedControl();
        private Stemmer stemmer;

        public Indexer(string value, IndexerType indexerType)
        {
            status = ApplicationErrorType.SUCCESS;
            this.indexerType = indexerType;
            this.value = value;

            words = new List<string>();

            if (this.indexerType.reserved != null)
            {
                try
                {
                    reserved = controls.readReserved(this.indexerType.reserved);
                    log.Info("Reserved Load: " + reserved.Count);
                }
                catch (VideoBookException e)
                {
                    status = ApplicationErrorType.LOAD_RESERVED_ERROR;
                }
            }

            if (status == ApplicationErrorType.SUCCESS && this.indexerType.useStemmer)
            {
                stemmer = new Stemmer();
                status = stemmer.status;
            }

            if (status == ApplicationErrorType.SUCCESS && this.value != null && !value.Equals(""))
            {
                string wordClean = cleanWords(value);
                if (wordClean!= null && !wordClean.Equals(""))
                {
                    //Split delle parole
                    Regex rgx = new Regex("\\s+");
                    String[] singleWords = rgx.Split(wordClean);
                    if (singleWords != null && singleWords.Length > 0)
                    {
                        for (int i = 0; i < singleWords.Length; i++)
                        {
                            if (singleWords[i] != null && !singleWords[i].Trim().Equals(""))
                            {
                                string parola = singleWords[i];
                                if (!reserved.Contains(parola))
                                {
                                    if (parola.Length > 1)
                                    {
                                        if (this.indexerType.useStemmer)
                                        {
                                            parola = stemmer.stem(parola);
                                        }
                                        if (!words.Contains(parola))
                                        {
                                            words.Add(parola);
                                        }
                                    }
                                    else
                                    {
                                        //Con Parole di una sola lettera non uso lo stemmer
                                        if (this.indexerType.singleWordSave && !words.Contains(parola))
                                        {
                                            words.Add(parola);
                                        }
                                    }
                                }
                            }
                        }

                        if (words.Count <= 0)
                        {
                            status = ApplicationErrorType.NO_INDEX;
                        }

                    }
                    else
                    {
                        status = ApplicationErrorType.INDEXER_PREPARE_ERROR;
                    }
                }
                else
                {
                    status = ApplicationErrorType.INDEXER_PREPARE_ERROR;
                }
            }
            else
            {
                status = ApplicationErrorType.INDEXER_INVALID_VALUE;
            }

        }

        private string cleanWords(string words)
        {
            // 1 - Tutto in minuscolo
            string w = words.ToLower();

            // 2 - Aggiungo spazio dopo Apice
            w = StringUtility.addSpaceAfterSpecialChar(w);

            // 3 - Trasformazione di accenti
            w = StringUtility.setAccent(w);

            // 4 - Trasformazione accenti italiani
            w = StringUtility.setItalianAccent(w);

            // 5 - Eliminazione caratteri speciali
            w = StringUtility.stripNotAlfaChar(w);

            // 6 - Trim
            w = w.Trim();

            return w;
        }


    }
}
