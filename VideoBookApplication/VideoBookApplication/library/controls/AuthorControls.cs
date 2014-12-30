﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoBookApplication.common.enums;
using VideoBookApplication.common.model;
using VideoBookApplication.common.operations;
using VideoBookApplication.common.utility;
using VideoBookApplication.library.model.database;
using VideoBookApplication.library.operations;

namespace VideoBookApplication.library.controls
{
    public class AuthorControls
    {

        private WordMasterControl wmControl = new WordMasterControl();

        public ApplicationErrorType addNewAuthor(string nome, string cognome, ref GlobalApplicationObject globalObject)
        {
            ApplicationErrorType status = ApplicationErrorType.SUCCESS;
            ApplicationErrorType warnStatus = ApplicationErrorType.NOT_INIT_WARN;
            List<AuthorModel> elencoAutoriCognome = null;
            List<AuthorModel> elencoAutoriNome = null;

            if (cognome != null && !cognome.Equals(""))
            {
                Indexer indexCognome = new Indexer(cognome, IndexerType.INDEX_AUTHOR);
                if (indexCognome.status == ApplicationErrorType.SUCCESS)
                {
                    elencoAutoriCognome = wmControl.getAuthorByFirstname(indexCognome.words);
                    if (elencoAutoriCognome != null && elencoAutoriCognome.Count > 0) {
                        if (indexCognome.words.Count > 1)
                        {
                            FilterAuthor filter = new FilterAuthor(FilterType.FILTER_AND);
                            elencoAutoriCognome = filter.filter(elencoAutoriCognome, indexCognome.words.Count);
                        }
                       warnStatus = ApplicationErrorType.AUTHOR_FIRSTNAME_FOUND_WARN;
                    }
                }
                else
                {
                    status = indexCognome.status;
                }

                if (status == ApplicationErrorType.SUCCESS && nome != null && !nome.Trim().Equals("") && warnStatus == ApplicationErrorType.AUTHOR_FIRSTNAME_FOUND_WARN)
                {
                    Indexer indexNome = new Indexer(nome, IndexerType.INDEX_AUTHOR);
                    if (indexNome.status == ApplicationErrorType.SUCCESS)
                    {
                        elencoAutoriNome = wmControl.getAuthorByName(indexNome.words);
                        if (elencoAutoriNome != null && elencoAutoriNome.Count > 0)
                        {
                            if (indexNome.words.Count > 1)
                            {
                                FilterAuthor filter = new FilterAuthor(FilterType.FILTER_AND);
                                elencoAutoriCognome = filter.filter(elencoAutoriNome, indexNome.words.Count);
                            }
                            if (elencoAutoriNome != null && elencoAutoriNome.Count > 0)
                            {
                                FilterAuthor filterFinal = new FilterAuthor(FilterType.FILTER_AND);
                                elencoAutoriCognome.AddRange(elencoAutoriNome);
                                filterFinal.filter(elencoAutoriCognome, 2);
                            }
                            warnStatus = ApplicationErrorType.AUTHOR_FOUND_WARN;
                        }
                    }
                    else
                    {
                        status = indexNome.status;
                    }
                }

            }
            else
            {
                status = ApplicationErrorType.EMPTY_FIRSTAME;
            }

            if (status == ApplicationErrorType.SUCCESS)
            {
                AuthorModel aModel = new AuthorModel();
                aModel.cognome = StringUtility.capitalize(cognome);
                if (nome != null)
                {
                    aModel.nome = StringUtility.capitalize(nome);
                }
                else
                {
                    aModel.nome = nome;
                }
                
                globalObject.libraryObject.libraryInput.autore = aModel;
                if (warnStatus != ApplicationErrorType.NOT_INIT_WARN)
                {
                    status = warnStatus;
                }
            }

            return status;
        }
    }
}
