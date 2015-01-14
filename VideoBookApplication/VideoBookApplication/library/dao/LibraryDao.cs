using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoBookApplication.common.controls;
using VideoBookApplication.common.enums;
using VideoBookApplication.common.model;
using VideoBookApplication.common.utility;
using VideoBookApplication.library.model.database;

namespace VideoBookApplication.library.dao
{
    public class LibraryDao
    {
        private MySqlTransaction transaction = DatabaseControl.getInstance().getConnection().BeginTransaction();
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public ApplicationErrorType writeInformations(GlobalApplicationObject globalObject)
        {
            ApplicationErrorType status = ApplicationErrorType.SUCCESS;
            int idAutore = Configurator.getInstsance().getInt("notfound.value");
            try
            {
                //Step 1: write autore
                if (globalObject.libraryObject.libraryInput.autore.idAutore == Configurator.getInstsance().getInt("notfound.value"))
                {
                    log.Info("STEP 1 : Write Autore");
                    try
                    {
                        writeAutore(globalObject.libraryObject.libraryInput.autore);
                        idAutore = readIdAutore();
                        if (idAutore != Configurator.getInstsance().getInt("notfound.value"))
                        {
                            log.Info("idAutore = " + idAutore);
                        }
                        else
                        {
                            log.Error("Failure Read id Autore");
                            status = ApplicationErrorType.READ_AUTHOR_ERROR;
                        }
                    }
                    catch (VideoBookException e)
                    {
                        log.Error("Throw Exception");
                        status = ApplicationErrorType.FAILURE;
                    }
                }

                log.Info("DONE");
                if (status == ApplicationErrorType.SUCCESS)
                {
                    //TODO: cambiare con commit
                    transaction.Rollback();
                }
                else
                {
                    transaction.Rollback();
                }

                return status;
                
            }
            catch (VideoBookException e)
            {
                transaction.Rollback();
                throw e;
            }
        }

        private void writeAutore(AuthorModel autore)
        {
            try
            {
                MySqlCommand command = new MySqlCommand(Configurator.getInstsance().get("author.write.query"), DatabaseControl.getInstance().getConnection(), transaction);
                command.Prepare();
                LogUtility.printQueryLog(Configurator.getInstsance().get("author.write.query"), autore.cognome, autore.nome);
                command.Parameters.AddWithValue("@cogn", autore.cognome);
                command.Parameters.AddWithValue("@nam", autore.nome);
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                log.Error(e.Message);
                throw new VideoBookException(ApplicationErrorType.WRITE_AUTHOR_ERROR);
            }
        }

        private int readIdAutore()
        {
            int value = Configurator.getInstsance().getInt("notfound.value");
            try
            {
                MySqlCommand command = new MySqlCommand(Configurator.getInstsance().get("author.readmaxid.query"), DatabaseControl.getInstance().getConnection(), transaction);
                command.Prepare();
                LogUtility.printQueryLog(Configurator.getInstsance().get("author.write.query"), null);
                MySqlDataReader reader = command.ExecuteReader();
                if (reader != null && reader.HasRows)
                {
                    while (reader.Read())
                    {
                        value = reader.GetInt32("id_autore");
                    }
                    reader.Close();
                }

                return value;

            }
            catch (Exception e)
            {
                log.Error(e.Message);
                throw new VideoBookException(ApplicationErrorType.READ_AUTHOR_ERROR);
            }
        }
    }
}
