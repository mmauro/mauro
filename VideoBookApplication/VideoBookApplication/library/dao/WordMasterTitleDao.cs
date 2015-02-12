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
    public class WordMasterTitleDao : IGenericInDao<WordMasterLibriModel>, IGenericOutDao<WordMasterLibriModel>
    {

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public WordMasterLibriModel readOne(object value)
        {
            MySqlDataReader reader = null;
            MySqlCommand command = null;
            try
            {
                String word = (string)value;
                String query = Configurator.getInstsance().get("word2libro.readone.query");
                command = new MySqlCommand(query, DatabaseControl.getInstance().getConnection());
                command.Prepare();
                command.Parameters.AddWithValue("@wtitle", word);

                LogUtility.printQueryLog(query, word);

                WordMasterLibriModel model = null;
                reader = command.ExecuteReader();
                if (reader != null && reader.HasRows)
                {

                    //Inizializzo Modello
                    model = new WordMasterLibriModel();
                    model.libri = new List<BookModel>();
                    while (reader.Read())
                    {
                        model.word = reader.GetString("WORD");
                        model.idWord = reader.GetInt32("ID_WORD");

                        AuthorModel authorModel = new AuthorModel();
                        BookModel bookModel = new BookModel();
                        BookInfoModel bookInfoModel = null;
                        BookNoteModel bookNoteModel = null;
                        CategoryModel catModel = null;
                        PositionModel posModel = null;

                        bookModel.idLibro = reader.GetInt32("ID_LIBRO");
                        bookModel.titolo = reader.GetString("TITOLO");
                        bookModel.serie = reader.GetString("SERIE");
                        bookModel.flEbook = reader.GetBoolean("FL_EBOOK");
                        bookModel.dtInsert = reader.GetDateTime("DT_INSERT");

                        if (reader.GetInt32("ID_POSIZIONE") != Configurator.getInstsance().getInt("notfound.value"))
                        {
                            posModel = new PositionModel();
                            posModel.idPosition = reader.GetInt32("ID_POSIZIONE");
                            posModel.position = reader.GetString("POSIZIONE");
                        }

                        if (reader.GetInt32("ID_CATEGORIA") != Configurator.getInstsance().getInt("notfound.value"))
                        {
                            catModel = new CategoryModel();
                            catModel.idCategory = reader.GetInt32("ID_CATEGORIA");
                            catModel.category = reader.GetString("CATEGORIA");
                        }

                        if (reader.GetInt32("ID_NOTA") != Configurator.getInstsance().getInt("notfound.value"))
                        {
                            bookNoteModel = new BookNoteModel();
                            bookNoteModel.idNota = reader.GetInt32("ID_NOTA");
                            bookNoteModel.nota = reader.GetString("NOTA");
                        }

                        if (reader.GetInt32("ID_INFOLIBRO") != Configurator.getInstsance().getInt("notfound.value"))
                        {
                            bookInfoModel = new BookInfoModel();
                            bookInfoModel.idInfoLibro = reader.GetInt32("ID_INFOLIBRO");
                            bookInfoModel.image = reader.GetString("IMG");
                            bookInfoModel.isbn = reader.GetString("ISBN");
                            bookInfoModel.publisher = reader.GetString("EDITORE");
                            bookInfoModel.trama = reader.GetString("TRAMA").Trim();
                            bookInfoModel.urlScheda = reader.GetString("URL_SCHEDA");
                            bookInfoModel.year = reader.GetString("YEAR");
                        }

                        authorModel.idAutore = reader.GetInt32("ID_AUTORE");
                        authorModel.cognome = reader.GetString("COGNOME");
                        authorModel.nome = reader.GetString("NOME");

                        bookModel.category = catModel;
                        bookModel.position = posModel;
                        bookModel.informations = bookInfoModel;
                        bookModel.note = bookNoteModel;
                        bookModel.autore = authorModel;

                        model.libri.Add(bookModel);
                    }
                }

                return model;
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

        public IEnumerable<WordMasterLibriModel> readMany(object value)
        {
            throw new VideoBookException(ApplicationErrorType.NOT_IMPLEMENTED);
        }

        public IEnumerable<WordMasterLibriModel> readAll()
        {
            throw new VideoBookException(ApplicationErrorType.NOT_IMPLEMENTED);
        }

        public void write(WordMasterLibriModel obj)
        {
            throw new VideoBookException(ApplicationErrorType.NOT_IMPLEMENTED);
        }
    }
}
