using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using VideoBookApplication.common.model.database;
using VideoBookApplication.common.controls;
using VideoBookApplication.common.utility;
using VideoBookApplication.common.enums;

namespace VideoBookApplication.common.dao
{
    public class ReservedDao : IGenericInDao<ReservedModel>, IGenericOutDao<ReservedModel>
    {

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public void write(ReservedModel obj)
        {
            MySqlTransaction transaction = DatabaseControl.getInstance().getConnection().BeginTransaction();
            try
            {
                String query = Configurator.getInstsance().get("reserved.insert.query");

                //Prepare Command
                MySqlCommand command = new MySqlCommand(query, DatabaseControl.getInstance().getConnection());
                command.Prepare();

                command.Parameters.AddWithValue("@res", obj.reserved);
                command.Parameters.AddWithValue("@typeres", obj.reservedType);
                LogUtility.printQueryLog(query, obj.reserved, obj.reservedType.ToString());
                //Execute Command
                command.ExecuteNonQuery();

                //Commit
                transaction.Commit();
            }
            catch (Exception e)
            {
                transaction.Rollback();
                log.Error(e.Message);
                throw new VideoBookException(ApplicationErrorType.WRITE_RESERVED_ERROR);
            }
        }

        public ReservedModel readOne(object value)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ReservedModel> readMany(object value)
        {
            List<ReservedModel> arrayReserved = new List<ReservedModel>();
            MySqlDataReader reader = null;
            MySqlCommand command = null;
            try
            {
                int type = (int)value;

                String query = Configurator.getInstsance().get("reserved.read.query");
                command = new MySqlCommand(query, DatabaseControl.getInstance().getConnection());
                command.Prepare();
                command.Parameters.AddWithValue("@typeres", type);

                LogUtility.printQueryLog(query, type.ToString());

                reader = command.ExecuteReader();
                if (reader != null && reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ReservedModel model = new ReservedModel();
                        model.reserved = reader.GetString("RESERVED");
                        model.reservedType = reader.GetInt32("TYPE_RESERVED");
                        arrayReserved.Add(model);
                    }
                }


                return arrayReserved;
            }
            catch (Exception e)
            {
                log.Error(e.Message);
                throw new VideoBookException(ApplicationErrorType.READ_RESERVED_ERROR);
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

        public IEnumerable<ReservedModel> readAll()
        {
            throw new NotImplementedException();
        }


        public void update(ReservedModel obj)
        {
            throw new VideoBookException(ApplicationErrorType.NOT_IMPLEMENTED);
        }
    }
}
