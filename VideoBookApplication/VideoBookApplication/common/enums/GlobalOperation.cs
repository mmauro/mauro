using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoBookApplication.common.enums
{
    public enum GlobalOperation
    {
        /** NON INIZIALIZZATA */
        UNDEFINED,

        /** COMMON */
        RESERVED,

        /** LIBRARY MENU */
        LIB_INSERT_MENU,
        LIB_DELETE_MENU,
        LIB_MODIFY_MENU,
        LIB_SEARCH_MENU,
        LIB_REPORT_MENU,

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
        LIB_STATS_GRAPH,
        LIB_SEARCH_NEW_BOOK,
        LIB_SHOW_BOOKS,
        LIB_CHOOSE_AUTHOR,
        LIB_SHOW_AUTHOR,
        LIB_SEARCHCAT_DELETE,
        LIB_SEARCHPOS_DELETE,
        LIB_SEARCHAUTHOR_DELETE,
        LIB_CHOOSE_AUTHOR_DELETE,
        LIB_DELETE_AUTHOR,
        LIB_SEARCHBOOK_DELETE,
        LIB_CHOOSE_BOOK_DELETE,
        LIB_DETAIL_BOOK_DELETE,
        LIB_SHOW_BOOKS_DETAIL,
        LIB_EDIT_CAT,
        LIB_EDIT_POS,
        LIB_SEARCHAUTHOR_EDIT,
        LIB_CHOOSE_AUTHOR_EDIT,
        LIB_EDIT_AUTHOR,
        LIB_SEARCHBOOK_EDIT,
        LIB_CHOOSE_BOOK_EDIT
    }
}
