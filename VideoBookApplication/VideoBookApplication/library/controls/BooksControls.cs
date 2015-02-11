using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoBookApplication.common.enums;
using VideoBookApplication.common.model;
using VideoBookApplication.common.utility;
using VideoBookApplication.library.dao;
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
                model.dtInsert = DateTime.Now;


                if (note != null && !note.Trim().Equals(""))
                {
                    BookNoteModel bNote = new BookNoteModel();
                    bNote.nota = note;
                    bNote.idNota = Configurator.getInstsance().getInt("notfound.value");
                    model.note = bNote;
                }
                else
                {
                    model.note = null;
                }

                //Cerca category e location
                try
                {
                    CategoryControls catControls = new CategoryControls();
                    model.category = catControls.read(idCategory);

                    PositionControls posControl = new PositionControls();
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

        public ApplicationErrorType getBookByCategory(ref GlobalApplicationObject globalObject, int idCategory)
        {
            ApplicationErrorType status = ApplicationErrorType.SUCCESS;
            if (idCategory != Configurator.getInstsance().getInt("notfound.value"))
            {
                try
                {
                    BookDao dao = new BookDao();
                    List<BookModel> libri = (List<BookModel>)dao.readByIdCategory(idCategory);
                    if (libri != null && libri.Count > 0)
                    {
                        globalObject.libraryObject.libraryInput.libri = libri;
                        if (libri.Count == 1)
                        {
                            globalObject.libraryObject.libraryInput.libro = libri[0];
                        }
                    }
                    else
                    {
                        status = ApplicationErrorType.EMPTY_BOOKS;
                    }
                }
                catch (VideoBookException e)
                {
                    status = e.errorType;
                }
            }
            else
            {
                status = ApplicationErrorType.EMPTY_CATEGORY;
            }
            return status;
        }

        public ApplicationErrorType getBookByPosition(ref GlobalApplicationObject globalObject, int idPos)
        {
            ApplicationErrorType status = ApplicationErrorType.SUCCESS;
            if (idPos != Configurator.getInstsance().getInt("notfound.value"))
            {
                try
                {
                    BookDao dao = new BookDao();
                    List<BookModel> libri = (List<BookModel>)dao.readByIdPos(idPos);
                    if (libri != null && libri.Count > 0)
                    {
                        globalObject.libraryObject.libraryInput.libri = libri;
                        if (libri.Count == 1)
                        {
                            globalObject.libraryObject.libraryInput.libro = libri[0];
                        }
                    }
                    else
                    {
                        status = ApplicationErrorType.EMPTY_BOOKS;
                    }
                }
                catch (VideoBookException e)
                {
                    status = e.errorType;
                }
            }
            else
            {
                status = ApplicationErrorType.EMPTY_CATEGORY;
            }
            return status;
        }
    }
}
