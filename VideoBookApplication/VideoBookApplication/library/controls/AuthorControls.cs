﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoBookApplication.common.enums;
using VideoBookApplication.common.operations;

namespace VideoBookApplication.library.controls
{
    public class AuthorControls
    {
        public ApplicationErrorType addNewAuthor(string nome, string cognome)
        {
            ApplicationErrorType status = ApplicationErrorType.SUCCESS;

            if (cognome != null && !cognome.Equals(""))
            {
                Indexer indexCognome = new Indexer(cognome, IndexerType.INDEX_AUTHOR);
                if (indexCognome.status == ApplicationErrorType.SUCCESS)
                {

                }
                else
                {
                    status = indexCognome.status;
                }
            }
            else
            {
                status = ApplicationErrorType.EMPTY_FIRSTAME;
            }

            return status;
        }
    }
}
