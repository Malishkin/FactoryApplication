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
    public class JustShiftController : ApiController
    {
        private static JustShiftBL bl = new JustShiftBL();
        // GET: api/JustShift
        public IEnumerable<shift1> Get()
        {
            return bl.GetAllShifts();
        }

        // GET: api/JustShift/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/JustShift
        public int Post(shift1 sh)
        {
            return bl.AddJustShift(sh);
        }

        // PUT: api/JustShift/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/JustShift/5
        public void Delete(int id)
        {
        }
    }
}
