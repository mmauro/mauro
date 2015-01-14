using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoBookApplication.common.model;
using VideoBookApplication.library.model.database;

namespace VideoBookApplication.library.model
{
    public class InputLibraryApplicationObject : IApplicationObject
    {
        public AuthorModel autore {get; set;}
        public List<BookModel> libri { get; set; }

        public IndexElementsObject indexElements { get; set; }

        public InputLibraryApplicationObject()
        {
            libri = new List<BookModel>();
            indexElements = new IndexElementsObject();
        }

        public void destroy()
        {
            autore = null;
            libri.Clear();
            libri = new List<BookModel>();
            indexElements.destroy();
        }
    }
}
