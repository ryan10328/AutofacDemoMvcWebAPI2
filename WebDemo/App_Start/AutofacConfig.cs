using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using WebDemo.Services;

namespace WebDemo
{
    public class AutofacConfig
    {
        public static void Bootstrap()
        {
            var assemblies = Assembly.GetExecutingAssembly();
            var config = GlobalConfiguration.Configuration;

            var builder = new ContainerBuilder();

            builder.RegisterControllers(assemblies);
            builder.RegisterApiControllers(assemblies);
            builder.RegisterWebApiModelBinderProvider();

            builder.RegisterModule<AutofacWebTypesModule>();

            builder.RegisterWebApiFilterProvider(config);
            builder.RegisterFilterProvider();


            builder.RegisterAssemblyTypes(assemblies)
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterModule<ServiceModule>();

            builder.RegisterAssemblyTypes(Assembly.Load("WebDemo.Services"))
                .AsImplementedInterfaces()
                .InstancePerRequest();



            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}