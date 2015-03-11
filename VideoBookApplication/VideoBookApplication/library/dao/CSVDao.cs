using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoBookApplication.common.dao;
using VideoBookApplication.common.enums;
using VideoBookApplication.common.utility;
using VideoBookApplication.library.model.database;

namespace VideoBookApplication.library.dao
{
    public class CSVDao : IGenericOutDao<CSVModel>
    {
        public CSVModel readOne(object value)
        {
            throw new VideoBookException(ApplicationErrorType.NOT_IMPLEMENTED);
        }

        public IEnumerable<CSVModel> readMany(object value)
        {
            throw new VideoBookException(ApplicationErrorType.NOT_IMPLEMENTED);
        }

        public IEnumerable<CSVModel> readAll()
        {
            throw new VideoBookException(ApplicationErrorType.NOT_IMPLEMENTED);
        }
    }
}
