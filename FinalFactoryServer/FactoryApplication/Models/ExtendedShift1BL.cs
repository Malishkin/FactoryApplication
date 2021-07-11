using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FactoryApplication.Models
{
    public class ExtendedShift1BL
    {
        factoryDBEntities db = new factoryDBEntities();

        public List<ExtendedShift1> GetAllShifts()
        {
            List<ExtendedShift1> lst = new List<ExtendedShift1>();

            foreach (var esh1 in db.employeeShift1)
            {
                ExtendedShift1 extendedShift1 = new ExtendedShift1();
                extendedShift1.ID = esh1.ID;
               
                extendedShift1.shifts = new List<shift1>();
                
                extendedShift1.employees = new List<employee>();
                foreach (var sh1 in db.shift1.Where(x=>x.ID == esh1.shift1_id ))
                {
                    extendedShift1.date = sh1.date;
                    extendedShift1.startTime = sh1.startTime;
                    extendedShift1.endTime = sh1.endTime;
                    foreach (var emp in db.employee.Where(x=>x.ID == esh1.employee_id))
                    {
                        extendedShift1.shifts.Add(sh1);
                        extendedShift1.employees.Add(emp);
                    }

                }
                lst.Add(extendedShift1);
            }

            return lst;
        }

        public List<ExtendedShift1> GetShift(int id)
        {
            List<ExtendedShift1> lst = new List<ExtendedShift1>();

            foreach (var esh1 in db.employeeShift1.Where(x=>x.shift1_id == id))
            {
                ExtendedShift1 extendedShift1 = new ExtendedShift1();
                extendedShift1.ID = esh1.ID;
                extendedShift1.shifts = new List<shift1>();
                extendedShift1.employees = new List<employee>();
                foreach (var sh1 in db.shift1.Where(x => x.ID == esh1.shift1_id))
                {
                    foreach (var emp in db.employee.Where(x => x.ID == esh1.employee_id))
                    {
                        extendedShift1.shifts.Add(sh1);
                        extendedShift1.employees.Add(emp);
                    }

                }
                lst.Add(extendedShift1);
            }

            return lst;
        }

        public int addShift(shift1 shift)
        {
            db.shift1.Add(shift);
            db.SaveChanges();
            return shift.ID;
        }
    }
}