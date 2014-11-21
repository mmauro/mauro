using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoBookApplication.common.enums;


namespace VideoBookApplication.common.utility
{
    class VideoBookException : Exception
    {

        public ApplicationErrorType errorType { get; private set; }

        public VideoBookException(ApplicationErrorType errorType)
        {
            this.errorType = errorType;
        }

    }
}
