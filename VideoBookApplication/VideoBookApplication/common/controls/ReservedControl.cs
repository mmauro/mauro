using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoBookApplication.common.dao;
using VideoBookApplication.common.enums;
using VideoBookApplication.common.model;
using VideoBookApplication.common.model.database;
using VideoBookApplication.common.utility;


namespace VideoBookApplication.common.controls
{
    class ReservedControl
    {
        public ApplicationErrorType writeReserved(String reservedWord, ReservedType typeReserved)
        {
            ApplicationErrorType status = ApplicationErrorType.SUCCESS;
                if (typeReserved != null)
                {
                    status = writeReserved(reservedWord, typeReserved.type);
                }
                else
                {
                    status = ApplicationErrorType.INVALID_TYPE;
                }
            return status;
        }

        public ApplicationErrorType writeReserved(String reservedWord, int typeReserved)
        {
            ApplicationErrorType status = ApplicationErrorType.SUCCESS;
            if (reservedWord != null && reservedWord.Trim().Length > 0)
            {
                ReservedModel model = new ReservedModel();
                model.reserved = reservedWord.Trim().ToLower();
                model.reservedType = typeReserved;
                try
                {
                    ReservedDao dao = new ReservedDao();
                    dao.write(model);
                }
                catch (VideoBookException e)
                {
                    status = e.errorType;
                }
            }
            else
            {
                status = ApplicationErrorType.EMPTY_RESERVED;
            }

            return status;
        }


        public List<ItemCombo> getItemsControl(ActivityType activity)
        {
            List<ItemCombo> items = new List<ItemCombo>();

            switch (activity)
            {
                case ActivityType.LIBRARY:
                    items.Add(new ItemCombo(ReservedType.AUTHOR_BOOK_RESERVED.description, ReservedType.AUTHOR_BOOK_RESERVED.type));
                    items.Add(new ItemCombo(ReservedType.TITLE_BOOK_RESERVED.description, ReservedType.TITLE_BOOK_RESERVED.type));
                    break;
                default:
                    throw new VideoBookException(ApplicationErrorType.ERROR_RESERVED);
            }
            return items;
        }
    }
}
