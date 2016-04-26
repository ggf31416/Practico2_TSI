using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Shared.Entities;
using BusinessLogicLayer;
using Microsoft.Practices.Unity;
using System.Net.Http;
using System.Net;
using System.Web.Http.Cors;


namespace WebAPI.Controllers
{
    [EnableCors(origins: "localhost", headers: "*", methods: "*")]
    public class EmployeeController : ApiController
    {

        IBLEmployees blHandler;


        public EmployeeController(IBLEmployees _blHandler) : base()
        {
            this.blHandler = _blHandler;
        }


        public IHttpActionResult GetEmployee(int id)
        {

            Employee emp = blHandler.GetEmployee(id);
            if (emp == null) return NotFound();
            return Ok(emp);
        }

        public IEnumerable<EmployeeDTO> Get()
        {
            var x = blHandler.GetAllEmployees();
            //var x = new List<Employee>();
            //x.Add(new FullTimeEmployee() { Id = 1, Name = "Guillermo", StartDate = DateTime.Now, Salary = 50000 });
            return x.Select(e => EmployeeDTO.FromShared(e));
        }

        private string listarErrores()
        {
            string errors_txt = String.Join("\n", ModelState.Where(x => x.Value.Errors.Count > 0).
                   Select(
                       x => x.Key.ToString() + ":" +
                           String.Join("", x.Value.Errors.Select(
                               e => e.ErrorMessage + " ex: " + e.Exception?.Message + 
                                " inner ex: " + e.Exception?.InnerException?.Message).ToArray())).
                       ToArray());
            return errors_txt;
        }

        private HttpResponseMessage retornarErrores()
        {
            string txt = listarErrores();
            var r = new HttpResponseMessage(HttpStatusCode.BadRequest);
            r.Content = new StringContent(txt);
            return r;
        }

        public HttpResponseMessage Post([FromBody] EmployeeDTO emp )
        {
            if (ModelState.IsValid)
            {
                blHandler.AddEmployee(emp.toShared());
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            else
            {
                return retornarErrores();
            }

        }

        public HttpResponseMessage Put([FromBody] EmployeeDTO emp)
        {
            if (ModelState.IsValid)
            {
                blHandler.UpdateEmployee(emp.toShared());
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            else
            {
                return retornarErrores();
            }
            
        }

        public HttpResponseMessage Delete(int id)
        {

            blHandler.DeleteEmployee(id);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }



    }
}