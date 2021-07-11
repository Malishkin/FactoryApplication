using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FactoryApplication.Models
{
    public class ExtendedEmployeeBL
    {
        factoryDBEntities db = new factoryDBEntities();

        public List<ExtendedEmployee> GetAllEmployees()
        {
            //var result = (from emp in db.employee
            //             join
            //empSh in db.employeeShift on emp.ID equals empSh.employee_id
            //             join
            //sh in db.shift on empSh.shift_id equals sh.ID
            //             select new ExtendedEmployee
            //             {
            //                 ID = emp.ID,
            //                 fName = emp.fName,
            //                 lName = emp.lName,
            //                 startWorkYear = emp.startWorkYear,
            //                 department_id = emp.department_id,
            //                 date = sh.date,
            //                 startTime = sh.startTime,
            //                 endTime = sh.endTime

            //             }).OrderBy(x=>x.ID);
            //return result.ToList();

            List<ExtendedEmployee> lst = new List<ExtendedEmployee>();

            foreach (var emp in db.employee.OrderBy(x=>x.lName))
            {
                ExtendedEmployee extendedEmployee = new ExtendedEmployee();
                extendedEmployee.ID = emp.ID;
                extendedEmployee.fName = emp.fName;
                extendedEmployee.lName = emp.lName;
                extendedEmployee.startWorkYear = emp.startWorkYear;
                extendedEmployee.department_id = emp.department_id;
                extendedEmployee.shifts = new List<shift1>();

                foreach (var eshift in db.employeeShift1.Where(x => x.employee_id == emp.ID))
                {
                    foreach (var sh1 in db.shift1.Where(x => x.ID == eshift.shift1_id))
                    {
                        extendedEmployee.shifts.Add(sh1);
                    }
                }
                lst.Add(extendedEmployee);



            }
            return lst;
        }

        public List<ExtendedEmployee> GetEmployee(int id)
        {
            //var result = (from emp in db.employee
            //              join
            // empSh in db.employeeShift on emp.ID equals empSh.employee_id
            //              join
            // sh in db.shift on empSh.shift_id equals sh.ID
            //              select new ExtendedEmployee
            //              {
            //                  ID = emp.ID,
            //                  fName = emp.fName,
            //                  lName = emp.lName,
            //                  startWorkYear = emp.startWorkYear,
            //                  department_id = emp.department_id,
            //                  date = sh.date,
            //                  startTime = sh.startTime,
            //                  endTime = sh.endTime

            //              }).Where(x => x.ID == id);


            //return result.ToList();
            List<ExtendedEmployee> lst = new List<ExtendedEmployee>();

            foreach (var emp in db.employee.Where(x=>x.ID==id))
            {
                ExtendedEmployee extendedEmployee = new ExtendedEmployee();
                extendedEmployee.ID = emp.ID;
                extendedEmployee.fName = emp.fName;
                extendedEmployee.lName = emp.lName;
                extendedEmployee.startWorkYear = emp.startWorkYear;
                extendedEmployee.department_id = emp.department_id;
                extendedEmployee.shifts = new List<shift1>();

                foreach (var eshift in db.employeeShift1.Where(x=>x.employee_id == emp.ID))
                {
                    foreach (var sh1 in db.shift1.Where(x=>x.ID == eshift.shift1_id))
                    {
                        extendedEmployee.shifts.Add(sh1);
                    }
                }lst.Add(extendedEmployee);

            }
            return lst;

        }

        public int AddEmployee(employee emp)
        {
            db.employee.Add(emp);
            db.SaveChanges();
            return emp.ID;
        }




        public void UpdateEmployee(int id, employee emp)
        {
            var currentEmployee = db.employee.Where(x => x.ID == id).First();
            currentEmployee.fName = emp.fName;
            currentEmployee.lName = emp.lName;
            currentEmployee.startWorkYear = emp.startWorkYear;
            currentEmployee.department_id = emp.department_id;
            db.SaveChanges();
        }

        public void DeleteEmployee(int id)
        {
            var currentEmployee = db.employee.Where(x => x.ID == id).First();
            db.employee.Remove(currentEmployee);
            db.SaveChanges();
        }

        

    }
}