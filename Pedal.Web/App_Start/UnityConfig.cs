using System.Web.Mvc;
using Pedal.Repositories;
using Pedal.Repositories.Interfaces;
using Unity;
using Unity.Mvc5;

namespace Pedal.Web
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IUnitOfWork, UnitOfWork>();
            
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}