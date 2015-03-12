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

            if (globalObject.reportObject != null)
            {
                if (globalObject.reportObject.fileName != null && !globalObject.reportObject.fileName.Equals(""))
                {
                    switch (globalObject.reportObject.reportType)
                    {
                        case ReportType.CSV:
                        case ReportType.EXCEL:
                        case ReportType.WORD:
                            ReportDao dao = new ReportDao();
                            status  = dao.readAll(globalObject);
                            break;
                        default:
                            status = ApplicationErrorType.NOT_ALLOWED;
                            break;
                    }
                }
                else
                {
                    status = ApplicationErrorType.INVALID_FILENAME;
                }
            }
            else
            {
                status = ApplicationErrorType.NOT_ALLOWED;
            }
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
