using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoBookApplication.common.dao
{
    interface IStatisticsDao
    {
        int countElement();
        int countElement(Object value);
    }
}
