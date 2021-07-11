using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FactoryApplication.Models
{
    public class ExtendedEmployee
    {
        public int ID { get; set; }

        public string fName { get; set; }
        public string lName { get; set; }
        public int startWorkYear { get; set; }
        public int department_id { get; set; }
        public List<shift1> shifts { get; set; }


        



    }
}