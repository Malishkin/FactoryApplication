using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FactoryApplication.Models
{
    public class JustShiftBL
    {
        factoryDBEntities db = new factoryDBEntities();

        public List<shift1>GetAllShifts()
        {
            var lst = db.shift1.OrderBy(x => x.date).ToList();
            return lst;
        }

        public int AddJustShift(shift1 sh)
        {
            db.shift1.Add(sh);
            db.SaveChanges();
            return sh.ID;
        }
    }

}