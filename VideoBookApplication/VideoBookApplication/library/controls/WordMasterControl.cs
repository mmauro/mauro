using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoBookApplication.common.enums;
using VideoBookApplication.common.utility;
using VideoBookApplication.library.dao;
using VideoBookApplication.library.model.database;

namespace VideoBookApplication.library.controls
{
    public class WordMasterControl
    {

        private WordMasterCognomeDao cognomeDao = new WordMasterCognomeDao();

        public List<AuthorModel> getAuthorByFirstname(List<String> firstname)
        {
            List<AuthorModel> listAuthor = new List<AuthorModel>();
            if (firstname != null && firstname.Count > 0)
            {
                foreach (String cognome in firstname)
                {
                    WordMasterCognomeModel cModel = cognomeDao.readOne(cognome);
                    if (cModel != null && cModel.autori != null && cModel.autori.Count > 0)
                    {
                        //TODO: inserire in caso di necessità la lettura dei libri con idAutore
                        listAuthor.AddRange(cModel.autori);

                    }
                }
                
                

                return listAuthor;
            }
            else
            {
                throw new VideoBookException(ApplicationErrorType.INVALID_VALUE);
            }
        }
    }
}
