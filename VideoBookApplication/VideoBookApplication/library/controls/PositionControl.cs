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
        public ApplicationErrorType write(string position)
        {
            ApplicationErrorType status = ApplicationErrorType.SUCCESS;
            if (position != null && !position.Equals(""))
            {
                try
                {
                    PositionModel model = new PositionModel();
                    model.position = position;
                    PositionDao positionDao = new PositionDao();
                    positionDao.write(model);
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
    }
}
