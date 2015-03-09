using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using VideoBookApplication.customCSV.common.model;

namespace VideoBookApplication.customCSV.common
{
    public class ProcessCustomObject
    {
        public Dictionary<string, FieldInfoModel> getInfoModels(Object element)
        {
            Dictionary<string, FieldInfoModel> listFields = new Dictionary<string, FieldInfoModel>();
            Type myType = element.GetType();
            IList<PropertyInfo> props = new List<PropertyInfo>(myType.GetProperties());

            foreach (PropertyInfo pi in props)
            {
                FieldInfoModel infoModel = new FieldInfoModel();
                infoModel.fieldName = pi.Name;
                infoModel.fieldType = pi.GetType();
                infoModel.value = pi.GetValue(element, null);

                listFields.Add(infoModel.fieldName, infoModel);

            }

            return listFields;


        }
    }
}
