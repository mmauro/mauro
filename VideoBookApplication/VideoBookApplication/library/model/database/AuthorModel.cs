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
            if (idAutore > 0)
            {
                return idAutore;
            }
            else
            {
                String value = cognome + nome;
                return value.GetHashCode();
            }
        }

        public bool Equals(AuthorModel other)
        {
            if (idAutore > 0 && other.idAutore > 0)
            {
                return (idAutore == other.idAutore);
            }
            else
            {
                return (cognome.Equals(other.cognome) && nome.Equals(other.nome));
            }
        }
    }
}
