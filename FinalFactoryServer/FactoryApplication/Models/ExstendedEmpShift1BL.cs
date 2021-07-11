using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FactoryApplication.Models
{
    public class ExstendedEmpShift1BL
    {

        factoryDBEntities db = new factoryDBEntities();

        public List<ExtendedEmpShift1> GetAllEmployeeAndShifts()
        {

            List<ExtendedEmpShift1> lst = new List<ExtendedEmpShift1>();

            foreach (var shift  in db.employeeShift1)
            {
                ExtendedEmpShift1 extendedEmpShift1 = new ExtendedEmpShift1();
                extendedEmpShift1.ID = shift.ID;
                extendedEmpShift1.shift1_id = shift.shift1_id;
                extendedEmpShift1.employee_id = shift.employee_id;


                foreach (var emp in db.employee.Where(x=>x.ID==extendedEmpShift1.employee_id))
                {

                    extendedEmpShift1.fName = emp.fName;
                    extendedEmpShift1.lName = emp.lName;

                    

                } lst.Add(extendedEmpShift1);
            }

            return lst;

        }


        public List<ExtendedEmpShift1> GetOneEmpShift(int id)
        {

            List<ExtendedEmpShift1> lst = new List<ExtendedEmpShift1>();

            foreach (var shift in db.employeeShift1.Where(x=>x.ID==id))
            {
                ExtendedEmpShift1 extendedEmpShift1 = new ExtendedEmpShift1();
                extendedEmpShift1.ID = shift.ID;
                extendedEmpShift1.shift1_id = shift.shift1_id;
                extendedEmpShift1.employee_id = shift.employee_id;


                foreach (var emp in db.employee.Where(x => x.ID == extendedEmpShift1.employee_id))
                {

                    extendedEmpShift1.fName = emp.fName;
                    extendedEmpShift1.lName = emp.lName;



                }
                lst.Add(extendedEmpShift1);
            }

            return lst;

        }

        public void AddEmpShift(ExtendedEmpShift1 empshift)
        {
            employee emp = new employee();
            emp.fName = empshift.fName;
            emp.lName = empshift.lName;
            emp.startWorkYear = empshift.startWorkYear;
            emp.department_id = empshift.department_id;
            db.employee.Add(emp);
            db.SaveChanges();

            shift1 shift = new shift1();
            shift.date = empshift.date;
            shift.startTime = empshift.startTime;
            shift.endTime = empshift.endTime;
            db.shift1.Add(shift);
            db.SaveChanges();
            
        }

        public void UpdateEmpShift(int id, employeeShift1 emp)
        {
            var currentEshift = db.employeeShift1.Where(x => x.ID == id).First();
            currentEshift.shift1_id = emp.shift1_id;
            currentEshift.employee_id = emp.employee_id;
            db.SaveChanges();

        }




    }
}