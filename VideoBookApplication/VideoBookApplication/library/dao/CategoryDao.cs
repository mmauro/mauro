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
            MySqlDataReader reader = null;
            MySqlCommand command = null;
            try
            {
                String query = Configurator.getInstsance().get("category.readall.query");
                command = new MySqlCommand(query, DatabaseControl.getInstance().getConnection());
                command.Prepare();
                LogUtility.printQueryLog(query, null);

                CategoryModel model = null;
                reader = command.ExecuteReader();
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

                return arrayCat;
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


        private CategoryModel readCategoryByName(string category)
        {
            MySqlDataReader reader = null;
            MySqlCommand command = null;
            try
            {
                String query = Configurator.getInstsance().get("category.read.query");
                command = new MySqlCommand(query, DatabaseControl.getInstance().getConnection());
                command.Prepare();
                command.Parameters.AddWithValue("@cat", category);

                LogUtility.printQueryLog(query, category);

                CategoryModel model = null;
                reader = command.ExecuteReader();
                if (reader != null && reader.HasRows)
                {
                    while (reader.Read())
                    {
                        model = new CategoryModel();
                        model.idCategory = reader.GetInt32("ID_CATEGORIA");
                        model.category = reader.GetString("CATEGORIA");
                    }
                }

                return model;
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

        private CategoryModel readCategoryById(int category)
        {
            MySqlDataReader reader = null;
            MySqlCommand command = null;
            try
            {
                String query = Configurator.getInstsance().get("category.readbyid.query");
                command = new MySqlCommand(query, DatabaseControl.getInstance().getConnection());
                command.Prepare();
                command.Parameters.AddWithValue("@idcat", category);

                LogUtility.printQueryLog(query, category.ToString());

                CategoryModel model = null;
                reader = command.ExecuteReader();
                if (reader != null && reader.HasRows)
                {
                    while (reader.Read())
                    {
                        model = new CategoryModel();
                        model.idCategory = reader.GetInt32("ID_CATEGORIA");
                        model.category = reader.GetString("CATEGORIA");
                    }
                }

                return model;
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




        public void update(CategoryModel obj)
        {
            MySqlTransaction transaction = DatabaseControl.getInstance().getConnection().BeginTransaction();
            try
            {
                String query = Configurator.getInstsance().get("category.update.query");

                //Prepare Command
                MySqlCommand command = new MySqlCommand(query, DatabaseControl.getInstance().getConnection());
                command.Prepare();
                command.Parameters.AddWithValue("@newcat", obj.category);
                command.Parameters.AddWithValue("@idcat", obj.idCategory);
                LogUtility.printQueryLog(query, obj.category, obj.idCategory.ToString());

                //Execute Command
                command.ExecuteNonQuery();

                //Commit
                transaction.Commit();
            }
            catch (Exception e)
            {
                transaction.Rollback();
                log.Error(e.Message);
                throw new VideoBookException(ApplicationErrorType.UPDATE_CAT_ERROR);
            }
        }
    }
}
