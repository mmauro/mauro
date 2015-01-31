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
    public class AuthorDao : IGenericOutDao<AuthorModel>, IGenericInDao<AuthorModel>, IStatisticsDao
    {

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public AuthorModel readOne(object value)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AuthorModel> readMany(object value)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AuthorModel> readAll()
        {
            throw new NotImplementedException();
        }

        public void write(AuthorModel obj)
        {
            throw new NotImplementedException();
        }

        public int countElement()
        {
            int value = Configurator.getInstsance().getInt("notfound.value");
            MySqlDataReader reader = null;
            MySqlCommand command = null;
            try
            {
                command = new MySqlCommand(Configurator.getInstsance().get("author.countall.query"), DatabaseControl.getInstance().getConnection());
                command.Prepare();
                LogUtility.printQueryLog(Configurator.getInstsance().get("author.countall.query"), null);
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
            throw new NotImplementedException();
        }
    }
}
