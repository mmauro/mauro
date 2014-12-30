using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Xml;
using System.IO;

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

        public static void deleteOldLogs()
        {
            String directory = null;
            int rollingFileSize = Configurator.getInstsance().getInt("notfound.value");

            String xmlApplicationConfig = global::VideoBookApplication.Properties.Resources.App;
            XmlDocument doc = new XmlDocument();
            //doc.Load(new StringReader(xmlApplicationConfig));
            doc.LoadXml(xmlApplicationConfig);

            XmlNodeList appenderList = doc.SelectNodes("/configuration/log4net/appender");
            if (appenderList != null && appenderList.Count > 0)
            {
                foreach (XmlNode singleAppender in appenderList)
                {
                    String type = singleAppender.Attributes["type"].InnerText;
                    if (type.Equals("log4net.Appender.RollingFileAppender"))
                    {
                        try 
                        {
                            XmlNode fileNode = singleAppender.SelectSingleNode("file");
                            directory = fileNode.Attributes["value"].InnerText;
                            XmlNode rollingNode = singleAppender.SelectSingleNode("maxSizeRollBackups");
                            rollingFileSize = Int32.Parse(rollingNode.Attributes["value"].InnerText);
                        } 
                        catch (Exception e)
                        {
                            log.Error("deleteOldLog Error: error parse XML - " + e.Message);
                        }
                    }
                }
            }

            if (directory != null && !directory.Equals("") && rollingFileSize > 0)
            {
                int index = directory.LastIndexOf("/");
                if (index > 0)
                {
                    directory = directory.Substring(0, index);
                    try {
                        DirectoryInfo info = new DirectoryInfo(directory);
                        FileInfo[] files = info.GetFiles("VideoBookApplication-*").OrderBy(p => p.CreationTime).ToArray();
                        int numFilesToDelete = files.Length - rollingFileSize;
                        if (numFilesToDelete > 0)
                        {
                            for (int i = 0; i < numFilesToDelete; i++)
                            {
                                log.Info("Delete Old File : " + files[i].Name);
                                files[i].Delete();
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        log.Error("deleteOldLog Error: error delete File - " + e.Message);
                    }

                }
            }
            else
            {
                log.Error("deleteOldLog Error: error parse XML");
            }


        }
    }
}
