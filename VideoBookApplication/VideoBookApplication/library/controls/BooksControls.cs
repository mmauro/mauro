﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoBookApplication.common.enums;
using VideoBookApplication.common.model;
using VideoBookApplication.common.operations;
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

        public ApplicationErrorType getBookByAuthor(ref GlobalApplicationObject globalObject, string cognome, string nome)
        {
            ApplicationErrorType status = ApplicationErrorType.SUCCESS;
            AuthorControls authorControl = new AuthorControls();
            status = authorControl.searchAuthors(nome, cognome, ref globalObject);
            if (status == ApplicationErrorType.SUCCESS)
            {
                if (globalObject.libraryObject.libraryInput.autori != null && globalObject.libraryObject.libraryInput.autori.Count > 0)
                {
                    globalObject.libraryObject.libraryInput.libri = new List<BookModel>();
                    BookDao dao = new BookDao();
                    try
                    {
                        foreach (AuthorModel model in globalObject.libraryObject.libraryInput.autori)
                        {
                            List<BookModel> tmpBooks = (List<BookModel>)dao.readByIdAutore(model.idAutore);
                            if (tmpBooks != null && tmpBooks.Count > 0)
                            {
                                globalObject.libraryObject.libraryInput.libri.AddRange(tmpBooks);
                            }
                        }

                        if (globalObject.libraryObject.libraryInput.libri.Count > 0)
                        {
                            if (globalObject.libraryObject.libraryInput.libri.Count == 1)
                            {
                                globalObject.libraryObject.libraryInput.libro = globalObject.libraryObject.libraryInput.libri[0];
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
                    status = ApplicationErrorType.AUTHOR_NOT_FOUND;
                }
            }
            return status;
        }


        public ApplicationErrorType getBookByTitle(ref GlobalApplicationObject globalObject, string titolo)
        {
            ApplicationErrorType status = ApplicationErrorType.SUCCESS;
            List<BookModel> tmpBookResults = new List<BookModel>();
            if (titolo != null && !titolo.Equals(""))
            {
                Indexer indexTitle = new Indexer(titolo, IndexerType.INDEX_BOOK_TITLE);
                status = indexTitle.status;
                if (status == ApplicationErrorType.SUCCESS)
                {
                    WordMasterTitleDao titleDao = new WordMasterTitleDao();
                    try
                    {
                        foreach (string word in indexTitle.words)
                        {
                            if (status == ApplicationErrorType.SUCCESS)
                            {
                                WordMasterLibriModel paroleLibri = titleDao.readOne(word);
                                if ( paroleLibri != null && paroleLibri.libri != null && paroleLibri.libri.Count > 0 )
                                {
                                    tmpBookResults.AddRange(paroleLibri.libri);
                                }
                                else
                                {
                                    status = ApplicationErrorType.EMPTY_BOOKS;
                                }
                            }
                        }
                    }
                    catch (VideoBookException e)
                    {
                        status = e.errorType;
                    }

                    if (status == ApplicationErrorType.SUCCESS)
                    {
                        FilterBook filter = new FilterBook(FilterType.FILTER_AND);
                        tmpBookResults = filter.filter(tmpBookResults, indexTitle.words.Count);
                        if (tmpBookResults != null && tmpBookResults.Count > 0)
                        {
                            globalObject.libraryObject.libraryInput.libri = tmpBookResults;
                            if (globalObject.libraryObject.libraryInput.libri.Count == 1)
                            {
                                globalObject.libraryObject.libraryInput.libro = globalObject.libraryObject.libraryInput.libri[0];
                            }
                        }
                        else
                        {
                            status = ApplicationErrorType.EMPTY_BOOKS;
                        }
                    }


                }
            }
            else
            {
                status = ApplicationErrorType.EMPTY_TITLE;
            }
            return status;
        }

    }
}
