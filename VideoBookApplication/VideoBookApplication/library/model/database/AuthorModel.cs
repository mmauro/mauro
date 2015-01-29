using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoBookApplication.library.model.database
{
    public class AuthorModel
    {

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

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
                //return value.GetHashCode();
            }

            log.Info("HC - " + hash.ToString());
            return hash;

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
