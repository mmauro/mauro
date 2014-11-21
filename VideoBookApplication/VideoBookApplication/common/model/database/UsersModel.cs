using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoBookApplication.common.model.database
{
    public class UsersModel
    {
        public string userName { get; set; }
        public bool flLibrary { get; set; }
        public bool flVideo { get; set; }
        public bool flMusic { get; set; }
        public bool flSoftware { get; set; }
        public bool flSuperUser { get; set; }

    }
}
