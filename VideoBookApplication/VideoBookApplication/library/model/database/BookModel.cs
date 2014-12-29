using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoBookApplication.library.model.database
{
    public class BookModel
    {
        public int idLibro { get; set; }
        public string titolo { get; set; }
        public string serie { get; set; }
        public bool flEbook { get; set; }
        public AuthorModel autore { get; set; }
        public CategoryModel category { get; set; }
        public PositionModel position { get; set; }
        public BookNoteModel note { get; set; }
        public BookInfoModel informations { get; set; }
    }
}
