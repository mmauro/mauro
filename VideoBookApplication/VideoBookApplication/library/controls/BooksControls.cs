﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoBookApplication.common.enums;
using VideoBookApplication.common.utility;
using VideoBookApplication.library.model.database;
using VideoBookApplication.library.operations;

namespace VideoBookApplication.library.controls
{
    public class BooksControls
    {
        public BookInfoModel getBookInfoModel(string title, string cognome)
        {
            BookInfoModel model = null;

            if (title != null && !title.Trim().Equals(""))
            {
                if (cognome != null && !cognome.Trim().Equals(""))
                {
                    GoogleBooksWebService gbws = new GoogleBooksWebService();
                    model = gbws.getBookInfo(title, cognome);
                }
                else
                {
                    throw new VideoBookException(ApplicationErrorType.AUTHOR_NOT_FOUND);
                }
            }
            else
            {
                throw new VideoBookException(ApplicationErrorType.EMPTY_TITLE);
            }

            return model;
        }

        public BookModel getBooksModel(string title, string serie, string note, int idCategory, int idLocation, bool flEbook ) {
            BookModel model = null;

            if (title != null && !title.Trim().Equals("")) {
                model = new BookModel();
                model.titolo = title;
                model.serie = serie;
                model.flEbook = flEbook;
                BookNoteModel bNote = new BookNoteModel();
                bNote.nota = note;
                bNote.idNota = Configurator.getInstsance().getInt("notfound.value");
                model.note = bNote;

                //Cerca category e location
                try
                {
                    CategoryControls catControls = new CategoryControls();
                    model.category = catControls.read(idCategory);

                    PositionControl posControl = new PositionControl();
                    model.position = posControl.read(idLocation);
                }
                catch (VideoBookException e)
                {
                    throw e;
                }

            } else {
                throw new VideoBookException(ApplicationErrorType.EMPTY_TITLE);
            }

            return model;
        }
    }
}
