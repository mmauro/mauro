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

        public override int GetHashCode()
        {
            int hash = -1;
            if (idAutore > 0)
            {
                hash = idAutore;
            }
            else
            {
                String value = cognome + nome;
                hash = value.GetHashCode();
            }

            return hash;
        }

    }
}
