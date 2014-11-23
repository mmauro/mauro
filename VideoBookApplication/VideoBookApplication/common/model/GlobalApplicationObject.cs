using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoBookApplication.common.enums;
using VideoBookApplication.common.model.database;

namespace VideoBookApplication.common.model
{
    public class GlobalApplicationObject : IApplicationObject
    {
        public UsersModel user { get; set;}

        public ActivityType activity { get; set; }

        public GlobalApplicationObject() 
        {
            activity = ActivityType.UNDEFINED;
            user = null;
        }

        public void destroy()
        {
            user = null;
            activity = ActivityType.UNDEFINED;
        }
    }
}
