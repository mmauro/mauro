using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace VideoBookApplication.common.utility
{
    public class Configurator
    {
        private static Configurator instance = null;
        private Dictionary<String, String> configProperties = null;

        private Configurator()
        {
            configProperties = new Dictionary<String, String>();
            readProperties();
        }

        private void readProperties()
        {
            try
            {
                String confContent = global::VideoBookApplication.Properties.Resources.Videobook;
                string[] lines = Regex.Split(confContent, "\r\n|\r|\n");
                foreach (String singleLine in lines)
                {
                    if (singleLine != null && singleLine.Length > 0)
                    {
                        if (!singleLine.StartsWith("#"))
                        {
                            int indexSeparator = singleLine.IndexOf("=");
                            if (indexSeparator > 0)
                            {
                                String key = singleLine.Substring(0, indexSeparator).Trim();
                                String value = singleLine.Substring(indexSeparator + 1).Trim();
                                if (key != null && key != "")
                                {
                                    configProperties.Add(key, value);
                                }
                            }
                        }
                    }
                }

            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
            }
        }

        public static Configurator getInstsance()
        {
            if (instance == null)
            {
                instance = new Configurator();
            }
            return instance;
        }

        public String get(String key)
        {
            String value = null;
            if (key != null)
            {
                if (configProperties.ContainsKey(key))
                {
                    value = configProperties[key];
                }
            }

            return value;
        }

        public bool getBoolean(String key)
        {
            bool value = false;
            if (key != null)
            {
                if (configProperties.ContainsKey(key))
                {
                    value = Utility.toBoolean(configProperties[key]);
                }
            }
            return value;
        }

        public int getInt(String key)
        {
            if (key != null)
            {
                try
                {
                    return Int32.Parse(configProperties[key]);
                }
                catch (Exception e)
                {
                    return Configurator.getInstsance().getInt("notfound.value");
                }
            }
            else
            {
                return Configurator.getInstsance().getInt("notfound.value");
            }
        }

    }
}
