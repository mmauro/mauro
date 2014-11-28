using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoBookApplication.common.enums;
using VideoBookApplication.common.utility;
using VideoBookApplication.library.dao;
using VideoBookApplication.library.model.database;

namespace VideoBookApplication.library.controls
{
    class PositionControl
    {

        private PositionDao positionDao = new PositionDao();

        public ApplicationErrorType write(string position)
        {
            ApplicationErrorType status = ApplicationErrorType.SUCCESS;
            if (position != null && !position.Trim().Equals(""))
            {
                try
                {
                    if (read(position) == null)
                    {
                        PositionModel model = new PositionModel();
                        model.position = position.Trim();
                        positionDao.write(model);
                    }
                    else
                    {
                        status = ApplicationErrorType.POSITION_PRESENT;
                    }
                }
                catch (VideoBookException e)
                {
                    status = e.errorType;
                }
            }
            else
            {
                status = ApplicationErrorType.EMPTY_POSITION;
            }

            return status;
        }

        public PositionModel read(string position)
        {
            try
            {
                PositionModel model = positionDao.readOne(position);
                return model;
            }
            catch (VideoBookException e)
            {
                throw e;
            }
        }
    }


}
