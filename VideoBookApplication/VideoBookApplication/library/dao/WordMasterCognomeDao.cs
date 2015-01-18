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
    public class WordMasterCognomeDao : IGenericOutDao<WordMasterCognomeModel>, IGenericInDao<WordMasterCognomeModel>
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public WordMasterCognomeModel readOne(object value)
        {
            try
            {
                String word = (string)value;
                String query = Configurator.getInstsance().get("word2cognome.readone.query");
                MySqlCommand command = new MySqlCommand(query, DatabaseControl.getInstance().getConnection());
                command.Prepare();
                command.Parameters.AddWithValue("@wcognome", word);

                LogUtility.printQueryLog(query, word);

                WordMasterCognomeModel model = null;
                MySqlDataReader reader = command.ExecuteReader();
                if (reader != null && reader.HasRows)
                {

                    //Inizializzo Modello
                    model = new WordMasterCognomeModel();
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
                reader.Close();
                command.Dispose();

                return model;
            }
            catch (Exception e)
            {
                log.Error(e.Message);
                throw new VideoBookException(ApplicationErrorType.READ_WORD_ERROR);
            }
        }

        public IEnumerable<WordMasterCognomeModel> readMany(object value)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<WordMasterCognomeModel> readAll()
        {
            throw new NotImplementedException();
        }

        public void write(WordMasterCognomeModel obj)
        {
            throw new NotImplementedException();
        }
    }
}
