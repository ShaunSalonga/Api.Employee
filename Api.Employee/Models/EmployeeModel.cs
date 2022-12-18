using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api.Employee.Models
{
    public class EmployeeModel : PersonModel
    {
        public int EmployeeId { get; set; }
        public int StatusId { get; set; }
    }
}