﻿using System;
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
    public class UserDao : IGenericInDao<UsersModel>, IGenericOutDao<UsersModel>
    {

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public void write(UsersModel obj)
        {
            MySqlTransaction transaction = DatabaseControl.getInstance().getConnection().BeginTransaction();
            try
            {
                String query = Configurator.getInstsance().get("users.insert.query");

                //Prepare Command
                MySqlCommand command = new MySqlCommand(query, DatabaseControl.getInstance().getConnection());
                command.Prepare();
                //@user, @fllib, @flvid, @flmus, @flsw, @flsus
                command.Parameters.AddWithValue("@user", obj.userName);
                command.Parameters.AddWithValue("@fllib", obj.flLibrary);
                command.Parameters.AddWithValue("@flvid", obj.flVideo);
                command.Parameters.AddWithValue("@flmus", obj.flMusic);
                command.Parameters.AddWithValue("@flsw", obj.flSoftware);
                command.Parameters.AddWithValue("@flsus", obj.flSuperUser);

                LogUtility.printQueryLog(query, obj.userName, obj.flLibrary.ToString(), obj.flVideo.ToString(), obj.flMusic.ToString(), obj.flSoftware.ToString(), obj.flSuperUser.ToString());

                //Execute Command
                command.ExecuteNonQuery();

                command.Dispose();


                //Commit
                transaction.Commit();
            }
            catch (Exception e)
            {
                transaction.Rollback();
                log.Error(e.Message);
                throw new VideoBookException(ApplicationErrorType.WRITE_USER_ERROR);
            }
        }

        public UsersModel readOne(object value)
        {
            if (value.GetType() == typeof(String))
            {
                return getUserByName((String)value);
            }
            throw new VideoBookException(ApplicationErrorType.INVALID_VALUE);
        }

        public IEnumerable<UsersModel> readMany(object value)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UsersModel> readAll()
        {
            throw new NotImplementedException();
        }


        private UsersModel getUserByName(String user)
        {
            UsersModel model = null;
            MySqlDataReader reader = null;
            MySqlCommand command = null;
            try
            {
                String query = Configurator.getInstsance().get("users.read.query");

                //Prepare Command
                command = new MySqlCommand(query, DatabaseControl.getInstance().getConnection());
                command.Prepare();
                command.Parameters.AddWithValue("@user", user);
                LogUtility.printQueryLog(query, user);

                reader = command.ExecuteReader();
                if (reader != null && reader.HasRows) {
                    while (reader.Read()) {
                        if (model == null) {
                            model = new UsersModel();
                        }
                        model.userName = reader.GetString("USERNAME");
                        model.flLibrary = reader.GetBoolean("FL_LIBRARY");
                        model.flVideo = reader.GetBoolean("FL_VIDEO");
                        model.flMusic = reader.GetBoolean("FL_MUSIC");
                        model.flSoftware = reader.GetBoolean("FL_SOFTWARE");
                        model.flSuperUser = reader.GetBoolean("FL_SUPERUSER");

                    }
                }

                return model;
            }
            catch (Exception e)
            {
                log.Error(e.Message);
                throw new VideoBookException(ApplicationErrorType.READ_USER_ERROR);
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


        public void update(UsersModel obj)
        {
            throw new VideoBookException(ApplicationErrorType.NOT_IMPLEMENTED);
        }
    }
}
