using System;
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

namespace VideoBookApplication.library.controls
{
    public class LibraryControls
    {
        public ApplicationErrorType write(ref GlobalApplicationObject globalObject)
        {
            ApplicationErrorType status = ApplicationErrorType.SUCCESS;
            if (globalObject.libraryObject.libraryInput.autore != null)
            {
                if (globalObject.libraryObject.libraryInput.libri != null && globalObject.libraryObject.libraryInput.libri.Count > 0)
                {

                    Indexer indexCognome = new Indexer(globalObject.libraryObject.libraryInput.autore.cognome, IndexerType.INDEX_AUTHOR);
                    status = indexCognome.status;
                    if (status == ApplicationErrorType.SUCCESS)
                    {
                        globalObject.libraryObject.libraryInput.indexElements.wordsCognome = indexCognome.words;
                    }

                    if (status == ApplicationErrorType.SUCCESS && globalObject.libraryObject.libraryInput.autore.nome != null && !globalObject.libraryObject.libraryInput.autore.nome.Equals(""))
                    {
                        Indexer indexNome = new Indexer(globalObject.libraryObject.libraryInput.autore.nome, IndexerType.INDEX_AUTHOR);
                        status = indexNome.status;
                        if (status == ApplicationErrorType.SUCCESS)
                        {
                            globalObject.libraryObject.libraryInput.indexElements.wordsNome = indexNome.words;
                        }
                    }

                    if (status == ApplicationErrorType.SUCCESS)
                    {
                        //Index Libri;
                        foreach (BookModel model in globalObject.libraryObject.libraryInput.libri)
                        {
                            if (status == ApplicationErrorType.SUCCESS)
                            {
                                string value = model.titolo;
                                if (model.serie != null && !model.serie.Equals(""))
                                {
                                    value += " " + model.serie;
                                }
                                Indexer indexTitle = new Indexer(value, IndexerType.INDEX_BOOK_TITLE);
                                status = indexTitle.status;
                                if (status == ApplicationErrorType.SUCCESS)
                                {
                                    globalObject.libraryObject.libraryInput.indexElements.wordBooksTitle.Add(model, indexTitle.words);
                                }
                            }
                        }
                    }

                    if (status == ApplicationErrorType.SUCCESS)
                    {
                        try
                        {
                            LibraryDao dao = new LibraryDao();
                            status = dao.writeInformations(globalObject);
                        }
                        catch (VideoBookException e)
                        {
                            status = e.errorType;
                        }
                    }
                }
                else
                {
                    status = ApplicationErrorType.EMPTY_BOOKS;
                }
            }
            else
            {
                status = ApplicationErrorType.AUTHOR_NOT_FOUND;
            }

            return status;
        }
    }
}
