using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoBookApplication.common.dao
{
    interface IGenericOutDao<out T>
    {
        
        T readOne(object value);
        IEnumerable<T> readMany(Object value);
        IEnumerable<T> readAll();

    }
}
