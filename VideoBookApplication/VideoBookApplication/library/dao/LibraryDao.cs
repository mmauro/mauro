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
                                    else
                                    {
                                        log.Info("Word Found");
                                        writeWord2Nome(idWord, idAutore);
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
                else
                {
                    idAutore = globalObject.libraryObject.libraryInput.autore.idAutore;
                }

                if (status == ApplicationErrorType.SUCCESS)
                {

                    foreach (BookModel libro in globalObject.libraryObject.libraryInput.libri)
                    {
                        int idNota = Configurator.getInstsance().getInt("notfound.value");
                        int idInfo = Configurator.getInstsance().getInt("notfound.value");
                        int idLibro = Configurator.getInstsance().getInt("notfound.value");

                        if (libro.note != null)
                        {
                            try
                            {
                                log.Info("STEP 3 : Write Note --> [ " + libro.titolo + " ]");
                                writeNote(libro.note);
                                idNota = readIdNota();
                                if (idNota == Configurator.getInstsance().getInt("notfound.value"))
                                {
                                    status = ApplicationErrorType.READ_NOTE_ERROR;
                                }

                            }
                            catch (VideoBookException e)
                            {
                                log.Error("Throw Exception");
                                status = e.errorType;
                            }
                        }

                        if (status == ApplicationErrorType.SUCCESS && libro.informations != null)
                        {
                            try
                            {
                                log.Info("STEP 4 : Write Info --> [ " + libro.titolo + " ]");
                                writeBookInfo(libro.informations);
                                idInfo = readIdInfo();
                                if (idInfo == Configurator.getInstsance().getInt("notfound.value"))
                                {
                                    status = ApplicationErrorType.READ_BOOKINFO_ERROR;
                                }

                            }
                            catch (VideoBookException e)
                            {
                                log.Error("Throw Exception");
                                status = e.errorType;
                            }
                        }

                        if (status == ApplicationErrorType.SUCCESS)
                        {
                            try
                            {
                                writeBooks(libro, idAutore, idNota, idInfo);
                                idLibro = readIdBook();
                                if (idLibro == Configurator.getInstsance().getInt("notfound.value"))
                                {
                                    status = ApplicationErrorType.READ_BOOK_ERROR;
                                }
                            }
                            catch (VideoBookException e)
                            {
                                status = e.errorType;
                            }
                        }

                        if (status == ApplicationErrorType.SUCCESS)
                        {
                            //Scrittura parole indicizzate per titolo
                            List<string> listaParoleTitoli = globalObject.libraryObject.libraryInput.indexElements.wordBooksTitle[libro];
                            if (listaParoleTitoli != null && listaParoleTitoli.Count > 0)
                            {
                                foreach (string word in listaParoleTitoli)
                                {
                                    int idWord = readIdWord(word);
                                    if (idWord == Configurator.getInstsance().getInt("notfound.value"))
                                    {
                                        log.Info("Word Not Found : write");
                                        writeWord(word);
                                        idWord = readIdWord(word);
                                        if (idWord != Configurator.getInstsance().getInt("notfound.value"))
                                        {
                                            writeWord2Book(idWord, idLibro);
                                        }
                                        else
                                        {
                                            status = ApplicationErrorType.READ_WORD_ERROR;
                                        }
                                    }
                                    else
                                    {
                                        log.Info("Word Found");
                                        writeWord2Book(idWord, idLibro);
                                    }
                                }
                            }
                        }

                    }

                }


               
                if (status == ApplicationErrorType.SUCCESS)
                {
                    log.Info("DONE");
                    transaction.Commit();
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

        private void writeBookInfo(BookInfoModel model)
        {
            try
            {
                MySqlCommand command = new MySqlCommand(Configurator.getInstsance().get("infobook.write.query"), DatabaseControl.getInstance().getConnection(), transaction);
                command.Prepare();
                LogUtility.printQueryLog(Configurator.getInstsance().get("infobook.write.query"), model.titleOrig);
                command.Parameters.AddWithValue("@img", model.image);
                command.Parameters.AddWithValue("@edit", model.publisher);
                command.Parameters.AddWithValue("@isbn", model.isbn);
                command.Parameters.AddWithValue("@anno", model.year);
                command.Parameters.AddWithValue("@descr", model.trama);
                command.Parameters.AddWithValue("@sk", model.urlScheda);

                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                log.Error(e.Message);
                throw new VideoBookException(ApplicationErrorType.WRITE_BOOKINFO_ERROR);
            }
        }

        private int readIdInfo()
        {
            int value = Configurator.getInstsance().getInt("notfound.value");
            try
            {
                MySqlCommand command = new MySqlCommand(Configurator.getInstsance().get("infobook.readmaxid.query"), DatabaseControl.getInstance().getConnection(), transaction);
                command.Prepare();
                LogUtility.printQueryLog(Configurator.getInstsance().get("infobook.readmaxid.query"), null);
                MySqlDataReader reader = command.ExecuteReader();
                if (reader != null && reader.HasRows)
                {
                    while (reader.Read())
                    {
                        value = reader.GetInt32("id_info");
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

        private void writeBooks(BookModel model, int idAutore, int idNota, int idInfo)
        {
            try
            {
                //insert into LIBRI (TITOLO, SERIE, FL_EBOOK, AUTORI_ID_AUTORE, CATEGORIE_ID_CATEGORIA, POSIZIONI_ID_POSIZIONE, DT_INSERT, INFOLIBRI_ID_INFOLIBRO, NOTELIBRI_ID_NOTA) values 
                //(@title, @serie, @flebook, @idauth, @idcat, @idpos, @dtinsert, @info, @nota)
                MySqlCommand command = new MySqlCommand(Configurator.getInstsance().get("books.write.query"), DatabaseControl.getInstance().getConnection(), transaction);
                command.Prepare();
                LogUtility.printQueryLog(Configurator.getInstsance().get("books.write.query"), model.titolo);
                command.Parameters.AddWithValue("@title", model.titolo);
                command.Parameters.AddWithValue("@serie", model.serie);


                command.Parameters.AddWithValue("@flebook", model.flEbook);
                command.Parameters.AddWithValue("@idauth", idAutore);
                command.Parameters.AddWithValue("@idcat", model.category.idCategory);
                command.Parameters.AddWithValue("@idpos", model.position.idPosition);
                command.Parameters.AddWithValue("@dtinsert", model.dtInsert);
                if (idNota != Configurator.getInstsance().getInt("notfound.value"))
                {
                    command.Parameters.AddWithValue("@nota", idNota);
                }
                else
                {
                    command.Parameters.AddWithValue("@nota", null);
                }

                if (idInfo != Configurator.getInstsance().getInt("notfound.value"))
                {
                    command.Parameters.AddWithValue("@info", idInfo);
                }
                else
                {
                    command.Parameters.AddWithValue("@info", null);
                }

                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                log.Error(e.Message);
                throw new VideoBookException(ApplicationErrorType.WRITE_BOOK_ERROR);
            }
        }

        private int readIdBook()
        {
            int value = Configurator.getInstsance().getInt("notfound.value");
            try
            {
                MySqlCommand command = new MySqlCommand(Configurator.getInstsance().get("books.readmaxid.query"), DatabaseControl.getInstance().getConnection(), transaction);
                command.Prepare();
                LogUtility.printQueryLog(Configurator.getInstsance().get("books.readmaxid.query"), null);
                MySqlDataReader reader = command.ExecuteReader();
                if (reader != null && reader.HasRows)
                {
                    while (reader.Read())
                    {
                        value = reader.GetInt32("id_libro");
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
                throw new VideoBookException(ApplicationErrorType.READ_BOOK_ERROR);
            }


        }


        private void writeWord2Book(int idWord, int idLibro)
        {
            try
            {
                MySqlCommand command = new MySqlCommand(Configurator.getInstsance().get("word2book.write.query"), DatabaseControl.getInstance().getConnection(), transaction);
                command.Prepare();
                LogUtility.printQueryLog(Configurator.getInstsance().get("word2book.write.query"), idWord.ToString(), idLibro.ToString());
                command.Parameters.AddWithValue("@idw", idWord);
                command.Parameters.AddWithValue("@idb", idLibro);
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                log.Error(e.Message);
                throw new VideoBookException(ApplicationErrorType.WRITE_W2BOOK_ERROR);
            }
        }




    }
}
