using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoBookApplication.common.model;
using VideoBookApplication.library.model.database;

namespace VideoBookApplication.library.model
{
    public class TempLibraryModel : IApplicationObject
    {

        public BookInfoModel infoModel { get; set; }
        public BookModel libro { get; set; }


        public void destroy()
        {
            infoModel = null;
            libro = null;
        }
    }
}
