using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoBookApplication.common.model;
using VideoBookApplication.library.model.database;

namespace VideoBookApplication.library.model
{
    public class IndexElementsObject : IApplicationObject
    {
        public List<string> wordsCognome {get; set;}
        public List<string> wordsNome { get; set; }
        public Dictionary<BookModel, List<String>> wordBooksTitle { get; set; }

        public IndexElementsObject()
        {
            wordsCognome = new List<string>();
            wordsNome = new List<string>();
            wordBooksTitle = new Dictionary<BookModel, List<string>>();
        }


        public void destroy()
        {
            wordBooksTitle.Clear();
            wordBooksTitle = new Dictionary<BookModel, List<string>>();
            wordsCognome.Clear();
            wordsCognome = new List<string>();
            wordsNome.Clear();
            wordsNome = new List<string>();
        }
    }
}
