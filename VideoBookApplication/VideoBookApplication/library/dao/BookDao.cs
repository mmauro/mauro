﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoBookApplication.common.controls;
using VideoBookApplication.common.dao;
using VideoBookApplication.common.enums;
using VideoBookApplication.common.utility;
using VideoBookApplication.library.model.database;

namespace VideoBookApplication.library.dao
{
    public class BookDao : IGenericOutDao<BookModel>, IGenericInDao<BookModel>, IStatisticsDao
    {

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public BookModel readOne(object value)
        {
            if (value.GetType() == typeof(int))
            {
                return readByIdLibro((int)value);
            }
            else
            {
                throw new VideoBookException(ApplicationErrorType.NOT_ALLOWED);
            }
        }

        public IEnumerable<BookModel> readMany(object value)
        {
            throw new VideoBookException(ApplicationErrorType.NOT_IMPLEMENTED);
        }

        public IEnumerable<BookModel> readAll()
        {
            throw new VideoBookException(ApplicationErrorType.NOT_IMPLEMENTED);
        }

        public void write(BookModel obj)
        {
            throw new VideoBookException(ApplicationErrorType.NOT_IMPLEMENTED);
        }

        public IEnumerable<BookModel> readByIdAutore(int idAutore)
        {
            List<BookModel> books = new List<BookModel>();

            MySqlDataReader reader = null;
            MySqlCommand command = null;

            try
            {
                //String word = (string)value;
                String query = Configurator.getInstsance().get("books.readmany.byauthor.query");
                command = new MySqlCommand(query, DatabaseControl.getInstance().getConnection());
                command.Prepare();
                command.Parameters.AddWithValue("@idauth", idAutore);

                LogUtility.printQueryLog(query, idAutore.ToString());

                
                reader = command.ExecuteReader();
                if (reader != null && reader.HasRows)
                {
                    while (reader.Read())
                    {
                        //Creazione di tutti gli elementi necessari
                        BookModel model = new BookModel();
                        CategoryModel catModel = new CategoryModel();
                        PositionModel posModel = new PositionModel();
                        BookInfoModel infoModel = new BookInfoModel();
                        BookNoteModel noteModel = new BookNoteModel();
                        AuthorModel author = new AuthorModel();

                        model.idLibro = reader.GetInt32("ID_LIBRO");
                        model.titolo = reader.GetString("TITOLO");
                        model.serie = reader.GetString("SERIE");
                        model.flEbook = reader.GetBoolean("FL_EBOOK");
                        model.dtInsert = reader.GetDateTime("DT_INSERT");

                        if (reader.GetInt32("ID_POSIZIONE") != Configurator.getInstsance().getInt("notfound.value")) {
                            posModel.idPosition = reader.GetInt32("ID_POSIZIONE");
                            posModel.position = reader.GetString("POSIZIONE");
                            model.position = posModel;
                        }
                        else
                        {
                            model.position = null;
                        }

                        if (reader.GetInt32("ID_CATEGORIA") != Configurator.getInstsance().getInt("notfound.value"))
                        {
                            catModel.idCategory = reader.GetInt32("ID_CATEGORIA");
                            catModel.category = reader.GetString("CATEGORIA");
                            model.category = catModel;
                        }
                        else
                        {
                            model.category = null;
                        }

                        if (reader.GetInt32("ID_NOTA") != Configurator.getInstsance().getInt("notfound.value"))
                        {
                            noteModel.idNota = reader.GetInt32("ID_NOTA");
                            noteModel.nota = reader.GetString("NOTA");
                            model.note = noteModel;
                        }
                        else
                        {
                            model.note = null;
                        }


                        if (reader.GetInt32("ID_INFOLIBRO") != Configurator.getInstsance().getInt("notfound.value"))
                        {
                            infoModel.idInfoLibro = reader.GetInt32("ID_INFOLIBRO");
                            infoModel.image = reader.GetString("IMG");
                            infoModel.isbn = reader.GetString("ISBN");
                            infoModel.publisher = reader.GetString("EDITORE");
                            infoModel.trama = reader.GetString("TRAMA").Trim();
                            infoModel.urlScheda = reader.GetString("URL_SCHEDA");
                            infoModel.year = reader.GetString("YEAR");
                            model.informations = infoModel;
                        }
                        else
                        {
                            model.informations = null;
                        }

                        author.idAutore = reader.GetInt32("ID_AUTORE");
                        author.cognome = reader.GetString("COGNOME");
                        author.nome = reader.GetString("NOME");
                        model.autore = author;


                        books.Add(model);

                    }
                }

                return books;
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


        public IEnumerable<BookModel> readByIdCategory(int idCategory)
        {
            List<BookModel> books = new List<BookModel>();

            MySqlDataReader reader = null;
            MySqlCommand command = null;

            try
            {
                //String word = (string)value;
                String query = Configurator.getInstsance().get("book.readbycat.query");
                command = new MySqlCommand(query, DatabaseControl.getInstance().getConnection());
                command.Prepare();
                command.Parameters.AddWithValue("@idcat", idCategory);

                LogUtility.printQueryLog(query, idCategory.ToString());


                reader = command.ExecuteReader();
                if (reader != null && reader.HasRows)
                {
                    while (reader.Read())
                    {
                        //Creazione di tutti gli elementi necessari
                        BookModel model = new BookModel();
                        CategoryModel catModel = new CategoryModel();
                        PositionModel posModel = new PositionModel();
                        BookInfoModel infoModel = new BookInfoModel();
                        BookNoteModel noteModel = new BookNoteModel();
                        AuthorModel author = new AuthorModel();

                        model.idLibro = reader.GetInt32("ID_LIBRO");
                        model.titolo = reader.GetString("TITOLO");
                        model.serie = reader.GetString("SERIE");
                        model.flEbook = reader.GetBoolean("FL_EBOOK");
                        model.dtInsert = reader.GetDateTime("DT_INSERT");

                        if (reader.GetInt32("ID_POSIZIONE") != Configurator.getInstsance().getInt("notfound.value"))
                        {
                            posModel.idPosition = reader.GetInt32("ID_POSIZIONE");
                            posModel.position = reader.GetString("POSIZIONE");
                            model.position = posModel;
                        }
                        else
                        {
                            model.position = null;
                        }

                        if (reader.GetInt32("ID_CATEGORIA") != Configurator.getInstsance().getInt("notfound.value"))
                        {
                            catModel.idCategory = reader.GetInt32("ID_CATEGORIA");
                            catModel.category = reader.GetString("CATEGORIA");
                            model.category = catModel;
                        }
                        else
                        {
                            model.category = null;
                        }

                        if (reader.GetInt32("ID_NOTA") != Configurator.getInstsance().getInt("notfound.value"))
                        {
                            noteModel.idNota = reader.GetInt32("ID_NOTA");
                            noteModel.nota = reader.GetString("NOTA");
                            model.note = noteModel;
                        }
                        else
                        {
                            model.note = null;
                        }


                        if (reader.GetInt32("ID_INFOLIBRO") != Configurator.getInstsance().getInt("notfound.value"))
                        {
                            infoModel.idInfoLibro = reader.GetInt32("ID_INFOLIBRO");
                            infoModel.image = reader.GetString("IMG");
                            infoModel.isbn = reader.GetString("ISBN");
                            infoModel.publisher = reader.GetString("EDITORE");
                            infoModel.trama = reader.GetString("TRAMA").Trim();
                            infoModel.urlScheda = reader.GetString("URL_SCHEDA");
                            infoModel.year = reader.GetString("YEAR");
                            model.informations = infoModel;
                        }
                        else
                        {
                            model.informations = null;
                        }

                        author.idAutore = reader.GetInt32("ID_AUTORE");
                        author.cognome = reader.GetString("COGNOME");
                        author.nome = reader.GetString("NOME");
                        model.autore = author;


                        books.Add(model);

                    }
                }

                return books;
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


        public IEnumerable<BookModel> readByIdPos(int idPos)
        {
            List<BookModel> books = new List<BookModel>();

            MySqlDataReader reader = null;
            MySqlCommand command = null;

            try
            {
                //String word = (string)value;
                String query = Configurator.getInstsance().get("book.readbypos.query");
                command = new MySqlCommand(query, DatabaseControl.getInstance().getConnection());
                command.Prepare();
                command.Parameters.AddWithValue("@idpos", idPos);

                LogUtility.printQueryLog(query, idPos.ToString());


                reader = command.ExecuteReader();
                if (reader != null && reader.HasRows)
                {
                    while (reader.Read())
                    {
                        //Creazione di tutti gli elementi necessari
                        BookModel model = new BookModel();
                        CategoryModel catModel = new CategoryModel();
                        PositionModel posModel = new PositionModel();
                        BookInfoModel infoModel = new BookInfoModel();
                        BookNoteModel noteModel = new BookNoteModel();
                        AuthorModel author = new AuthorModel();

                        model.idLibro = reader.GetInt32("ID_LIBRO");
                        model.titolo = reader.GetString("TITOLO");
                        model.serie = reader.GetString("SERIE");
                        model.flEbook = reader.GetBoolean("FL_EBOOK");
                        model.dtInsert = reader.GetDateTime("DT_INSERT");

                        if (reader.GetInt32("ID_POSIZIONE") != Configurator.getInstsance().getInt("notfound.value"))
                        {
                            posModel.idPosition = reader.GetInt32("ID_POSIZIONE");
                            posModel.position = reader.GetString("POSIZIONE");
                            model.position = posModel;
                        }
                        else
                        {
                            model.position = null;
                        }

                        if (reader.GetInt32("ID_CATEGORIA") != Configurator.getInstsance().getInt("notfound.value"))
                        {
                            catModel.idCategory = reader.GetInt32("ID_CATEGORIA");
                            catModel.category = reader.GetString("CATEGORIA");
                            model.category = catModel;
                        }
                        else
                        {
                            model.category = null;
                        }

                        if (reader.GetInt32("ID_NOTA") != Configurator.getInstsance().getInt("notfound.value"))
                        {
                            noteModel.idNota = reader.GetInt32("ID_NOTA");
                            noteModel.nota = reader.GetString("NOTA");
                            model.note = noteModel;
                        }
                        else
                        {
                            model.note = null;
                        }


                        if (reader.GetInt32("ID_INFOLIBRO") != Configurator.getInstsance().getInt("notfound.value"))
                        {
                            infoModel.idInfoLibro = reader.GetInt32("ID_INFOLIBRO");
                            infoModel.image = reader.GetString("IMG");
                            infoModel.isbn = reader.GetString("ISBN");
                            infoModel.publisher = reader.GetString("EDITORE");
                            infoModel.trama = reader.GetString("TRAMA").Trim();
                            infoModel.urlScheda = reader.GetString("URL_SCHEDA");
                            infoModel.year = reader.GetString("YEAR");
                            model.informations = infoModel;
                        }
                        else
                        {
                            model.informations = null;
                        }

                        author.idAutore = reader.GetInt32("ID_AUTORE");
                        author.cognome = reader.GetString("COGNOME");
                        author.nome = reader.GetString("NOME");
                        model.autore = author;

                        books.Add(model);

                    }
                }

                return books;
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

        private BookModel readByIdLibro(int idLibro)
        {
            BookModel model = null;
            MySqlDataReader reader = null;
            MySqlCommand command = null;
            try
            {
                //String word = (string)value;
                String query = Configurator.getInstsance().get("book.readbyid.query");
                command = new MySqlCommand(query, DatabaseControl.getInstance().getConnection());
                command.Prepare();
                command.Parameters.AddWithValue("@idbook", idLibro);

                LogUtility.printQueryLog(query, idLibro.ToString());


                reader = command.ExecuteReader();
                if (reader != null && reader.HasRows)
                {
                    while (reader.Read())
                    {
                        //Creazione di tutti gli elementi necessari
                        model = new BookModel();
                        
                        CategoryModel catModel = new CategoryModel();
                        PositionModel posModel = new PositionModel();
                        BookInfoModel infoModel = new BookInfoModel();
                        BookNoteModel noteModel = new BookNoteModel();
                        AuthorModel author = new AuthorModel();

                        model.idLibro = reader.GetInt32("ID_LIBRO");
                        model.titolo = reader.GetString("TITOLO");
                        model.serie = reader.GetString("SERIE");
                        model.flEbook = reader.GetBoolean("FL_EBOOK");
                        model.dtInsert = reader.GetDateTime("DT_INSERT");

                        if (reader.GetInt32("ID_POSIZIONE") != Configurator.getInstsance().getInt("notfound.value"))
                        {
                            posModel.idPosition = reader.GetInt32("ID_POSIZIONE");
                            posModel.position = reader.GetString("POSIZIONE");
                            model.position = posModel;
                        }
                        else
                        {
                            model.position = null;
                        }

                        if (reader.GetInt32("ID_CATEGORIA") != Configurator.getInstsance().getInt("notfound.value"))
                        {
                            catModel.idCategory = reader.GetInt32("ID_CATEGORIA");
                            catModel.category = reader.GetString("CATEGORIA");
                            model.category = catModel;
                        }
                        else
                        {
                            model.category = null;
                        }

                        if (reader.GetInt32("ID_NOTA") != Configurator.getInstsance().getInt("notfound.value"))
                        {
                            noteModel.idNota = reader.GetInt32("ID_NOTA");
                            noteModel.nota = reader.GetString("NOTA");
                            model.note = noteModel;
                        }
                        else
                        {
                            model.note = null;
                        }


                        if (reader.GetInt32("ID_INFOLIBRO") != Configurator.getInstsance().getInt("notfound.value"))
                        {
                            infoModel.idInfoLibro = reader.GetInt32("ID_INFOLIBRO");
                            infoModel.image = reader.GetString("IMG");
                            infoModel.isbn = reader.GetString("ISBN");
                            infoModel.publisher = reader.GetString("EDITORE");
                            infoModel.trama = reader.GetString("TRAMA").Trim();
                            infoModel.urlScheda = reader.GetString("URL_SCHEDA");
                            infoModel.year = reader.GetString("YEAR");
                            model.informations = infoModel;
                        }
                        else
                        {
                            model.informations = null;
                        }

                        author.idAutore = reader.GetInt32("ID_AUTORE");
                        author.cognome = reader.GetString("COGNOME");
                        author.nome = reader.GetString("NOME");
                        model.autore = author;

                    }
                }
                return model;
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


        public int countElement()
        {
            int value = Configurator.getInstsance().getInt("notfound.value");
            MySqlDataReader reader = null;
            MySqlCommand command = null;
            try
            {
                command = new MySqlCommand(Configurator.getInstsance().get("books.countall.query"), DatabaseControl.getInstance().getConnection());
                command.Prepare();
                LogUtility.printQueryLog(Configurator.getInstsance().get("books.countall.query"), null);
                reader = command.ExecuteReader();
                if (reader != null && reader.HasRows)
                {
                    while (reader.Read())
                    {
                        value = reader.GetInt32("cnt");
                    }
                }

                return value;

            }
            catch (Exception e)
            {
                log.Error(e.Message);
                throw new VideoBookException(ApplicationErrorType.COUNT_BOOK_ERROR);
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

        public int countElement(object value)
        {
            if (value.GetType() == typeof(bool))
            {
                return countBookByFlag((bool)value);
            }
            else
            {
                throw new VideoBookException(ApplicationErrorType.NOT_IMPLEMENTED);
            }
        }

        private int countBookByFlag(bool flEbook)
        {
            int value = Configurator.getInstsance().getInt("notfound.value");
            MySqlDataReader reader = null;
            MySqlCommand command = null;
            try
            {
                command = new MySqlCommand(Configurator.getInstsance().get("books.countebook.query"), DatabaseControl.getInstance().getConnection());
                command.Prepare();
                command.Parameters.AddWithValue("@flebook", flEbook);

                LogUtility.printQueryLog(Configurator.getInstsance().get("books.countebook.query"), flEbook.ToString());
                reader = command.ExecuteReader();
                if (reader != null && reader.HasRows)
                {
                    while (reader.Read())
                    {
                        value = reader.GetInt32("cnt");
                    }
                }

                return value;

            }
            catch (Exception e)
            {
                log.Error(e.Message);
                throw new VideoBookException(ApplicationErrorType.COUNT_BOOK_ERROR);
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

        public int readIdLibro()
        {
            int value = Configurator.getInstsance().getInt("notfound.value");
            MySqlDataReader reader = null;
            MySqlCommand command = null;
            try
            {
                command = new MySqlCommand(Configurator.getInstsance().get("books.readmaxid.query"), DatabaseControl.getInstance().getConnection());
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


        public void update(BookModel obj)
        {
            throw new VideoBookException(ApplicationErrorType.NOT_IMPLEMENTED);
        }
    }
}
