using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoBookApplication.library.model.database
{
    public class WordMasterNomeModel
    {
        public int idWord { get; set; }
        public string word { get; set; }
        public List<AuthorModel> autori { get; set; }
    }
}
