﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoBookApplication.common.enums;
using VideoBookApplication.common.model;
using VideoBookApplication.common.utility;
using VideoBookApplication.library.dao;

namespace VideoBookApplication.library.controls
{
    public class StatControls
    {
        public ApplicationErrorType getStatistics(ref GlobalApplicationObject globalObject)
        {
            ApplicationErrorType status = ApplicationErrorType.SUCCESS;
            BookDao bDao = new BookDao();
            AuthorDao aDao = new AuthorDao();
            try
            {
                //Contatore Libri
                globalObject.libraryObject.statistiche.numLibri = bDao.countElement();
                globalObject.libraryObject.statistiche.ebook = bDao.countElement(true);
                globalObject.libraryObject.statistiche.numLibriCarta = globalObject.libraryObject.statistiche.numLibri - globalObject.libraryObject.statistiche.ebook;

                //Contatore Autori
                globalObject.libraryObject.statistiche.numAutori = aDao.countElement();
                globalObject.libraryObject.statistiche.media = 0;
                if (globalObject.libraryObject.statistiche.numAutori > 0)
                {
                    double floatValue = globalObject.libraryObject.statistiche.numLibri / globalObject.libraryObject.statistiche.numAutori;
                    globalObject.libraryObject.statistiche.media = (int)Math.Ceiling(floatValue);

                    int idLibro = bDao.readIdLibro();
                    if (idLibro != Configurator.getInstsance().getInt("notfound.value"))
                    {
                        globalObject.libraryObject.statistiche.lastBook = bDao.readOne(idLibro);
                    }
                    else
                    {
                        status = ApplicationErrorType.BOOK_NOT_FOUND;
                    }

                    //Chiamata per numero libri per categorie
                    status = getCategoryCount(ref globalObject);

                }
            }
            catch (VideoBookException e)
            {
                status = e.errorType;
            }

            return status;
        }

        private ApplicationErrorType getCategoryCount(ref GlobalApplicationObject globalObject)
        {
            ApplicationErrorType status = ApplicationErrorType.SUCCESS;


            StatDao sDao = new StatDao();
            try
            {
                globalObject.libraryObject.statistiche.categoryDistribution = sDao.countCategory();
                if (globalObject.libraryObject.statistiche.categoryDistribution == null)
                {
                    globalObject.libraryObject.statistiche.categoryDistribution = new Dictionary<string, int>();
                }
            }
            catch (VideoBookException e)
            {
                status = e.errorType;
            }


            return status;
        }
    }
}
