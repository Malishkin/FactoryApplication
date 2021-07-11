using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FactoryApplication.Models
{
    public class ExtendedEmpShift1
    {

        public int ID { get; set; }
        public int employee_id { get; set; }
        public int shift1_id { get; set; }

        public System.DateTime date { get; set; }
        public int startTime { get; set; }
        public int endTime { get; set; }

        public string fName { get; set; }
        public string lName { get; set; }

        public int startWorkYear { get; set; }
        public int department_id { get; set; }
    }
}