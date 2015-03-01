using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoBookApplication.common.enums;
using VideoBookApplication.common.utility;
using VideoBookApplication.customCSV.common;

namespace VideoBookApplication.customCSV.operations
{
    public class WriteCSV
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private FormatterCSV formatter = null;
        StreamWriter writer = null;

        public WriteCSV(string fileName)
        {
            formatter = FormatterCSV.DEFAULT_FORMATTER;
            open(fileName);
        }

        private void open(string fileName)
        {
            if (fileName != null && !fileName.Equals(""))
            {
                try
                {
                    writer = new StreamWriter(fileName);
                    log.Info("Stream Aperto con Successo");
                }
                catch (Exception e)
                {
                    log.Error(e.Message);
                    throw new VideoBookException(ApplicationErrorType.OPEN_STREAM_ERROR);
                }
            }
            else
            {
                throw new VideoBookException(ApplicationErrorType.INVALID_FILENAME);
            }
        }

        public void close() 
        {
            if (writer != null)
            {
                writer.Close();
            }
        }
    }
}
