using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoBookApplication.library.model.database
{
    public class AuthorModel
    {
        public int idAutore { get; set; }
        public string cognome {get; set;}
        public string nome { get; set; }
        public List<BookModel> libri { get; set; }
    }
}
