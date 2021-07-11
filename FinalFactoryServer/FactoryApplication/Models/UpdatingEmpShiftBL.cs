using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FactoryApplication.Models
{
    public class UpdatingEmpShiftBL
    {
        factoryDBEntities db = new factoryDBEntities();

        public List<UpdatingEmpShift> GetEmpAndShifts()
        {
            List<UpdatingEmpShift> lst = new List<UpdatingEmpShift>();
            foreach (var empSh in db.employeeShift1)
            {
                UpdatingEmpShift updatingEmpShift = new UpdatingEmpShift();
                updatingEmpShift.employee_id = empSh.employee_id;
                updatingEmpShift.shift1_id = empSh.shift1_id;

                foreach (var emp in db.employee.Where(X=>X.ID==updatingEmpShift.employee_id))
                {
                    updatingEmpShift.fName = emp.fName;
                    updatingEmpShift.lName = emp.lName;

                }lst.Add(updatingEmpShift);
            }

            return lst;
        }



        public void AddEmployeeToNewShift(employeeShift1 empS)
        {
            db.employeeShift1.Add(empS);
            db.SaveChanges();


        }
    }
}