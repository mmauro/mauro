using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoBookApplication.library.utility
{
    public class CSVUtility
    {
        public static List<string> getCSVHeader()
        {
        
            List<string> header = new List<string>();
            header.Add("cognome");
            header.Add("nome");
            header.Add("titolo");
            header.Add("serie");
            header.Add("categoria");
            header.Add("posizione");
            header.Add("flEbook");
            header.Add("isbn");
            header.Add("editore");
            header.Add("annoPubblicazione");
            header.Add("img");
            header.Add("nota");
            header.Add("trama");
            header.Add("dtInsert");

            return header;

        }

        public static List<string> getCSVFirstRow()
        {

            List<string> header = new List<string>();
            header.Add("Cognome");
            header.Add("Nome");
            header.Add("Titolo");
            header.Add("Serie");
            header.Add("Categoria");
            header.Add("Posizione");
            header.Add("Ebook");
            header.Add("ISBN");
            header.Add("Editore");
            header.Add("Anno di Pubblicazione");
            header.Add("Immagine");
            header.Add("Nota");
            header.Add("Trama");
            header.Add("Data di Inserimento");

            return header;

        }

    }
}
