﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoBookApplication.common.enums
{
    public enum GlobalOperation
    {
        /** COMMON */
        RESERVED,

        /** LIBRARY MENU */
        LIB_INSERT_MENU,

        /** LIBRARY OPERATION */
        LIB_NEW_CATEGORY,
        LIB_NEW_POSITION,
        LIB_SHOW_CAT,
        LIB_SHOW_POS,
        LIB_NEW_AUTHOR,
        LIB_NEW_BOOKS,
        LIB_NEW_BOOKS_CATEGORY,
        LIB_NEW_BOOKS_POSITION,
        LIB_INFOBOOK,
        LIB_KEEP_TITLE,
        LIB_DELETE_INFOBOOK,
        LIB_STATS,
        LIB_STATS_GRAPH
    }
}
