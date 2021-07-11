using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FactoryApplication.Models
{
    public class ExtendedShift1
    {
        public int ID { get; set; }

        public System.DateTime date { get; set; }
        public int startTime { get; set; }
        public int endTime { get; set; }

        public List<shift1> shifts { get; set; }

        public List<employee> employees { get; set; }
    }
}