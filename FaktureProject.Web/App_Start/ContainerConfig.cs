using Autofac;
using Autofac.Integration.Mvc;
using FaktureProject.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FaktureProject.Web
{
    public class ContainerConfig
    {
        internal static void RegisterContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterType<SqlFakturaData>()
                   .As<IFakturaData>()
                   .InstancePerRequest();
            builder.RegisterType<SqlStavkaData>()
                   .As<IStavkaData>()
                   .InstancePerRequest();
            builder.RegisterType<FaktureProjectDbContext>().InstancePerRequest();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}