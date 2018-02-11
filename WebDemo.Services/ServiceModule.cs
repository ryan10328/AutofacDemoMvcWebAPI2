using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using AutoMapper;

namespace WebDemo.Services
{
    public class ServiceModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assemblies = Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assemblies)
                .Where(x => x.Namespace == "WebDemo.Services.Profiles")
                .As<Profile>();

            builder.Register(context => new MapperConfiguration(cfg =>
            {
                foreach (var profile in context.Resolve<IEnumerable<Profile>>())
                {
                    cfg.AddProfile(profile);
                }
            }))
            .AsSelf()
            .SingleInstance();

            builder.Register(context => context.Resolve<MapperConfiguration>()
                                               .CreateMapper(context.Resolve))
                .As<IMapper>()
                .InstancePerLifetimeScope();


        }
    }
}
