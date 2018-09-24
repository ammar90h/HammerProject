using HammerProject.Database;
using HammerProject.Database.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace HammerProject.Controllers.Api
{
    public class DepartmentsController : ApiController
    {
        DataContext db = new DataContext();

        // GET: api/Departments
        public IQueryable<Department> Get()
        {
            return db.Departments;
        }

        // GET: api/Departments/5
        [ResponseType(typeof(Department))]
        public IHttpActionResult GetDepartments(int id)
        {
            Department department = db.Departments.Find(id);
            if (department == null)
            {
                return NotFound();
            }

            return Ok(department);
        }
    }
}
