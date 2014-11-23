using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoBookApplication.common.enums
{
    public class ReservedType
    {

        public int type { get; private set; }

        public string description { get; private set; }

        private ReservedType(int type, string description)
        {
            this.type = type;
            this.description = description;
        }

        public static ReservedType TITLE_BOOK_RESERVED = new ReservedType(0, "Titoli");
        public static ReservedType AUTHOR_BOOK_RESERVED = new ReservedType(1, "Autori");
    }
}
