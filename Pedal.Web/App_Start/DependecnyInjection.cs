using Pedal.Data;
using Pedal.Repositories;
using Pedal.Repositories.Interfaces;
using Pedal.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Unity;

namespace Pedal.Web.App_Start
{
    public static class DependecnyInjection
    {
        public static void ResgisterDependency()
        {//
           // var container = new UnityContainer();


            //register services
            //container.RegisterType<IUnitOfWork ,UnitOfWork > ();
           // container.RegisterType<IApplicationDbContext, ApplicationDbContext>();
            


            //register controller

            //var controller = container.Resolve<HomeController>();


        }
    }
}