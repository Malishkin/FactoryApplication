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
    [EnableCors(origins: "*", methods: "*", headers: "*")]
    public class UpdatingShiftEmpController : ApiController
    {
        private static UpdatingEmpShiftBL bl = new UpdatingEmpShiftBL();
        // GET: api/UpdatingShiftEmp
        public IEnumerable<UpdatingEmpShift> Get()
        {
            return bl.GetEmpAndShifts();
        }

        // GET: api/UpdatingShiftEmp/5
        public string Get(int id)
        {
            return "value";
        }


        // POST: api/UpdatingShiftEmp
        public string Post(employeeShift1 empS)
        {
            bl.AddEmployeeToNewShift(empS);
            return "Created";
        }

        // DELETE: api/UpdatingShiftEmp/5
        public void Delete(int id)
        {
        }
    }
}
