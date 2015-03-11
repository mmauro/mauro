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

            return header;

        } 
    }
}
