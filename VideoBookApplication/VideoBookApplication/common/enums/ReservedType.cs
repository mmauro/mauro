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
        public OperationType operation { get; private set; }
        private ReservedType(int type, OperationType operation)
        {
            this.type = type;
            this.operation = operation;
        }

        public static ReservedType TITLE_BOOK_RESERVED = new ReservedType(0, OperationType.LIBRARY);
        public static ReservedType AUTHOR_BOOK_RESERVED = new ReservedType(1, OperationType.LIBRARY);
    }
}
