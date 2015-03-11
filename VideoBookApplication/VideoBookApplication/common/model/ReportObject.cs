using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoBookApplication.common.enums;

namespace VideoBookApplication.common.model
{
    public class ReportObject
    {
        public string fileName { get; set; }
        public FileFilterType filter { get; set; }
        public ReportType reportType { get; set; }

        public ReportObject(FileFilterType filter, ReportType reportType)
        {
            this.filter = filter;
            this.reportType = reportType;
            this.fileName = null;
        }

        public ReportObject()
        {
            this.filter = null;
            this.fileName = null;
            this.reportType = ReportType.UNDEFINED;
        }

    }
}
