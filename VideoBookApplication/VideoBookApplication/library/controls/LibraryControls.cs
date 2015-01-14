using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoBookApplication.common.enums;
using VideoBookApplication.common.model;
using VideoBookApplication.common.utility;
using VideoBookApplication.library.dao;

namespace VideoBookApplication.library.controls
{
    public class LibraryControls
    {
        public ApplicationErrorType write(GlobalApplicationObject globalObject)
        {
            ApplicationErrorType status = ApplicationErrorType.SUCCESS;
            if (globalObject.libraryObject.libraryInput.autore != null)
            {
                if (globalObject.libraryObject.libraryInput.libri != null && globalObject.libraryObject.libraryInput.libri.Count > 0)
                {
                    try
                    {
                        LibraryDao dao = new LibraryDao();
                        dao.writeInformations(globalObject.libraryObject.libraryInput.autore, globalObject.libraryObject.libraryInput.libri);
                    }
                    catch (VideoBookException e)
                    {
                        status = e.errorType;
                    }
                }
                else
                {
                    status = ApplicationErrorType.AUTHOR_NOT_FOUND;
                }
            }
            else
            {
                status = ApplicationErrorType.EMPTY_BOOKS;
            }

            return status;
        }
    }
}
