using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FactoryApplication.Models
{
    public class ExtendDepartment
    {
        public int ID { get; set; }
        public string department_name { get; set; }
        public Nullable<int> department_manager { get; set; }
        public string managerfName { get; set; }
        public string managerlName { get; set; }
    }
}