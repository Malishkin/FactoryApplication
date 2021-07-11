using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using FactoryApplication.Models;

namespace FactoryApplication.Controllers
{
    [EnableCors(origins: "*", methods: "*", headers: "*")]
    public class EmployeeController : ApiController
    {
        private static ExtendedEmployeeBL bl = new ExtendedEmployeeBL();
        // GET: api/Employee
        public IEnumerable<ExtendedEmployee> Get()
        {
            return bl.GetAllEmployees();
        }

        // GET: api/Employee/5
        public IEnumerable<ExtendedEmployee> Get(int id)
        {
            return bl.GetEmployee(id);
        }

        // POST: api/Employee
        public int Post(employee emp)
        {
            return bl.AddEmployee(emp);

        }

        // PUT: api/Employee/5
        public string Put(int id, employee emp)
        {
            bl.UpdateEmployee(id, emp);
            return "Updated";
        }

        // DELETE: api/Employee/5
        public string Delete(int id)
        {
            bl.DeleteEmployee(id);
            return "Deleted";
        }
    }
}
