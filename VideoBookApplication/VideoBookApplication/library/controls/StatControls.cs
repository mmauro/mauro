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
    public class StatControls
    {
        public ApplicationErrorType getStatistics(ref GlobalApplicationObject globalObject)
        {
            ApplicationErrorType status = ApplicationErrorType.SUCCESS;
            BookDao bDao = new BookDao();
            try
            {
                globalObject.libraryObject.statistiche.numLibri = bDao.countElement();
                globalObject.libraryObject.statistiche.ebook = bDao.countElement(true);
                globalObject.libraryObject.statistiche.numLibriCarta = globalObject.libraryObject.statistiche.numLibri - globalObject.libraryObject.statistiche.ebook;
            }
            catch (VideoBookException e)
            {
                status = e.errorType;
            }

            return status;
        }
    }
}
