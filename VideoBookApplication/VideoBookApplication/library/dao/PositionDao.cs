using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using VideoBookApplication.common.dao;
using VideoBookApplication.common.controls;
using VideoBookApplication.common.utility;
using VideoBookApplication.common.enums;
using VideoBookApplication.library.model.database;


namespace VideoBookApplication.library.dao
{
    class PositionDao : IGenericOutDao<PositionModel>, IGenericInDao<PositionModel>
    {

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public PositionModel readOne(object value)
        {
            try
            {
                String position = (string)value;
                String query = Configurator.getInstsance().get("position.read.query");
                MySqlCommand command = new MySqlCommand(query, DatabaseControl.getInstance().getConnection());
                command.Prepare();
                command.Parameters.AddWithValue("@pos", position);

                LogUtility.printQueryLog(query, position);

                PositionModel model = null;
                MySqlDataReader reader = command.ExecuteReader();
                if (reader != null && reader.HasRows)
                {
                    while (reader.Read())
                    {
                        model = new PositionModel();
                        model.idPosition = reader.GetInt32("ID_POSIZIONE");
                        model.position = reader.GetString("POSIZIONE");
                    }
                }
                reader.Close();
                command.Dispose();

                return model;
            }
            catch (Exception e)
            {
                log.Error(e.Message);
                throw new VideoBookException(ApplicationErrorType.DB_READ_ERROR);
            }

        }

        public IEnumerable<PositionModel> readMany(object value)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PositionModel> readAll()
        {
            throw new NotImplementedException();
        }

        public void write(PositionModel obj)
        {
            MySqlTransaction transaction = DatabaseControl.getInstance().getConnection().BeginTransaction();
            try
            {
                String query = Configurator.getInstsance().get("position.insert.query");

                //Prepare Command
                MySqlCommand command = new MySqlCommand(query, DatabaseControl.getInstance().getConnection());
                command.Prepare();
                command.Parameters.AddWithValue("@pos", obj.position);
                LogUtility.printQueryLog(query, obj.position);

                //Execute Command
                command.ExecuteNonQuery();

                //Commit
                transaction.Commit();
            }
            catch (Exception e)
            {
                transaction.Rollback();
                log.Error(e.Message);
                throw new VideoBookException(ApplicationErrorType.DB_WRITE_ERROR);
            }
        }
    }
}
