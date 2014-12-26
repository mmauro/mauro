using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoBookApplication.common.dao;
using VideoBookApplication.common.model.database;
using VideoBookApplication.common.utility;

namespace VideoBookApplication.common.controls
{
    public class StemmerControls
    {

        private StemmerDao dao = new StemmerDao();

        public Dictionary<string, string> getStemmerForced()
        {
            Dictionary<string, string> stemmers = new Dictionary<string, string>();

            try
            {
                List<StemmerForceModel> arrayStemmer = null;
                arrayStemmer = (List<StemmerForceModel>)dao.readAll();
                if (arrayStemmer != null && arrayStemmer.Count > 0)
                {
                    foreach (StemmerForceModel model in arrayStemmer)
                    {
                        stemmers.Add(model.word, model.stemmer);
                    }
                }

            }
            catch (VideoBookException e)
            {
                throw e;
            }

            return stemmers;
        }
    }
}
