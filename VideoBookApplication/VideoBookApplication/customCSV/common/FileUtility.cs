using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoBookApplication.customCSV.common
{
    public class FileUtility
    {

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private string fileName;
        private string backupFileName;

        public FileUtility(string fileName) 
        {
            this.fileName = fileName;
            this.backupFileName = getBackupFileName();
            backupFile();
        }

        public void backupFile()
        {
            if (File.Exists(fileName))
            {
                try
                {
                    File.Copy(fileName, backupFileName, true);
                    File.Delete(fileName);
                }
                catch (Exception e)
                {
                    log.Error(e.Message);
                }
            }
            else
            {
                backupFileName = null;
            }
        }

        public void restoreBackup()
        {
            if (backupFileName != null)
            {
                try
                {
                    File.Copy(backupFileName, fileName, true);
                }
                catch (Exception e)
                {
                    log.Error(e.Message);
                }
            }
        }

        public void deleteBackup()
        {
            if (backupFileName != null)
            {
                if (File.Exists(backupFileName))
                {
                    try
                    {
                        File.Delete(backupFileName);
                    }
                    catch (Exception e)
                    {
                        log.Error(e.Message);
                    }
                }
            }
        }

        private string getBackupFileName()
        {
            string backupFile = null;
            string folder = "";
            string file = "";

            int index = this.fileName.LastIndexOf("\\");
            if (index < 0)
            {
                index = this.fileName.LastIndexOf("/");
            }
            if (index >= 0)
            {
                //estrazione folder e filename
                folder = this.fileName.Substring(0, index);
                file = this.fileName.Substring(index+1);
                if (file != null && !file.Equals(""))
                {
                    file = "backup_" + file;
                    if (folder != null && !folder.Equals(""))
                    {
                        backupFile = folder + file;
                        log.Info("Backup : " + backupFile);
                    }
                    else
                    {
                        backupFile = null;
                    }
                }
                else
                {
                    backupFile = null;
                }
            }
            return backupFile;
        }

    }
}
