using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoBookApplication.common.model;
using VideoBookApplication.common.utility;
using VideoBookApplication.library.model.database;

namespace VideoBookApplication.library.model
{
    public class StatObject : IApplicationObject
    {

        public int numAutori { get; set; }
        public int numLibri { get; set; }
        public int numLibriCarta { get; set; }
        public int ebook { get; set; }
        public int media { get; set; }
        public Dictionary<string, int> categoryDistribution { get; set; }

        public BookModel lastBook {get; set; }


        public StatObject()
        {
            numAutori = Configurator.getInstsance().getInt("notfound.value");
            ebook = Configurator.getInstsance().getInt("notfound.value");
            numLibri = Configurator.getInstsance().getInt("notfound.value");
            media = Configurator.getInstsance().getInt("notfound.value");
            categoryDistribution = new Dictionary<string, int>();
            lastBook = null;
        }

        public void destroy()
        {
            numAutori = Configurator.getInstsance().getInt("notfound.value");
            ebook = Configurator.getInstsance().getInt("notfound.value");
            numLibri = Configurator.getInstsance().getInt("notfound.value");
            media = Configurator.getInstsance().getInt("notfound.value");
            categoryDistribution.Clear();
            categoryDistribution = new Dictionary<string, int>();
            lastBook = null;
        }
    }
}
