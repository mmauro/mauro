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

                //Prepare Command
                MySqlCommand command = new MySqlCommand(query, DatabaseControl.getInstance().getConnection());
                command.Prepare();
                command.Parameters.AddWithValue("@cat", obj.category);
                LogUtility.printQueryLog(query, obj.category);


                //Execute Command
                command.ExecuteNonQuery();

                //Commit
                transaction.Commit();
            }
            catch (Exception e)
            {
                transaction.Rollback();
                log.Error(e.Message);
                throw new VideoBookException(ApplicationErrorType.WRITE_CAT_ERROR);
            }
        }

        public CategoryModel readOne(object value)
        {
            if (value.GetType() == typeof(string))
            {
                return readCategoryByName((string)value);
            }
            else
            {
                return readCategoryById((int)value);
            }


        }

        public IEnumerable<CategoryModel> readMany(object value)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CategoryModel> readAll()
        {
            List<CategoryModel> arrayCat = new List<CategoryModel>();

            try
            {
                String query = Configurator.getInstsance().get("category.readall.query");
                MySqlCommand command = new MySqlCommand(query, DatabaseControl.getInstance().getConnection());
                command.Prepare();
                LogUtility.printQueryLog(query, null);

                CategoryModel model = null;
                MySqlDataReader reader = command.ExecuteReader();
                if (reader != null && reader.HasRows)
                {
                    while (reader.Read())
                    {
                        model = new CategoryModel();
                        model.idCategory = reader.GetInt32("ID_CATEGORIA");
                        model.category = reader.GetString("CATEGORIA");
                        arrayCat.Add(model);
                    }
                }

                if (reader != null)
                {
                    reader.Close();
                }
                command.Dispose();

                return arrayCat;
            }
            catch (Exception e)
            {
                log.Error(e.Message);
                throw new VideoBookException(ApplicationErrorType.READ_CAT_ERROR);
            }

        }


        private CategoryModel readCategoryByName(string category)
        {
            try
            {
                String query = Configurator.getInstsance().get("category.read.query");
                MySqlCommand command = new MySqlCommand(query, DatabaseControl.getInstance().getConnection());
                command.Prepare();
                command.Parameters.AddWithValue("@cat", category);

                LogUtility.printQueryLog(query, category);

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
                throw new VideoBookException(ApplicationErrorType.READ_CAT_ERROR);
            }
        }

        private CategoryModel readCategoryById(int category)
        {
            try
            {
                String query = Configurator.getInstsance().get("category.readbyid.query");
                MySqlCommand command = new MySqlCommand(query, DatabaseControl.getInstance().getConnection());
                command.Prepare();
                command.Parameters.AddWithValue("@idcat", category);

                LogUtility.printQueryLog(query, category.ToString());

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
                throw new VideoBookException(ApplicationErrorType.READ_CAT_ERROR);
            }
        }


    }
}
