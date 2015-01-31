using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoBookApplication.common.controls;
using VideoBookApplication.common.enums;
using VideoBookApplication.common.utility;

namespace VideoBookApplication.library.dao
{
    public class StatDao
    {

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public Dictionary<string, int> countCategory()
        {

            MySqlDataReader reader = null;
            MySqlCommand command = null;
            try
            {
                String query = Configurator.getInstsance().get("stat.catbookcount.query");
                command = new MySqlCommand(query, DatabaseControl.getInstance().getConnection());
                command.Prepare();

                LogUtility.printQueryLog(query, null);

                Dictionary<string, int> categoryCount = null;
                reader = command.ExecuteReader();
                if (reader != null && reader.HasRows)
                {
                    categoryCount = new Dictionary<string, int>();

                    while (reader.Read())
                    {
                        categoryCount.Add(reader.GetString("CATEGORIA"), reader.GetInt32("cnt"));
                    }
                }

                return categoryCount;
            }
            catch (Exception e)
            {
                log.Error(e.Message);
                throw new VideoBookException(ApplicationErrorType.READ_CAT_ERROR);
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
    }
}
