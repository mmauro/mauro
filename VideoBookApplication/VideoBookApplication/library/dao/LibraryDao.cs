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
                   
                    try
                    {
                        log.Info("STEP 1 : Write Autore");
                        writeAutore(globalObject.libraryObject.libraryInput.autore);

                        log.Info("STEP 2 : Read Autore");
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
                        if (status == ApplicationErrorType.SUCCESS && globalObject.libraryObject.libraryInput.indexElements.wordsCognome != null && globalObject.libraryObject.libraryInput.indexElements.wordsCognome.Count > 0)
                        {
                            try
                            {
                                foreach (string word in globalObject.libraryObject.libraryInput.indexElements.wordsCognome)
                                {
                                    int idWord = readIdWord(word);
                                    if (idWord == Configurator.getInstsance().getInt("notfound.value"))
                                    {
                                        log.Info("Word Not Found : write");
                                        writeWord(word);
                                        idWord = readIdWord(word);
                                        if (idWord != Configurator.getInstsance().getInt("notfound.value"))
                                        {
                                            writeWord2Cognome(idWord, idAutore);
                                        }
                                        else
                                        {
                                            status = ApplicationErrorType.READ_WORD_ERROR;
                                        }
                                    }
                                    else
                                    {
                                        log.Info("Word Found");
                                        writeWord2Cognome(idWord, idAutore);
                                    }
                                }
                            }
                            catch (VideoBookException e)
                            {
                                log.Error("Throw Exception");
                                status = e.errorType;
                            }
                        }
                        else
                        {
                            log.Error("Cognome non Indicizzato");
                            status = ApplicationErrorType.INDEXER_INVALID_VALUE;
                        }

                        if (status == ApplicationErrorType.SUCCESS && globalObject.libraryObject.libraryInput.indexElements.wordsNome != null && globalObject.libraryObject.libraryInput.indexElements.wordsNome.Count > 0)
                        {
                            try
                            {
                                foreach (string word in globalObject.libraryObject.libraryInput.indexElements.wordsNome)
                                {
                                    int idWord = readIdWord(word);
                                    if (idWord == Configurator.getInstsance().getInt("notfound.value"))
                                    {
                                        log.Info("Word Not Found : write");
                                        writeWord(word);
                                        idWord = readIdWord(word);
                                        if (idWord != Configurator.getInstsance().getInt("notfound.value"))
                                        {
                                            writeWord2Nome(idWord, idAutore);
                                        }
                                        else
                                        {
                                            status = ApplicationErrorType.READ_WORD_ERROR;
                                        }
                                    }
                                }
                            }
                            catch (VideoBookException e)
                            {
                                log.Error("Throw Exception");
                                status = e.errorType;
                            }
                        }

                    }
                    catch (VideoBookException e)
                    {
                        log.Error("Throw Exception");
                        status = ApplicationErrorType.FAILURE;
                    }

                }

                if (status == ApplicationErrorType.SUCCESS)
                {

                    foreach (BookModel libro in globalObject.libraryObject.libraryInput.libri)
                    {
                        if (libro.note != null)
                        {
                            try
                            {
                                log.Info("STEP 3 : Write Note --> [ " + libro.titolo + " ]");
                                writeNote(libro.note);
                            }
                            catch (VideoBookException e)
                            {
                                log.Error("Throw Exception");
                                status = e.errorType;
                            }
                        }

                    }

                }


               
                if (status == ApplicationErrorType.SUCCESS)
                {
                    log.Info("DONE");
                    //TODO: cambiare con commit
                    transaction.Rollback();
                }
                else
                {
                    log.Error("FAILURE");
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
                LogUtility.printQueryLog(Configurator.getInstsance().get("author.readmaxid.query"), null);
                MySqlDataReader reader = command.ExecuteReader();
                if (reader != null && reader.HasRows)
                {
                    while (reader.Read())
                    {
                        value = reader.GetInt32("id_autore");
                    }
                }


                if (reader != null)
                {
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

        private void writeNote(BookNoteModel note)
        {
            try
            {
                MySqlCommand command = new MySqlCommand(Configurator.getInstsance().get("booknote.write.query"), DatabaseControl.getInstance().getConnection(), transaction);
                command.Prepare();
                LogUtility.printQueryLog(Configurator.getInstsance().get("booknote.write.query"), note.nota);
                command.Parameters.AddWithValue("@note", note.nota);
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                log.Error(e.Message);
                throw new VideoBookException(ApplicationErrorType.WRITE_NOTE_ERROR);
            }
        }

        private int readIdNota()
        {
            int value = Configurator.getInstsance().getInt("notfound.value");
            try
            {
                MySqlCommand command = new MySqlCommand(Configurator.getInstsance().get("booknote.readmaxid.query"), DatabaseControl.getInstance().getConnection(), transaction);
                command.Prepare();
                LogUtility.printQueryLog(Configurator.getInstsance().get("booknote.readmaxid.query"), null);
                MySqlDataReader reader = command.ExecuteReader();
                if (reader != null && reader.HasRows)
                {
                    while (reader.Read())
                    {
                        value = reader.GetInt32("id_nota");
                    }
                    
                }

                if (reader != null)
                {
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

        private int readIdWord(string word)
        {
            int value = Configurator.getInstsance().getInt("notfound.value");
            try
            {
                MySqlCommand command = new MySqlCommand(Configurator.getInstsance().get("wordmaster.readbyword.query"), DatabaseControl.getInstance().getConnection(), transaction);
                command.Prepare();
                command.Parameters.AddWithValue("@word", word);
                LogUtility.printQueryLog(Configurator.getInstsance().get("wordmaster.readbyword.query"), word);
                MySqlDataReader reader = command.ExecuteReader();
                if (reader != null && reader.HasRows)
                {
                    while (reader.Read())
                    {
                        value = reader.GetInt32("id_word");
                    }
                    
                }

                if (reader != null)
                {
                    reader.Close();
                }

                return value;

            }
            catch (Exception e)
            {
                log.Error(e.Message);
                throw new VideoBookException(ApplicationErrorType.READ_WORD_ERROR);
            }


        }


        private void writeWord(string word)
        {
            try
            {
                MySqlCommand command = new MySqlCommand(Configurator.getInstsance().get("wordmaster.write.query"), DatabaseControl.getInstance().getConnection(), transaction);
                command.Prepare();
                LogUtility.printQueryLog(Configurator.getInstsance().get("wordmaster.write.query"), word);
                command.Parameters.AddWithValue("@word", word);
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                log.Error(e.Message);
                throw new VideoBookException(ApplicationErrorType.WRITE_WORD_ERROR);
            }
        }


        private void writeWord2Cognome(int idWord, int idAutore)
        {
            try
            {
                MySqlCommand command = new MySqlCommand(Configurator.getInstsance().get("word2cognome.write.query"), DatabaseControl.getInstance().getConnection(), transaction);
                command.Prepare();
                LogUtility.printQueryLog(Configurator.getInstsance().get("word2cognome.write.query"), idWord.ToString(), idAutore.ToString());
                command.Parameters.AddWithValue("@idw", idWord);
                command.Parameters.AddWithValue("@ida", idAutore);
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                log.Error(e.Message);
                throw new VideoBookException(ApplicationErrorType.WRITE_W2AUTORE_ERROR);
            }
        }

        private void writeWord2Nome(int idWord, int idAutore)
        {
            try
            {
                MySqlCommand command = new MySqlCommand(Configurator.getInstsance().get("word2nome.write.query"), DatabaseControl.getInstance().getConnection(), transaction);
                command.Prepare();
                LogUtility.printQueryLog(Configurator.getInstsance().get("word2nome.write.query"), idWord.ToString(), idAutore.ToString());
                command.Parameters.AddWithValue("@idw", idWord);
                command.Parameters.AddWithValue("@ida", idAutore);
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                log.Error(e.Message);
                throw new VideoBookException(ApplicationErrorType.WRITE_W2AUTORE_ERROR);
            }
        }




    }
}
