using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoBookApplication.common.enums;
using VideoBookApplication.common.utility;

namespace VideoBookApplication.common.controls
{
    public class DatabaseControl : IDatabaseControl
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static DatabaseControl instance;
        public static Boolean isOpenConnection = false;

        private MySqlConnection dbConnection = null;
        private ApplicationErrorType statusConnection = ApplicationErrorType.NOT_INIT_WARN;

        private DatabaseControl()
        {
            statusConnection = openConnection();
        }

        private string getConnectionString()
        {
            string myConnectionString = "server={0};uid={1};pwd={2};database={3};";
            string val = String.Format(myConnectionString, Configurator.getInstsance().get("db.host"),
                Configurator.getInstsance().get("db.user"),
                Configurator.getInstsance().get("db.password"),
                Configurator.getInstsance().get("db.schema"));
            log.Info(val);
            return val;
        }

        public static DatabaseControl getInstance()
        {
            if (isOpenConnection == false)
            {
                instance = new DatabaseControl();
                isOpenConnection = true;
            }

            return instance;
        }


        public enums.ApplicationErrorType openConnection()
        {
            statusConnection = ApplicationErrorType.SUCCESS;
            try
            {
                dbConnection = null;
                dbConnection = new MySqlConnection(getConnectionString());
                dbConnection.Open();
            }
            catch (Exception e)
            {
                log.Error(e.Message);
                statusConnection = ApplicationErrorType.CONNECTION_ERROR;
            }
            return statusConnection;
        }

        public void closeConnection()
        {
            if ((isOpenConnection || statusConnection == ApplicationErrorType.NOT_INIT_WARN) && dbConnection != null)
            {
                dbConnection.Close();
                dbConnection = null;
                statusConnection = ApplicationErrorType.NOT_INIT_WARN;
                isOpenConnection = false;
            }
        }

        public MySqlConnection getConnection()
        {
            if (isOpenConnection && statusConnection == ApplicationErrorType.SUCCESS && dbConnection != null)
            {
                return dbConnection;
            }
            else
            {
                throw new VideoBookException(ApplicationErrorType.CONNECTION_ERROR);
            }
        }


        public ApplicationErrorType getStatus()
        {
            return statusConnection;
        }
    }
}
