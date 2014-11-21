using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoBookApplication.common.dao;
using VideoBookApplication.common.enums;
using VideoBookApplication.common.model;
using VideoBookApplication.common.model.database;
using VideoBookApplication.common.utility;


namespace VideoBookApplication.common.controls
{
    class UsersControl
    {
        private UserDao userDao = new UserDao();

        public ApplicationErrorType writeUser(string username, bool flLibrary, bool flVideo, bool flMusic, bool flSw, bool flSuper)
        {
            ApplicationErrorType status = ApplicationErrorType.SUCCESS;
            if (username != null && username != "")
            {
                UsersModel um = new UsersModel();
                um.userName = username;
                um.flLibrary = flLibrary;
                um.flMusic = flMusic;
                um.flVideo = flVideo;
                um.flSoftware = flSw;
                um.flSuperUser = flSuper;

                try
                {
                    userDao.write(um);           
                }
                catch (VideoBookException e)
                {
                    status = e.errorType;
                }

            }
            else
            {
                status = ApplicationErrorType.EMPTY_USERNAME;
            }
            return status;
        }

        public ApplicationErrorType selectUser(ref GlobalApplicationObject applicationObject, String userName)
        {
            ApplicationErrorType status = ApplicationErrorType.SUCCESS;
            if (userName != null && userName != "")
            {
                //Search userName on DB
                UsersModel model = userDao.readOne(userName);
                if (model != null)
                {
                    applicationObject.user = model;
                }
                else
                {
                    status = ApplicationErrorType.USER_NOT_FOUND;
                }

            }
            else
            {
                status = ApplicationErrorType.EMPTY_USERNAME;
            }

            return status;
        }
    }
}
