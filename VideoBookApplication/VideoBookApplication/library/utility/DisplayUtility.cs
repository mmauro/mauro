using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoBookApplication.common.utility;
using VideoBookApplication.library.model.database;

namespace VideoBookApplication.library.utility
{
    public class DisplayUtility
    {
        public static string formatAuthorName(AuthorModel autore)
        {
            string name = "";
            if (autore != null)
            {
                if (autore.nome != null && !autore.nome.Trim().Equals(""))
                {
                    name += StringUtility.capitalize(autore.nome) + " ";
                }
                name += autore.cognome;
            }
            return name;
        }

        public static string formatCategory(string category)
        {
            string cat = "";
            if (category != null && !category.Equals("")) 
            {
                if (category.Equals(Configurator.getInstsance().get("catpos.default.value")))
                {
                    cat = "Non Disponibile";
                }
                else
                {
                    cat = StringUtility.capitalize(category);
                }
            }

            return cat;
        }
    }
}
