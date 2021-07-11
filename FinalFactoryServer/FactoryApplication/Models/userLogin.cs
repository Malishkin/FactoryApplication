using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FactoryApplication.Models
{
    public class userLogin
    {
        //public int ID { get; set; }
        public int user_id { get; set; }
        public string fullName { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public int num_of_actions { get; set; }
        //public int actions { get; set; }
        public System.DateTime enterDate { get; set; }
    }
}