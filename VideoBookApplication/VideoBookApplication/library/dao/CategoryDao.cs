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
    class CategoryDao : IGenericInDao<CategoryModel>, IGenericOutDao<CategoryModel>
    {

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public void write(CategoryModel obj)
        {
            MySqlTransaction transaction = DatabaseControl.getInstance().getConnection().BeginTransaction();
            try
            {
                String query = Configurator.getInstsance().get("category.insert.query");
                log.Info(query);

                //Prepare Command
                MySqlCommand command = new MySqlCommand(query, DatabaseControl.getInstance().getConnection());
                command.Prepare();
                command.Parameters.AddWithValue("@cat", obj.category);

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

        public CategoryModel readOne(object value)
        {

            try
            {
                String category = (string)value;
                String query = Configurator.getInstsance().get("category.read.query");
                MySqlCommand command = new MySqlCommand(query, DatabaseControl.getInstance().getConnection());
                command.Prepare();
                command.Parameters.AddWithValue("@cat", category.ToLower());

                LogUtility.printQueryLog(query, category.ToLower());

                CategoryModel model = null;
                MySqlDataReader reader = command.ExecuteReader();
                if (reader != null && reader.HasRows)
                {
                    while (reader.Read())
                    {
                        model = new CategoryModel();
                        model.idCategory = reader.GetInt32("ID_CATEGORIA");
                        model.category = reader.GetString("CATEGORIA");
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

        public IEnumerable<CategoryModel> readMany(object value)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CategoryModel> readAll()
        {
            throw new NotImplementedException();
        }
    }
}
