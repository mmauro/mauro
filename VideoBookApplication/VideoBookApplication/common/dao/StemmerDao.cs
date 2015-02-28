using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoBookApplication.common.controls;
using VideoBookApplication.common.enums;
using VideoBookApplication.common.model.database;
using VideoBookApplication.common.utility;

namespace VideoBookApplication.common.dao
{
    public class StemmerDao : IGenericInDao<StemmerForceModel>, IGenericOutDao<StemmerForceModel>
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public void write(StemmerForceModel obj)
        {
            throw new NotImplementedException();
        }

        public StemmerForceModel readOne(object value)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<StemmerForceModel> readMany(object value)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<StemmerForceModel> readAll()
        {
            List<StemmerForceModel> stemmerList = new List<StemmerForceModel>();
            MySqlDataReader reader = null;
            MySqlCommand command = null;
            try
            {
                String query = Configurator.getInstsance().get("stemmer.readall.query");
                command = new MySqlCommand(query, DatabaseControl.getInstance().getConnection());
                command.Prepare();
                LogUtility.printQueryLog(query, null);

                StemmerForceModel model = null;
                reader = command.ExecuteReader();
                if (reader != null && reader.HasRows)
                {
                    while (reader.Read())
                    {
                        model = new StemmerForceModel();
                        model.word = reader.GetString("WORD");
                        model.stemmer = reader.GetString("STEM");
                        stemmerList.Add(model);
                    }
                }
                return stemmerList;
            }
            catch (Exception e)
            {
                log.Error(e.Message);
                throw new VideoBookException(ApplicationErrorType.READ_STEMMER_ERROR);
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


        public void update(StemmerForceModel obj)
        {
            throw new VideoBookException(ApplicationErrorType.NOT_IMPLEMENTED);
        }
    }
}
