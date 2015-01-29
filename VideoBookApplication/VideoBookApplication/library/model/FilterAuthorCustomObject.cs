using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoBookApplication.library.model.database;

namespace VideoBookApplication.library.model
{
    public class FilterAuthorCustomObject
    {
        public AuthorModel model { get; set; }
        public int value {get; set;}

        public FilterAuthorCustomObject(AuthorModel model)
        {
            this.model = model;
            this.value = 1;
        }

        public FilterAuthorCustomObject(AuthorModel model, int value)
        {
            this.model = model;
            this.value = value;
        }

        public void increment()
        {
            value++;
        }

    }
}
