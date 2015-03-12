using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoBookApplication.common.enums;
using VideoBookApplication.common.utility;
using VideoBookApplication.customCSV.common.model;

namespace VideoBookApplication.customCSV.common
{
    public class ProcessRow
    {

        private FormatterCSV formatter;

        public ProcessRow(FormatterCSV formatter) {
            this.formatter = formatter;
        }

        public string processRow(List<String> header)
        {
            string value = "";
            foreach (string valore in header)
            {
                try
                {
                    FieldInfoModel model = new FieldInfoModel();
                    model.value = valore;
                    model.fieldType = typeof(string);
                    value += formatter.cellSeparator + processField(model);
                }
                catch (VideoBookException e)
                {
                    throw e;
                }
            }
            if (value.StartsWith(formatter.cellSeparator))
            {
                value = value.Substring(formatter.cellSeparator.Length);
            }
            return value;
        }

        public string processRow(Dictionary<string, FieldInfoModel> fieldList, List<String> header)
        {
            string value = "";
            foreach (string fieldName in header)
            {
                if (fieldList.ContainsKey(fieldName))
                {
                    value += formatter.cellSeparator + processField(fieldList[fieldName]);
                }
                else
                {
                    throw new VideoBookException(ApplicationErrorType.FIELD_ERROR);
                }
            }
            if (value.StartsWith(formatter.cellSeparator))
            {
                value = value.Substring(formatter.cellSeparator.Length);
            }

            if (value != null && !value.Equals(""))
            {
                value += formatter.rowSeparator;
            }
            else
            {
                throw new VideoBookException(ApplicationErrorType.INVALID_ROW);
            }

            return value;
        }

        public string processField(FieldInfoModel model)
        {
            if (model != null)
            {
                if (model.fieldType == typeof(string))
                {
                    string fieldValue = (string)model.value;
                    if (fieldValue != null)
                    {
                        if (fieldValue.Contains(formatter.cellSeparator))
                        {
                            fieldValue = fieldValue.Replace(formatter.cellQuote, "\\" + formatter.cellQuote);
                            fieldValue = formatter.cellQuote + fieldValue + formatter.cellQuote;
                        }
                    }
                    else
                    {
                        fieldValue = "";
                    }
                    return fieldValue;
                }
                else
                {
                    return model.value.ToString();
                }
            }
            else
            {
                throw new VideoBookException(ApplicationErrorType.INVALID_INFO_MODEL);
            }
        }
    }
}
