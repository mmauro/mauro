using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoBookApplication.common.controls;
using VideoBookApplication.common.dao;
using VideoBookApplication.common.enums;
using VideoBookApplication.common.model;
using VideoBookApplication.common.utility;
using VideoBookApplication.customCSV.operations;
using VideoBookApplication.library.model.database;
using VideoBookApplication.library.utility;

namespace VideoBookApplication.library.dao
{
    public class ReportDao
    {

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private WriteCSV writerCSV = null;

        public ApplicationErrorType readAll(GlobalApplicationObject globalObject)
        {
            MySqlDataReader reader = null;
            MySqlCommand command = null;
            ApplicationErrorType status = ApplicationErrorType.SUCCESS;
            try
            {
                command = new MySqlCommand(Configurator.getInstsance().get("report.extract.query"), DatabaseControl.getInstance().getConnection());
                command.Prepare();
                LogUtility.printQueryLog(Configurator.getInstsance().get("report.extract.query"), null);
                reader = command.ExecuteReader();

                initReport(globalObject.reportObject.fileName, globalObject.reportObject.reportType);

                ProcessHeader(globalObject.reportObject.reportType);

                if (reader != null && reader.HasRows)
                {
                    while (reader.Read())
                    {

                        ReportModel model = new ReportModel();
                        model.cognome = reader.GetString("COGNOME");
                        model.nome = reader.GetString("NOME");
                        model.titolo = reader.GetString("TITOLO");
                        model.serie = reader.GetString("SERIE");
                        model.dtInsert = reader.GetDateTime("DT_INSERT");
                        model.flEbook = reader.GetBoolean("FL_EBOOK");
                        model.categoria = DisplayUtility.formatCategoryPosition(reader.GetString("CATEGORIA"));
                        model.posizione = DisplayUtility.formatCategoryPosition(reader.GetString("POSIZIONE"));
                        model.nota = reader.GetString("NOTA").Trim();
                        model.trama = reader.GetString("TRAMA").Trim();
                        model.img = reader.GetString("IMG");
                        model.annoPubblicazione = reader.GetString("YEAR");
                        model.editore = reader.GetString("EDITORE");
                        model.isbn = reader.GetString("ISBN");


                        processModel(model, globalObject.reportObject.reportType);
                    }
                }
            }
            catch (VideoBookException vbe) {
                status = vbe.errorType;
                log.Error(vbe.errorType.message);
            }
            catch (Exception e)
            {
                log.Error(e.Message);
                status = ApplicationErrorType.READ_REPORT_ERROR;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
                if (command != null)
                {
                    command.Dispose();
                }
                closeReport(globalObject.reportObject.reportType);
            }


            return status;

        }


        private void initReport(String filename, ReportType reportType)
        {
            switch (reportType)
            {
                case ReportType.CSV:
                    writerCSV = new WriteCSV(filename);
                    break;
                case ReportType.WORD:
                    throw new VideoBookException(ApplicationErrorType.NOT_IMPLEMENTED);
                case ReportType.EXCEL:
                    throw new VideoBookException(ApplicationErrorType.NOT_IMPLEMENTED);
                default:
                    throw new VideoBookException(ApplicationErrorType.NOT_ALLOWED);

            }
        }

        private void processModel(ReportModel model, ReportType reportType)
        {
            switch (reportType)
            {
                case ReportType.CSV:
                    writerCSV.write(model, CSVUtility.getCSVHeader());
                    break;
                case ReportType.WORD:
                    throw new VideoBookException(ApplicationErrorType.NOT_IMPLEMENTED);
                case ReportType.EXCEL:
                    throw new VideoBookException(ApplicationErrorType.NOT_IMPLEMENTED);
                default:
                    throw new VideoBookException(ApplicationErrorType.NOT_ALLOWED);
            }
        }

        private void ProcessHeader(ReportType reportType)
        {
            switch (reportType)
            {
                case ReportType.CSV:
                    writerCSV.writeHeader(CSVUtility.getCSVFirstRow());
                    break;
                case ReportType.WORD:
                    throw new VideoBookException(ApplicationErrorType.NOT_IMPLEMENTED);
                case ReportType.EXCEL:
                    throw new VideoBookException(ApplicationErrorType.NOT_IMPLEMENTED);
                default:
                    throw new VideoBookException(ApplicationErrorType.NOT_ALLOWED);
            }
        }

        private void closeReport(ReportType reportType)
        {
            switch (reportType)
            {
                case ReportType.CSV:
                    writerCSV.close();
                    break;
                case ReportType.WORD:
                    throw new VideoBookException(ApplicationErrorType.NOT_IMPLEMENTED);
                case ReportType.EXCEL:
                    throw new VideoBookException(ApplicationErrorType.NOT_IMPLEMENTED);
                default:
                    throw new VideoBookException(ApplicationErrorType.NOT_ALLOWED);

            }
        }

    }

 


}
