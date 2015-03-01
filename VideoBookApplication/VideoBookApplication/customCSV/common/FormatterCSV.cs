using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoBookApplication.customCSV.common
{
    public class FormatterCSV
    {
        public string cellSeparator { get; private set; }
        public string rowSeparator { get; private set; }
        public string cellQuote { get; private set; }

        private FormatterCSV(string cellSeparator, string cellQuote, string rowSeparator)
        {
            this.cellQuote = cellQuote;
            this.rowSeparator = rowSeparator;
            this.cellSeparator = cellSeparator;
        }

        public static FormatterCSV DEFAULT_FORMATTER = new FormatterCSV(";", "\"", Environment.NewLine);
    }
}
