using System;
using System.Collections.Generic;
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
                //https://www.googleapis.com/books/v1/volumes?q=la%20freccia%20di%20poseidone+inauthor:cussler&key=AIzaSyCpuZOgKmwxODZiuWEWWIhb9ToCOEm5_3Q&orderBy=relevance&maxResults=1&printType=books&langRestrict=it
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
                    log.Info("Responce OK");
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

    }
}
