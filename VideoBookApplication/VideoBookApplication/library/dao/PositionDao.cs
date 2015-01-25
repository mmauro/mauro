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
            if (value.GetType() == typeof(string))
            {
                return readPositionByName((string)value);
            }
            else
            {
                return readPositionById((int)value);
            }

        }

        public IEnumerable<PositionModel> readMany(object value)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PositionModel> readAll()
        {
            List<PositionModel> arrayPos = new List<PositionModel>();

            try
            {
                String query = Configurator.getInstsance().get("position.readall.query");
                MySqlCommand command = new MySqlCommand(query, DatabaseControl.getInstance().getConnection());
                command.Prepare();
                LogUtility.printQueryLog(query, null);

                PositionModel model = null;
                MySqlDataReader reader = command.ExecuteReader();
                if (reader != null && reader.HasRows)
                {
                    while (reader.Read())
                    {
                        model = new PositionModel();
                        model.idPosition = reader.GetInt32("ID_POSIZIONE");
                        model.position = reader.GetString("POSIZIONE");
                        arrayPos.Add(model);
                    }
                }
                if (reader != null)
                {
                    reader.Close();
                }
                command.Dispose();

                return arrayPos;
            }
            catch (Exception e)
            {
                log.Error(e.Message);
                throw new VideoBookException(ApplicationErrorType.READ_POS_ERROR);
            }
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
                throw new VideoBookException(ApplicationErrorType.WRITE_POS_ERROR);
            }
        }

        private PositionModel readPositionByName(string position) 
        {
            try
            {
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
                if (reader != null)
                {
                    reader.Close();
                }

                command.Dispose();

                return model;
            }
            catch (Exception e)
            {
                log.Error(e.Message);
                throw new VideoBookException(ApplicationErrorType.READ_POS_ERROR);
            }

        }

        private PositionModel readPositionById(int position)
        {
            try
            {
                String query = Configurator.getInstsance().get("position.readbyid.query");
                MySqlCommand command = new MySqlCommand(query, DatabaseControl.getInstance().getConnection());
                command.Prepare();
                command.Parameters.AddWithValue("@idpos", position);

                LogUtility.printQueryLog(query, position.ToString());

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

                if (reader != null)
                {
                    reader.Close();
                }

                command.Dispose();

                return model;
            }
            catch (Exception e)
            {
                log.Error(e.Message);
                throw new VideoBookException(ApplicationErrorType.READ_POS_ERROR);
            }

        }

    }
}
