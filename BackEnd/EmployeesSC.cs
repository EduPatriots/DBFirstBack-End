using DBFirstBack_End.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DatabaseFirstDWB_Sabado.Backend
{
    class EmployeesSC : Conexion<Employees>
    {
        NorthwindContext dataContext = new NorthwindContext();
        public IQueryable<Employees> GetData()
        {
            return dataContext.Employees.Select(s => s);
        }
        public Employees GetDataByID(int id)
        {
            return GetData().Where(w => w.EmployeeId == id).FirstOrDefault();
        }
    }
}
