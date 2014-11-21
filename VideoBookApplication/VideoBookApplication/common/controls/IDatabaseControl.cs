using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoBookApplication.common.enums;

namespace VideoBookApplication.common.controls
{
    public interface IDatabaseControl
    {
        ApplicationErrorType openConnection();
        void closeConnection();
        MySqlConnection getConnection();
        ApplicationErrorType getStatus();
    }
}
