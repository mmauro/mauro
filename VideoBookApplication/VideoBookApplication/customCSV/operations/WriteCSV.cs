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
        private StreamWriter writer = null;
        private FileUtility fileUtil = null;

        public WriteCSV(string fileName)
        {
            formatter = FormatterCSV.DEFAULT_FORMATTER;

            //Creazione di Backup di file Esistente
            fileUtil = new FileUtility(fileName);

            //Apertuta dello stream;
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
                    fileUtil.restoreBackup();
                    log.Error(e.Message);
                    throw new VideoBookException(ApplicationErrorType.OPEN_STREAM_ERROR);
                }
            }
            else
            {
                fileUtil.restoreBackup();
                throw new VideoBookException(ApplicationErrorType.INVALID_FILENAME);
            }
        }

        public void close() 
        {
            //Cancellazione dello stream;
            fileUtil.deleteBackup();
            if (writer != null)
            {
                writer.Close();
            }
        }

        public void writeHeader(List<string> header)
        {
            if (header != null)
            {
                string row = null;
                ProcessRow processRow = new ProcessRow(formatter);
                try
                {
                    row = processRow.processRow(header);
                }
                catch (VideoBookException e)
                {
                    fileUtil.restoreBackup();
                    throw e;
                }

                if (row != null)
                {
                    try
                    {
                        writer.Write(row);
                    }
                    catch (Exception e)
                    {
                        log.Error(e.Message);
                        fileUtil.restoreBackup();
                        throw new VideoBookException(ApplicationErrorType.WRITE_STREAM_ERROR);
                    }
                }
                else
                {
                    fileUtil.restoreBackup();
                    throw new VideoBookException(ApplicationErrorType.INVALID_ROW);
                }

            }
            else
            {
                fileUtil.restoreBackup();
                throw new VideoBookException(ApplicationErrorType.INVALID_HEADER);
            }
        }
    }
}
