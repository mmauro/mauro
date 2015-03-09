using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoBookApplication.common.enums;

namespace VideoBookApplication.common.model
{
    public class FileObject
    {
        public string fileName { get; set; }
        public FileFilterType filter { get; set; }

        public FileObject(FileFilterType filter)
        {
            this.filter = filter;
            this.fileName = null;
        }

        public FileObject()
        {
            this.filter = null;
            this.fileName = null;
        }

    }
}
