using BusinessLogicLayer;
using DataAccessLayer;
using Microsoft.Practices.Unity;
using System.Web.Http;
using Unity.WebApi;

namespace WebAPI
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterType<IDALEmployees, DALEmployeesEF>();
            container.RegisterType<IBLEmployees, BLEmployees>();

            //register a singleton for DAL
            DALEmployeesEF dalEmployeesEF = new DALEmployeesEF();
            container.RegisterInstance(dalEmployeesEF);

            //register a singleton for BL
            BLEmployees blEmployees = new BLEmployees(container.Resolve<IDALEmployees>());
            container.RegisterInstance(blEmployees);

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}