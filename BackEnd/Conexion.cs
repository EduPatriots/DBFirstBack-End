using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DatabaseFirstDWB_Sabado.Backend
{
    interface Conexion<T> where T : class
    {
        IQueryable<T> GetData();
        T GetDataByID(int id);
    }
}
