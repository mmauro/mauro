using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoBookApplication.common.utility
{
    class LogUtility
    {

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static void printQueryLog(string query, params string[] queryParams)
        {
            if (queryParams != null && queryParams.Length > 0)
            {
                String queryBuilder = query;
                queryBuilder += " ---> [ ";

                for (int i = 0; i < queryParams.Length; i++)
                {
                    queryBuilder += queryParams[i];
                    queryBuilder += " - ";
                }

                queryBuilder = queryBuilder.Substring(0, queryBuilder.Length - 3);

                queryBuilder += " ]";

                log.Info(queryBuilder);
            }
            else
            {
                log.Info(query);
            }
        }
    }
}
