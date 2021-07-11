using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FactoryApplication.Models
{
    public class ExtendDepartmentBL
    {
        factoryDBEntities db = new factoryDBEntities();

        public List<ExtendDepartment> GetAllDepartments()
        {
            List<ExtendDepartment> lst = new List<ExtendDepartment>();
            foreach (var dep in db.department1)
            {
                ExtendDepartment extendDepartment = new ExtendDepartment();
                extendDepartment.ID = dep.ID;
                extendDepartment.department_name = dep.department_name;
                extendDepartment.department_manager = dep.department_manager;
                if (extendDepartment.department_manager.HasValue)
                {

                    foreach (var emp in db.employee.Where(x=>x.ID==extendDepartment.department_manager))
                    {
                        extendDepartment.managerfName = emp.fName;
                        extendDepartment.managerlName = emp.lName;

                    }
                }
                lst.Add(extendDepartment);
            }

            return lst;
        }

        public ExtendDepartment GetDepartment(int depID)
        {
            department1 dep = db.department1.Where(x => x.ID == depID).First();

            ExtendDepartment extendDepartment = new ExtendDepartment();
            extendDepartment.ID = dep.ID;
            extendDepartment.department_name = dep.department_name;
            extendDepartment.department_manager = dep.department_manager;
            if (extendDepartment.department_manager.HasValue)
            {

                foreach (var emp in db.employee.Where(x => x.ID == extendDepartment.department_manager))
                {
                    extendDepartment.managerfName = emp.fName;
                    extendDepartment.managerlName = emp.lName;

                }
            }
            return extendDepartment;

        }

        public int AddDepartment(department1 dep)
        {
            db.department1.Add(dep);
            db.SaveChanges();
            return dep.ID;

        }

        public void UpdateDepartment(int id, department1 dep)
        {
            var currentDep = db.department1.Where(x => x.ID == id).First();
            currentDep.department_name = dep.department_name;
            currentDep.department_manager = dep.department_manager;
            db.SaveChanges();
        }


        public string DeleteDepartment(int id)
        {
            var currentDep = db.department1.Where(x => x.ID == id).First();
            if (currentDep.department_manager.HasValue == false)
            {
                db.department1.Remove(currentDep);
                db.SaveChanges();
                return "Deleted";
            }
            else
            {
                return "Can't delete this department";
            }

        }



    }
}