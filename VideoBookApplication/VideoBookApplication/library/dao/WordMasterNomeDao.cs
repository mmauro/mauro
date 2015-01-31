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
    public class WordMasterNomeDao : IGenericInDao<WordMasterNomeModel>, IGenericOutDao<WordMasterNomeModel>
    {

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public void write(WordMasterNomeModel obj)
        {
            throw new NotImplementedException();
        }

        public WordMasterNomeModel readOne(object value)
        {
            MySqlDataReader reader = null;
            MySqlCommand command = null;
            try
            {
                String word = (string)value;
                String query = Configurator.getInstsance().get("word2nome.readone.query");
                command = new MySqlCommand(query, DatabaseControl.getInstance().getConnection());
                command.Prepare();
                command.Parameters.AddWithValue("@wnome", word);

                LogUtility.printQueryLog(query, word);

                WordMasterNomeModel model = null;
                reader = command.ExecuteReader();
                if (reader != null && reader.HasRows)
                {

                    //Inizializzo Modello
                    model = new WordMasterNomeModel();
                    model.autori = new List<AuthorModel>();
                    while (reader.Read())
                    {
                        model.word = reader.GetString("WORD");
                        model.idWord = reader.GetInt32("ID_WORD");

                        AuthorModel modelAutore = new AuthorModel();
                        modelAutore.libri = new List<BookModel>();

                        modelAutore.idAutore = reader.GetInt32("ID_AUTORE");
                        modelAutore.cognome = reader.GetString("COGNOME");
                        modelAutore.nome = reader.GetString("NOME");

                        model.autori.Add(modelAutore);

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

        public IEnumerable<WordMasterNomeModel> readMany(object value)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<WordMasterNomeModel> readAll()
        {
            throw new NotImplementedException();
        }
    }
}
