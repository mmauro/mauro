using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoBookApplication.common.enums;
using VideoBookApplication.common.model.database;
using VideoBookApplication.library.model;

namespace VideoBookApplication.common.model
{
    public class GlobalApplicationObject : IApplicationObject
    {
        public UsersModel user { get; set;}
        public LibraryApplicationObject libraryObject { get; set; }

        public GlobalOperation currentOperation { get; set; }

        public ActivityType activity { get; set; }

        public GlobalApplicationObject() 
        {
            libraryObject = new LibraryApplicationObject();
            activity = ActivityType.UNDEFINED;
            user = null;
            currentOperation = GlobalOperation.UNDEFINED;
        }

        public void destroy()
        {
            libraryObject.destroy();
            libraryObject = new LibraryApplicationObject();
            user = null;
            activity = ActivityType.UNDEFINED;
        }
    }
}
