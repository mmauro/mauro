using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoBookApplication.common.utility;

namespace VideoBookApplication.library.model.database
{
    public class BookModel
    {
        public int idLibro { get; set; }
        public string titolo { get; set; }
        public string serie { get; set; }
        public bool flEbook { get; set; }
        public DateTime dtInsert { get; set; }
        public AuthorModel autore { get; set; }
        public CategoryModel category { get; set; }
        public PositionModel position { get; set; }
        public BookNoteModel note { get; set; }
        public BookInfoModel informations { get; set; }

        public override int GetHashCode()
        {
            if (idLibro != Configurator.getInstsance().getInt("notfound.value"))
            {
                return idLibro;
            }
            else
            {
                string value = titolo;
                if (serie != null)
                {
                    value += " " + serie;
                }
                return value.GetHashCode();
            }
        }
    }
}
