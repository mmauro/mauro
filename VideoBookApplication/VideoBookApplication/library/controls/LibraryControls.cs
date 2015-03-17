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

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public ApplicationErrorType write(ref GlobalApplicationObject globalObject)
        {
            LibraryDao dao = new LibraryDao();
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
                    status = ApplicationErrorType.BOOK_NOT_FOUND;
                }
            }
            else
            {
                status = ApplicationErrorType.AUTHOR_NOT_FOUND;
            }

            return status;
        }

        public ApplicationErrorType deleteCategory(int categoryToDelete, int defaultCategory)
        {
            LibraryDao dao = new LibraryDao();
            ApplicationErrorType status = ApplicationErrorType.SUCCESS;
            if ( categoryToDelete != Configurator.getInstsance().getInt("notfound.value") && defaultCategory != Configurator.getInstsance().getInt("notfound.value"))
            {
                try
                {
                    status = dao.deleteCategory(categoryToDelete, defaultCategory);
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

        public ApplicationErrorType deletePosition(int posToDelete, int defaultPos)
        {
            LibraryDao dao = new LibraryDao();
            ApplicationErrorType status = ApplicationErrorType.SUCCESS;
            if (posToDelete != Configurator.getInstsance().getInt("notfound.value") && defaultPos != Configurator.getInstsance().getInt("notfound.value"))
            {
                try
                {
                    status = dao.deletePosition(posToDelete, defaultPos);
                }
                catch (VideoBookException e)
                {
                    status = e.errorType;
                }
            }
            else
            {
                status = ApplicationErrorType.EMPTY_POSITION;
            }

            return status;

        }

        public ApplicationErrorType deleteAuthorAndBook(ref GlobalApplicationObject globalObject)
        {
            LibraryDao dao = new LibraryDao();
            ApplicationErrorType status = ApplicationErrorType.SUCCESS;

            if (globalObject.libraryObject.libraryInput.autore != null && globalObject.libraryObject.libraryInput.autore.idAutore != Configurator.getInstsance().getInt("notfound.value"))
            {
                status = dao.deleteAuthorsAndBook(globalObject.libraryObject.libraryInput.autore);
            }
            else
            {
                status = ApplicationErrorType.AUTHOR_NOT_FOUND;
            }

            return status;
        }

        public ApplicationErrorType deleteBook(ref GlobalApplicationObject globalObject)
        {
            LibraryDao dao = new LibraryDao();
            ApplicationErrorType status = ApplicationErrorType.SUCCESS;

            if (globalObject.libraryObject.libraryInput.libro != null && globalObject.libraryObject.libraryInput.libro.idLibro != Configurator.getInstsance().getInt("notfound.value"))
            {
                status = dao.deleteBooks(globalObject.libraryObject.libraryInput.libro);
            }
            else
            {
                status = ApplicationErrorType.BOOK_NOT_FOUND;
            }

            return status;


        }

        public ApplicationErrorType updateAuthor(ref GlobalApplicationObject globalObject, AuthorModel newAuthor)
        {
            ApplicationErrorType status = ApplicationErrorType.SUCCESS;
            bool modificaCognome = false;
            bool modificaNome = false;

            List<String> cognomeAdd = new List<string>();
            List<String> cognomeDelete = new List<string>();
            List<String> nomeAdd = new List<string>();
            List<String> nomeDelete = new List<string>();


            Indexer indexOld = null;
            Indexer indexNew = null;

            if (newAuthor != null && newAuthor.cognome != null && !newAuthor.cognome.Trim().Equals(""))
            {
                if (globalObject.libraryObject.libraryInput.autore != null && globalObject.libraryObject.libraryInput.autore.idAutore != Configurator.getInstsance().getInt("notfound.value"))
                {
                    modificaCognome = compare(globalObject.libraryObject.libraryInput.autore.cognome, newAuthor.cognome);
                    modificaNome = compare(globalObject.libraryObject.libraryInput.autore.nome, newAuthor.nome);


                    if (modificaNome || modificaCognome)
                    {
                        //Ho delle modifiche da salvare
                        if (modificaCognome)
                        {
                            indexOld = new Indexer(globalObject.libraryObject.libraryInput.autore.cognome, IndexerType.INDEX_AUTHOR);
                            indexNew = new Indexer(newAuthor.cognome, IndexerType.INDEX_AUTHOR);

                            if (indexNew.status == ApplicationErrorType.SUCCESS && indexOld.status == ApplicationErrorType.SUCCESS)
                            {
                                prepareIndexerValue(indexOld.words, indexNew.words, ref cognomeDelete, ref cognomeAdd);
                                if (cognomeAdd.Count == 0 && cognomeDelete.Count == 0)
                                {
                                    log.Error("Preparazione Cognome");
                                    status = ApplicationErrorType.AUTHOR_PREPARE_DELETE_ERROR;
                                }
                            }
                            else
                            {
                                status = ApplicationErrorType.INDEXER_PREPARE_ERROR;
                            }

                        }

                        if (status == ApplicationErrorType.SUCCESS && modificaNome)
                        {
                            List<string> oldWords = new List<string>();
                            List<string> newWords = new List<string>();


                            if (globalObject.libraryObject.libraryInput.autore.nome != null && !globalObject.libraryObject.libraryInput.autore.nome.Equals(""))
                            {
                                indexOld = new Indexer(globalObject.libraryObject.libraryInput.autore.nome, IndexerType.INDEX_AUTHOR);
                                status = indexOld.status;
                                if (status == ApplicationErrorType.SUCCESS)
                                {
                                    oldWords = indexOld.words;
                                }
                            }

                            if (status == ApplicationErrorType.SUCCESS && newAuthor.nome != null && !newAuthor.nome.Trim().Equals(""))
                            {
                                indexNew = new Indexer(newAuthor.nome, IndexerType.INDEX_AUTHOR);
                                status = indexNew.status;
                                if (status == ApplicationErrorType.SUCCESS)
                                {
                                    newWords = indexNew.words;
                                }
                            }
                            

                            if (status == ApplicationErrorType.SUCCESS)
                            {
                                prepareIndexerValue(oldWords, newWords, ref nomeDelete, ref nomeAdd);
                                if (nomeAdd.Count == 0 && nomeDelete.Count == 0)
                                {
                                    log.Error("Preparazione Nome");
                                    status = ApplicationErrorType.AUTHOR_PREPARE_DELETE_ERROR;
                                }
                            }
                            else
                            {
                                status = ApplicationErrorType.INDEXER_PREPARE_ERROR;
                            }

                        }

                        if (status == ApplicationErrorType.SUCCESS)
                        {
                            newAuthor.idAutore = globalObject.libraryObject.libraryInput.autore.idAutore;
                            //Chiamata DAO
                            LibraryDao dao = new LibraryDao();
                            status = dao.updateAuthor(newAuthor, cognomeAdd, cognomeDelete, nomeAdd, nomeDelete);
                        }

                    }
                    else
                    {
                        status = ApplicationErrorType.AUTHOR_EQUALS_VALUE;
                    }


                }
                else
                {
                    status = ApplicationErrorType.AUTHOR_NOT_FOUND;
                }
            }
            else
            {
                status = ApplicationErrorType.EMPTY_FIRSTAME;
            }

            return status;
        }

        private bool compare(String oldValue, String newValue)
        {

            if (oldValue == null && newValue == null)
            {
                return false;
            }

            if (oldValue == null && newValue != null)
            {
                return true;
            }

            if (oldValue != null && newValue == null)
            {
                return true;
            }

            bool flag = !oldValue.Trim().ToLower().Equals(newValue.Trim().ToLower());
            return flag;

        }

        private void prepareIndexerValue(List<String> inputOldValue, List<String> inputNewValue, ref List<String> deleteValue, ref List<String> addValue)
        {
            if (inputOldValue != null && inputOldValue.Count > 0)
            {
                foreach (string value in inputOldValue)
                {
                    if (!inputNewValue.Contains(value))
                    {
                        deleteValue.Add(value);
                    }
                }
            }

            if (inputNewValue != null && inputNewValue.Count > 0) 
            {
                foreach (string value in inputNewValue)
                {
                    if (!inputOldValue.Contains(value))
                    {
                        addValue.Add(value);
                    }
                }
            }

        }

    }
}
