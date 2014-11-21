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
    class CategoryControls
    {
        public ApplicationErrorType write(string cat)
        {
            ApplicationErrorType status = ApplicationErrorType.SUCCESS;
            if (cat != null && !cat.Equals(""))
            {
                try
                {
                    CategoryModel model = new CategoryModel();
                    model.category = cat;
                    CategoryDao categoryDao = new CategoryDao();
                    categoryDao.write(model);
                }
                catch (VideoBookException e)
                {
                    status = e.errorType;
                }
            }
            else
            {
                status = ApplicationErrorType.EMPTY_CATEGORY;
            }

            return status;
        }
    }
}
