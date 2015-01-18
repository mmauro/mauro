using MySql.Data.MySqlClient;
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
            throw new NotImplementedException();
        }

        public IEnumerable<BookModel> readMany(object value)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BookModel> readAll()
        {
            throw new NotImplementedException();
        }

        public void write(BookModel obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BookModel> readByIdAutore(int idAutore)
        {
            List<BookModel> books = new List<BookModel>();

            try
            {
                //String word = (string)value;
                String query = Configurator.getInstsance().get("books.readmany.byauthor.query");
                MySqlCommand command = new MySqlCommand(query, DatabaseControl.getInstance().getConnection());
                command.Prepare();
                command.Parameters.AddWithValue("@idauth", idAutore);

                LogUtility.printQueryLog(query, idAutore.ToString());

                
                MySqlDataReader reader = command.ExecuteReader();
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
                            infoModel.trama = reader.GetString("TRAMA");
                            infoModel.urlScheda = reader.GetString("URL_SCHEDA");
                            infoModel.year = reader.GetString("YEAR");
                            model.informations = infoModel;
                        }
                        else
                        {
                            model.informations = null;
                        }

                        books.Add(model);

                    }
                }
                reader.Close();
                command.Dispose();

                return books;
            }
            catch (Exception e)
            {
                log.Error(e.Message);
                throw new VideoBookException(ApplicationErrorType.READ_BOOK_ERROR);
            }
        }

        public int countElement()
        {
            int value = Configurator.getInstsance().getInt("notfound.value");
            try
            {
                MySqlCommand command = new MySqlCommand(Configurator.getInstsance().get("books.countall.query"), DatabaseControl.getInstance().getConnection());
                command.Prepare();
                LogUtility.printQueryLog(Configurator.getInstsance().get("books.countall.query"), null);
                MySqlDataReader reader = command.ExecuteReader();
                if (reader != null && reader.HasRows)
                {
                    while (reader.Read())
                    {
                        value = reader.GetInt32("cnt");
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
                throw new VideoBookException(ApplicationErrorType.COUNT_BOOK_ERROR);
            }
        }

        public int countElement(object value)
        {
            throw new NotImplementedException();
        }
    }
}
