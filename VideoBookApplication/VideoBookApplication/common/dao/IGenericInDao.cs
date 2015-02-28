using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoBookApplication.common.dao
{
    interface IGenericInDao<in T>
    {
        void write(T obj);

        void update(T obj);
    }
}
