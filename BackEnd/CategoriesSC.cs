using DBFirstBack_End.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DatabaseFirstDWB_Sabado.Backend
{
    class CategoriesSC : Conexion<Categories>
    {
        NorthwindContext dataContext = new NorthwindContext();
        public IQueryable<Categories> GetData()
        {
            return dataContext.Categories.Select(s => s);
        }
        public Categories GetDataByID(int id)
        {
            return GetData().Where(w => w.CategoryId == id).FirstOrDefault();
        }

    }
}
