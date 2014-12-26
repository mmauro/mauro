using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoBookApplication.common.enums
{
    public class IndexerType
    {

        public ReservedType reserved { get; private set; }
        public bool useStemmer { get; private set; }


        private IndexerType(ReservedType reserved, bool useStemmer)
        {
            this.reserved = reserved;
            this.useStemmer = useStemmer;
        }

        public static IndexerType INDEX_BOOK_TITLE = new IndexerType(ReservedType.TITLE_BOOK_RESERVED, true);
        public static IndexerType INDEX_AUTHOR = new IndexerType(ReservedType.AUTHOR_BOOK_RESERVED, false);

    }
}
