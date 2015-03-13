using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoBookApplication.library.model.database
{
    public class ReportModel
    {
        public string cognome { get; set; }
        public string nome { get; set; }
        public string titolo { get; set; }
        public string serie { get; set; }
        public bool flEbook { get; set; }
        public string categoria { get; set; }
        public string posizione { get; set; }
        public string nota { get; set; }
        public string editore { get; set; }
        public string trama { get; set; }
        public string annoPubblicazione { get; set; }
        public string isbn { get; set; }
        public string img { get; set; }
        public DateTime dtInsert { get; set; }
    }
}
