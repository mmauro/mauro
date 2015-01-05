using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace VideoBookApplication.common.operations
{
    public class HttpRequest
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        protected Uri url = null;
        protected const int TIMEOUT = 5000;

        protected void buildUrl(string schema, string host, string path, Dictionary<string,string> parameters)
        {
            string finalUrl = String.Format("{0}://{1}/{2}", schema, host, path);
            if (parameters != null && parameters.Count > 0)
            {
                finalUrl += "?";
                foreach (KeyValuePair<string, string> entry in parameters)
                {
                    finalUrl += entry.Key + "=" + entry.Key + "&";
                }
            }
            buildUrl(finalUrl);
        }

        protected void buildUrl(string url)
        {
            log.Info("buildUrl = " + url);
            this.url = new Uri(url);
        }

        protected HttpWebResponse execute()
        {
            return execute(TIMEOUT);
        }

        protected HttpWebResponse execute(int timeout)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Timeout = timeout;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            return response;
        }



    }
}
