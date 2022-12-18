using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Api.Employee.Database;
using Api.Employee.Models;

namespace Api.Employee.Controllers
{
    [EnableCors(origins: "https://localhost:44307", headers: "*", methods: "*")]
    public class EmployeeController : ApiController
    {
        public IHttpActionResult Get()
        {
            using (var db = new EmployeeEntities())
            {
                IEnumerable<EmployeeModel> result = db.Employee.Select(m => new EmployeeModel()
                {
                    EmployeeId = m.EmployeeId,
                    FirstName = m.FirstName,
                    MiddleName = m.MiddleName,
                    LastName = m.LastName,
                    MobileNumber= m.MobileNumber,
                    EmailAddress = m.EmailAddress,
                    StatusId = (int) m.StatusId
                }).ToList();

                return Ok(result);
            }
        }

        public IHttpActionResult Get(int id)
        {
            using (var db = new EmployeeEntities())
            {
                var employee = db.Employee.Find(id);
                EmployeeModel result = new EmployeeModel
                {
                    EmployeeId = employee.EmployeeId,
                    FirstName = employee.FirstName,
                    MiddleName = employee.MiddleName,
                    LastName = employee.LastName,
                    MobileNumber = employee.MobileNumber,
                    EmailAddress = employee.EmailAddress,
                    StatusId = (int)employee.StatusId
                };
                return Ok(employee);
            }
        }

        public IHttpActionResult Post(EmployeeModel model)
        {
            using (var db = new EmployeeEntities())
            {
                db.Employee.Add(new Database.Employee
                {
                    EmployeeId = model.EmployeeId,
                    FirstName = model.FirstName,
                    MiddleName = model.MiddleName,
                    LastName = model.LastName,
                    MobileNumber = model.MobileNumber,
                    EmailAddress = model.EmailAddress,
                    StatusId = (int)model.StatusId
                });
                db.SaveChanges();
                return Ok();
            }
        }

        public IHttpActionResult Delete(int id)
        {
            using (var db = new EmployeeEntities())
            {
                db.Employee.Remove(db.Employee.Find(id));
                db.SaveChanges();
                return Ok();
            }
        }

        public IHttpActionResult Put(EmployeeModel model)
        {
            using (var db = new EmployeeEntities())
            {
                var employee = db.Employee.Find(model.EmployeeId);
                employee.EmployeeId = model.EmployeeId;
                employee.FirstName = model.FirstName;
                employee.MiddleName = model.MiddleName;
                employee.LastName = model.LastName;
                employee.MobileNumber = model.MobileNumber;
                employee.EmailAddress = model.EmailAddress;
                employee.StatusId = model.StatusId;
                db.SaveChanges();
                return Ok();
            }
        }
    }
}
