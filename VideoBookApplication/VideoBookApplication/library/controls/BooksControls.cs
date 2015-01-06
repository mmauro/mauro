using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoBookApplication.common.enums;
using VideoBookApplication.common.utility;
using VideoBookApplication.library.model.database;
using VideoBookApplication.library.operations;

namespace VideoBookApplication.library.controls
{
    public class BooksControls
    {
        public BookInfoModel getBookInfoModel(string title, string cognome)
        {
            BookInfoModel model = null;

            if (title != null && !title.Trim().Equals(""))
            {
                if (cognome != null && !cognome.Trim().Equals(""))
                {
                    GoogleBooksWebService gbws = new GoogleBooksWebService();
                    gbws.getBookInfo(title, cognome);
                }
                else
                {
                    throw new VideoBookException(ApplicationErrorType.AUTHOR_NOT_FOUND);
                }
            }
            else
            {
                throw new VideoBookException(ApplicationErrorType.EMPTY_TITLE);
            }

            return model;
        }
    }
}
