using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using VideoBookApplication.common.enums;
using VideoBookApplication.common.operations;
using VideoBookApplication.common.utility;
using VideoBookApplication.library.model.database;

namespace VideoBookApplication.library.operations
{
    class GoogleBooksWebService : HttpRequest
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public BookInfoModel getBookInfo(string title, string cognome)
        {
            BookInfoModel infoModel = null;

            try
            {
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Add("q", prepareQsParam(title, cognome));
                parameters.Add("key", Configurator.getInstsance().get("google.books.browser.api.key"));
                parameters.Add("orderBy", Configurator.getInstsance().get("google.books.sort"));
                parameters.Add("maxResults", Configurator.getInstsance().get("google.books.maxresults"));
                parameters.Add("printType", Configurator.getInstsance().get("google.books.print.type"));
                parameters.Add("langRestrict", Configurator.getInstsance().get("google.books.lang"));

                buildUrl(Configurator.getInstsance().get("google.books.schema"), Configurator.getInstsance().get("google.books.host"), Configurator.getInstsance().get("google.books.path"), parameters);
                HttpWebResponse response = execute(Configurator.getInstsance().getInt("google.books.timeout"));
                if (response != null && response.StatusCode == HttpStatusCode.OK)
                {
                    try
                    {
                        string selfLink = parseSelfLink(getResponse(response.GetResponseStream()));
                        if (selfLink != null && !selfLink.Equals(""))
                        {
                            try
                            {
                                return getBookInfo(selfLink);
                            }
                            catch (VideoBookException e)
                            {
                                throw e;
                            }
                        }
                        else
                        {
                            log.Info("No Info Found");
                            infoModel = null;
                        }
                    }
                    catch (VideoBookException e)
                    {
                        throw e;
                    }
                }
                else
                {
                    log.Error("HttpStatusCode = " + response.StatusCode.ToString());
                    infoModel = null;
                    throw new VideoBookException(ApplicationErrorType.WEBSERVICE_ERROR);
                }


            }
            catch (Exception e)
            {
                log.Error(e.Message);
                infoModel = null;
                throw new VideoBookException(ApplicationErrorType.WEBSERVICE_ERROR);
            }


            return infoModel;
        }

        private string prepareQsParam(string title, string cognome) {
            return String.Format("{0}+inauthor:{1}", WebUtility.UrlEncode(title), WebUtility.UrlEncode(cognome));
        }

        private BookInfoModel getBookInfo(string url)
        {
            BookInfoModel infoModel = null;
            try
            {
                log.Info("Call SelfLink");
                buildUrl(url);
                HttpWebResponse response = execute(Configurator.getInstsance().getInt("google.books.timeout"));
                if (response != null && response.StatusCode == HttpStatusCode.OK)
                {
                    try
                    {
                        infoModel = parseInfo(getResponse(response.GetResponseStream()));
                    }
                    catch (VideoBookException e)
                    {
                        throw e;
                    }
                }
                else
                {
                    log.Error("HttpStatusCode = " + response.StatusCode.ToString());
                    infoModel = null;
                    throw new VideoBookException(ApplicationErrorType.WEBSERVICE_ERROR);
                }
            }
            catch (Exception e)
            {
                log.Error(e.Message);
                infoModel = null;
                throw new VideoBookException(ApplicationErrorType.WEBSERVICE_ERROR);
            }


            return infoModel;
        }

        private string parseSelfLink(dynamic json)
        {
            try
            {
                if (json.totalItems > 0)
                {
                    return json.items[0].selfLink;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                log.Error(e.Message);
                throw new VideoBookException(ApplicationErrorType.WEBSERVICE_PARSER_ERROR);
            }
        }

        private BookInfoModel parseInfo(dynamic json)
        {
            BookInfoModel infoModel = new BookInfoModel();

            //Titolo Originale
            try
            {
                infoModel.titleOrig = json.volumeInfo.title;
            }
            catch (Exception e)
            {
                infoModel.titleOrig = "";
            }

            //url scheda (selfLink)
            try
            {
                infoModel.urlScheda = json.selfLink;
            }
            catch (Exception e)
            {
                infoModel.urlScheda = "";
            }

            //editore
            try
            {
                infoModel.publisher = json.volumeInfo.publisher;
            }
            catch (Exception e)
            {
                infoModel.publisher = "";
            }

            //Anno Pubblicazione
            try
            {
                bool useString = false;
                try
                {
                    DateTime year = json.volumeInfo.publishedDate;
                    infoModel.year = year.Year.ToString();
                }
                catch (Exception e)
                {
                    useString = true;
                }
                if (useString)
                {
                    string year = json.volumeInfo.publishedDate;
                    infoModel.year = StringUtility.getYear(year);
                }
                log.Info("YEAR = " + infoModel.year);
            }
            catch (Exception e)
            {
                log.Error(e.Message);
                infoModel.year = "";
            }            

            //ISBN
            try 
            {
                foreach (dynamic isbnIndustry in json.volumeInfo.industryIdentifiers)
                {
                    string isbnType = isbnIndustry.type;
                    if (isbnType.Equals("ISBN_13"))
                    {
                        infoModel.isbn = isbnIndustry.identifier;
                    }
                }
            }
            catch (Exception e)
            {
                infoModel.isbn = "";
            }

            //editore
            try
            {
                infoModel.trama = json.volumeInfo.description;
            }
            catch (Exception e)
            {
                infoModel.trama = "";
            }

            return infoModel;
        }

    }
}
