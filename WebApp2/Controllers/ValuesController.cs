using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApp2.Models;

namespace WebApp2.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public HttpResponseMessage Get()
        {
            using (EmployeeDBContext db= new EmployeeDBContext())
            {
                var emp = db.Employees.ToList();
                return Request.CreateResponse(HttpStatusCode.OK, emp);
            }
        }

        // GET api/values/5
        public HttpResponseMessage Get(int id)
        {
            using (EmployeeDBContext db = new EmployeeDBContext())
            {
                var emp = db.Employees.FirstOrDefault(x => x.ID == id);
                if (emp!=null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, emp);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound,"Employee With Id " + id.ToString() + "Not Found");
                }
            
            }
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
