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
    
    public class LoginController : ApiController
    {
        private static LoginBL bl = new LoginBL();
        // GET: api/Login
        public IEnumerable<user> Get()
        {
            return bl.GetAllUsers();
        }

        //GET: api/Login/5

        public bool Get(int id)
        {
            return bl.checkALogs(id);
        }
        //public user Get(int id)
        //{
        //    return bl.GetUserById(id);
        //}

        // POST: api/Login
        public user Post(user us)
        {
            return bl.VerifyUser(us);
        }

        // PUT: api/Login/5
        public string Put(int id, user_actions user)
        {
            bl.AddAction(id, user);
            return "Added";


         }

        // DELETE: api/Login/5
        public void Delete(int id)
        {
        }
    }
}
