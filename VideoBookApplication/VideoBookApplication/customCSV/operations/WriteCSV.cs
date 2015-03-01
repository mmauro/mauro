using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoBookApplication.customCSV.common;

namespace VideoBookApplication.customCSV.operations
{
    public class WriteCSV
    {

        private FormatterCSV formatter = null;
        public WriteCSV()
        {
            formatter = FormatterCSV.DEFAULT_FORMATTER;
        }
    }
}
