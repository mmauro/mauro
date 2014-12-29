using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoBookApplication.library.model.database
{
    public class BookInfoModel
    {
        public int idInfoLibro { get; set; }
        public string image { get; set; }
        public string publisher { get; set; }
        public string isbn { get; set; }
        public string trama { get; set; }
        public string year { get; set; }
        public string urlScheda { get; set; }
    }
}
