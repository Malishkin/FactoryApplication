using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FactoryApplication.Models;
using System.Web.Http.Cors;

namespace FactoryApplication.Controllers
{
    [EnableCors(origins:"*", methods:"*", headers:"*")]
    public class DepartmentController : ApiController
    {
        private static ExtendDepartmentBL bl = new ExtendDepartmentBL();
        // GET: api/Department
        public IEnumerable<ExtendDepartment> Get()
        {
            return bl.GetAllDepartments();
        }

        // GET: api/Department/5
        public ExtendDepartment Get(int id)
        {
            return bl.GetDepartment(id);
        }

        // POST: api/Department
        public int Post(department1 dep)
        {
            return bl.AddDepartment(dep);
        }

        // PUT: api/Department/5
        public string Put(int id, department1 dep)
        {
            bl.UpdateDepartment(id, dep);
            return "Updated";
        }

        // DELETE: api/Department/5
        public string Delete(int id)
        {
            return bl.DeleteDepartment(id);
        }
    }
}
