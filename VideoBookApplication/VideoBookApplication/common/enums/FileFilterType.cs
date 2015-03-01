using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoBookApplication.common.enums
{
    public class FileFilterType
    {
        public string extension { get; private set; }
        public string dialogFilter { get; private set; }

        private FileFilterType(string extension, string dialogFilter)
        {
            this.extension = extension;
            this.dialogFilter = dialogFilter;
        }

        public FileFilterType CSV_FILE = new FileFilterType(".csv", "CSV files (*.csv)|*.csv");
        public FileFilterType EXCEL_FILE = new FileFilterType(".xlsx", "Excel files (*.xlsx)|*.xlsx");      
        public FileFilterType WORD_FILE = new FileFilterType(".docx", "Word files (*.docx)|*.docx");
    }
}
