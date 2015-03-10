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
    public class ReportControls
    {
        public ApplicationErrorType saveReport(ref GlobalApplicationObject globalObject)
        {
            ApplicationErrorType status = ApplicationErrorType.SUCCESS;
            return status;
        }

        public bool canSaveReport()
        {
            int numValue = 0;
            bool saveReport = false;
            AuthorDao dao = new AuthorDao();
            try
            {
                numValue = dao.countElement();
            }
            catch (VideoBookException e)
            {
                numValue = 0;
            }

            if (numValue > 0)
            {
                saveReport = true;
            }
            else
            {
                saveReport = false;
            }

            return saveReport;
        }
    }
}
