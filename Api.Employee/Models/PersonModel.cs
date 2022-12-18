using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api.Employee.Models
{
    public class PersonModel : ContactModel
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
    }
}