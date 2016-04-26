using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class EmployeesController : Controller
    {

  

        private EmployeesREST cliente = new EmployeesREST();
        // GET: Employees
        public ActionResult Index()
        {
            var model = cliente.GetEmployees();//.Select(e => EmployeeDTO.FromShared(e));
            return View(model);
        }

        public ActionResult Create()
        {

            return View();
        }
        
        [HttpPost]
        public  ActionResult AddEmployee(EmployeeDTO emp)
        {
           if (ModelState.IsValid)
            {
                //Employee e = emp.toShared();
                 cliente.AddEmployee(emp);
            }
            return RedirectToAction("Index") ;
        }


    }
}