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


        public ApplicationErrorType deleteCategory(int categoryDelete, int categoryDefault)
        {
            ApplicationErrorType status = ApplicationErrorType.SUCCESS;

            try
            {

                updateBookCategory(categoryDelete, categoryDefault);
                deleteCat(categoryDelete);

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
            }
            catch (VideoBookException e)
            {
                transaction.Rollback();
                throw e;
            }

            return status;
        }

        public ApplicationErrorType deletePosition(int posDelete, int posDefault)
        {
            ApplicationErrorType status = ApplicationErrorType.SUCCESS;

            try
            {

                updateBookPosition(posDelete, posDefault);
                deletePos(posDelete);

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
            }
            catch (VideoBookException e)
            {
                log.Error("FAILURE");
                transaction.Rollback();
                throw e;
            }

            return status;
        }


        public ApplicationErrorType deleteAuthorsAndBook(AuthorModel model)
        {
            ApplicationErrorType status = ApplicationErrorType.SUCCESS;

            try
            {
                //CAncellazione Autore
                deleteAuthor(model.idAutore);

                //Cancellazioe Parole Orfane di libri e autori
                deleteOrphanWord();

                //Cancellazione Note e Informazioni Aggiuntive Orfane dai libri
                deleteOrphanBookInfo();
                deleteOrphanBookNote();

                log.Info("DONE");
                transaction.Commit();

            }
            catch (VideoBookException e)
            {
                log.Error("FAILURE");
                transaction.Rollback();
                status = e.errorType;
            }


            return status;
        }

        public ApplicationErrorType deleteBooks(BookModel model)
        {
            ApplicationErrorType status = ApplicationErrorType.SUCCESS;
            try
            {
                //CAncellazione Autore
                deleteBook(model.idLibro);

                //Cancellazioe Parole Orfane di libri e autori
                deleteOrphanWord();

                //Cancellazione Note e Informazioni Aggiuntive Orfane dai libri
                deleteOrphanBookInfo();
                deleteOrphanBookNote();

                log.Info("DONE");
                transaction.Commit();

            }
            catch (VideoBookException e)
            {
                log.Error("FAILURE");
                transaction.Rollback();
                status = e.errorType;
            }
            return status;
        }

        public ApplicationErrorType updateAuthor(AuthorModel model, List<string> cognomeAdd, List<string> cognomeDelete, List<string> nomeAdd, List<string> nomeDelete)
        {
            ApplicationErrorType status = ApplicationErrorType.SUCCESS;

            try
            {
                //Update Autore
                updateAuthor(model);

                //cancellazione word2cognome
                foreach (string word in cognomeDelete)
                {
                    if (status == ApplicationErrorType.SUCCESS)
                    {
                        int idWord = readIdWord(word);
                        if (idWord != Configurator.getInstsance().getInt("notfound.value"))
                        {
                            deleteWord2Cognome(idWord, model.idAutore);
                        }
                        else
                        {
                            status = ApplicationErrorType.READ_WORD_ERROR;
                        }
                    }
                }

                //cancellazione word2nome
                if (status == ApplicationErrorType.SUCCESS)
                {
                    foreach (string word in nomeDelete)
                    {
                        if (status == ApplicationErrorType.SUCCESS)
                        {
                            int idWord = readIdWord(word);
                            if (idWord != Configurator.getInstsance().getInt("notfound.value"))
                            {
                                deleteWord2Nome(idWord, model.idAutore);
                            }
                            else
                            {
                                status = ApplicationErrorType.READ_WORD_ERROR;
                            }
                        }
                    }
                }


                //Cancellazione Parole Orfane
                deleteOrphanWord();

                //Inserimento Nuove parole per cognome
                if (status == ApplicationErrorType.SUCCESS)
                {
                    foreach (string word in cognomeAdd)
                    {
                        if (status == ApplicationErrorType.SUCCESS)
                        {
                            int idWord = readIdWord(word);
                            if (idWord == Configurator.getInstsance().getInt("notfound.value"))
                            {
                                log.Info("Word Not Found : write");
                                writeWord(word);
                                idWord = readIdWord(word);
                                if (idWord != Configurator.getInstsance().getInt("notfound.value"))
                                {
                                    writeWord2Cognome(idWord, model.idAutore);
                                }
                                else
                                {
                                    status = ApplicationErrorType.READ_WORD_ERROR;
                                }
                            }
                            else
                            {
                                log.Info("Word Found");
                                writeWord2Cognome(idWord, model.idAutore);
                            }
                        }
                        
                    }
                }

                if (status == ApplicationErrorType.SUCCESS)
                {
                    foreach (string word in nomeAdd)
                    {
                        if (status == ApplicationErrorType.SUCCESS)
                        {
                            int idWord = readIdWord(word);
                            if (idWord == Configurator.getInstsance().getInt("notfound.value"))
                            {
                                log.Info("Word Not Found : write");
                                writeWord(word);
                                idWord = readIdWord(word);
                                if (idWord != Configurator.getInstsance().getInt("notfound.value"))
                                {
                                    writeWord2Nome(idWord, model.idAutore);
                                }
                                else
                                {
                                    status = ApplicationErrorType.READ_WORD_ERROR;
                                }
                            }
                            else
                            {
                                log.Info("Word Found");
                                writeWord2Nome(idWord, model.idAutore);
                            }
                        }

                    }
                }

                if (status == ApplicationErrorType.SUCCESS)
                {
                    transaction.Commit();
                }
                else
                {
                    transaction.Rollback();
                }

            }
            catch (VideoBookException e)
            {
                log.Error(e.errorType.message);
                transaction.Rollback();
                status = e.errorType;
            }


            return status;
        }

        private void updateBookCategory(int categoryDelete, int categoryDefault)
        {
            try
            {
                MySqlCommand command = new MySqlCommand(Configurator.getInstsance().get("book.updatecat.query"), DatabaseControl.getInstance().getConnection(), transaction);
                command.Prepare();
                LogUtility.printQueryLog(Configurator.getInstsance().get("book.updatecat.query"), categoryDefault.ToString(), categoryDelete.ToString());
                command.Parameters.AddWithValue("@idcatnew", categoryDefault);
                command.Parameters.AddWithValue("@idcatold", categoryDelete);
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                log.Error(e.Message);
                throw new VideoBookException(ApplicationErrorType.UPDATE_BOOK_ERROR);
            }
        }

        private void updateBookPosition(int posDelete, int posDefault)
        {
            try
            {
                MySqlCommand command = new MySqlCommand(Configurator.getInstsance().get("book.updatepos.query"), DatabaseControl.getInstance().getConnection(), transaction);
                command.Prepare();
                LogUtility.printQueryLog(Configurator.getInstsance().get("book.updatepos.query"), posDefault.ToString(), posDelete.ToString());
                command.Parameters.AddWithValue("@idposnew", posDefault);
                command.Parameters.AddWithValue("@idposold", posDelete);
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                log.Error(e.Message);
                throw new VideoBookException(ApplicationErrorType.UPDATE_BOOK_ERROR);
            }
        }

        private void deletePos(int posDelete)
        {
            try
            {
                MySqlCommand command = new MySqlCommand(Configurator.getInstsance().get("position.delete.query"), DatabaseControl.getInstance().getConnection(), transaction);
                command.Prepare();
                LogUtility.printQueryLog(Configurator.getInstsance().get("position.delete.query"), posDelete.ToString());
                command.Parameters.AddWithValue("@idpos", posDelete);
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                log.Error(e.Message);
                throw new VideoBookException(ApplicationErrorType.DELETE_CATEGORY_ERROR);
            }
        }


        private void deleteCat(int categoryDelete)
        {
            try
            {
                MySqlCommand command = new MySqlCommand(Configurator.getInstsance().get("category.delete.query"), DatabaseControl.getInstance().getConnection(), transaction);
                command.Prepare();
                LogUtility.printQueryLog(Configurator.getInstsance().get("category.delete.query"), categoryDelete.ToString());
                command.Parameters.AddWithValue("@idcat", categoryDelete);
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                log.Error(e.Message);
                throw new VideoBookException(ApplicationErrorType.DELETE_CATEGORY_ERROR);
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
            MySqlDataReader reader = null;
            MySqlCommand command = null;
            try
            {
                command = new MySqlCommand(Configurator.getInstsance().get("author.readmaxid.query"), DatabaseControl.getInstance().getConnection(), transaction);
                command.Prepare();
                LogUtility.printQueryLog(Configurator.getInstsance().get("author.readmaxid.query"), null);
                reader = command.ExecuteReader();
                if (reader != null && reader.HasRows)
                {
                    while (reader.Read())
                    {
                        value = reader.GetInt32("id_autore");
                    }
                }

                return value;

            }
            catch (Exception e)
            {
                log.Error(e.Message);
                throw new VideoBookException(ApplicationErrorType.READ_AUTHOR_ERROR);
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
            MySqlDataReader reader = null;
            MySqlCommand command = null;
            try
            {
                command = new MySqlCommand(Configurator.getInstsance().get("booknote.readmaxid.query"), DatabaseControl.getInstance().getConnection(), transaction);
                command.Prepare();
                LogUtility.printQueryLog(Configurator.getInstsance().get("booknote.readmaxid.query"), null);
                reader = command.ExecuteReader();
                if (reader != null && reader.HasRows)
                {
                    while (reader.Read())
                    {
                        value = reader.GetInt32("id_nota");
                    }
                }

                return value;

            }
            catch (Exception e)
            {
                log.Error(e.Message);
                throw new VideoBookException(ApplicationErrorType.READ_AUTHOR_ERROR);
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
            MySqlDataReader reader = null;
            MySqlCommand command = null;
            try
            {
                command = new MySqlCommand(Configurator.getInstsance().get("infobook.readmaxid.query"), DatabaseControl.getInstance().getConnection(), transaction);
                command.Prepare();
                LogUtility.printQueryLog(Configurator.getInstsance().get("infobook.readmaxid.query"), null);
                reader = command.ExecuteReader();
                if (reader != null && reader.HasRows)
                {
                    while (reader.Read())
                    {
                        value = reader.GetInt32("id_info");
                    }

                }

                return value;

            }
            catch (Exception e)
            {
                log.Error(e.Message);
                throw new VideoBookException(ApplicationErrorType.READ_AUTHOR_ERROR);
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
            }
        }

        private int readIdWord(string word)
        {
            int value = Configurator.getInstsance().getInt("notfound.value");
            MySqlDataReader reader = null;
            MySqlCommand command = null;
            try
            {
                command = new MySqlCommand(Configurator.getInstsance().get("wordmaster.readbyword.query"), DatabaseControl.getInstance().getConnection(), transaction);
                command.Prepare();
                command.Parameters.AddWithValue("@word", word);
                LogUtility.printQueryLog(Configurator.getInstsance().get("wordmaster.readbyword.query"), word);
                reader = command.ExecuteReader();
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
            MySqlDataReader reader = null;
            MySqlCommand command = null;
            try
            {
                command = new MySqlCommand(Configurator.getInstsance().get("books.readmaxid.query"), DatabaseControl.getInstance().getConnection(), transaction);
                command.Prepare();
                LogUtility.printQueryLog(Configurator.getInstsance().get("books.readmaxid.query"), null);
                reader = command.ExecuteReader();
                if (reader != null && reader.HasRows)
                {
                    while (reader.Read())
                    {
                        value = reader.GetInt32("id_libro");
                    }

                }
                return value;

            }
            catch (Exception e)
            {
                log.Error(e.Message);
                throw new VideoBookException(ApplicationErrorType.READ_BOOK_ERROR);
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

        private void deleteAuthor(int authorModel)
        {
            try
            {
                MySqlCommand command = new MySqlCommand(Configurator.getInstsance().get("author.delete.query"), DatabaseControl.getInstance().getConnection(), transaction);
                command.Prepare();
                LogUtility.printQueryLog(Configurator.getInstsance().get("author.delete.query"), authorModel.ToString());
                command.Parameters.AddWithValue("@idauth", authorModel);
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                log.Error(e.Message);
                throw new VideoBookException(ApplicationErrorType.DELETE_AUTHOR_ERROR);
            }
        }

        private void deleteBook(int bookId)
        {
            try
            {
                MySqlCommand command = new MySqlCommand(Configurator.getInstsance().get("book.delete.query"), DatabaseControl.getInstance().getConnection(), transaction);
                command.Prepare();
                LogUtility.printQueryLog(Configurator.getInstsance().get("book.delete.query"), bookId.ToString());
                command.Parameters.AddWithValue("@idbook", bookId);
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                log.Error(e.Message);
                throw new VideoBookException(ApplicationErrorType.DELETE_BOOK_ERROR);
            }
        }

        private void deleteOrphanWord()
        {
            try
            {
                MySqlCommand command = new MySqlCommand(Configurator.getInstsance().get("wordmaster.delete.orphan.query"), DatabaseControl.getInstance().getConnection(), transaction);
                command.Prepare();
                LogUtility.printQueryLog(Configurator.getInstsance().get("wordmaster.delete.orphan.query"), null);
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                log.Error(e.Message);
                throw new VideoBookException(ApplicationErrorType.DELETE_WORDMASTER_ERROR);
            }
        }

        private void deleteOrphanBookNote()
        {
            try
            {
                MySqlCommand command = new MySqlCommand(Configurator.getInstsance().get("booknote.delete.orphan.query"), DatabaseControl.getInstance().getConnection(), transaction);
                command.Prepare();
                LogUtility.printQueryLog(Configurator.getInstsance().get("booknote.delete.orphan.query"), null);
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                log.Error(e.Message);
                throw new VideoBookException(ApplicationErrorType.DELETE_NOTEBOOK_ERROR);
            }
        }

        private void deleteOrphanBookInfo()
        {
            try
            {
                MySqlCommand command = new MySqlCommand(Configurator.getInstsance().get("infobook.delete.orphan.query"), DatabaseControl.getInstance().getConnection(), transaction);
                command.Prepare();
                LogUtility.printQueryLog(Configurator.getInstsance().get("infobook.delete.orphan.query"), null);
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                log.Error(e.Message);
                throw new VideoBookException(ApplicationErrorType.DELETE_INFOBOOK_ERROR);
            }
        }

        private void updateAuthor(AuthorModel model)
        {
            try
            {
                MySqlCommand command = new MySqlCommand(Configurator.getInstsance().get("author.update.query"), DatabaseControl.getInstance().getConnection(), transaction);
                command.Prepare();
                LogUtility.printQueryLog(Configurator.getInstsance().get("author.update.query"), model.cognome, model.nome, model.idAutore.ToString());
                command.Parameters.AddWithValue("@cogn", model.cognome);
                command.Parameters.AddWithValue("@nam", model.nome);
                command.Parameters.AddWithValue("@idauth", model.idAutore);
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                log.Error(e.Message);
                throw new VideoBookException(ApplicationErrorType.UPDATE_AUTHOR_ERROR);
            }
        }

        private void deleteWord2Cognome(int idWord, int idAutore)
        {
            try
            {
                MySqlCommand command = new MySqlCommand(Configurator.getInstsance().get("word2cognome.delete.query"), DatabaseControl.getInstance().getConnection(), transaction);
                command.Prepare();
                LogUtility.printQueryLog(Configurator.getInstsance().get("word2cognome.delete.query"), idWord.ToString(), idAutore.ToString());
                command.Parameters.AddWithValue("@idw", idWord);
                command.Parameters.AddWithValue("@ida", idAutore);
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                log.Error(e.Message);
                throw new VideoBookException(ApplicationErrorType.UPDATE_AUTHOR_ERROR);
            }
        }

        private void deleteWord2Nome(int idWord, int idAutore)
        {
            try
            {
                MySqlCommand command = new MySqlCommand(Configurator.getInstsance().get("word2nome.delete.query"), DatabaseControl.getInstance().getConnection(), transaction);
                command.Prepare();
                LogUtility.printQueryLog(Configurator.getInstsance().get("word2nome.delete.query"), idWord.ToString(), idAutore.ToString());
                command.Parameters.AddWithValue("@idw", idWord);
                command.Parameters.AddWithValue("@ida", idAutore);
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                log.Error(e.Message);
                throw new VideoBookException(ApplicationErrorType.UPDATE_AUTHOR_ERROR);
            }
        }


    }
}
