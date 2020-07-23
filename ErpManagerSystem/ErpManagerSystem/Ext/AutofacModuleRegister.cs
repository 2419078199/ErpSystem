using Autofac;
using System;
using System.IO;
using System.Reflection;
using Module = Autofac.Module;

namespace ErpManagerSystem.Ext
{
    public class AutofacModuleRegister : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            string basePath = AppContext.BaseDirectory;
            Assembly servicesAssembly = Assembly.LoadFrom(Path.Combine(basePath, "Services.dll"));
            Assembly repositoryAssembly = Assembly.LoadFrom(Path.Combine(basePath, "Repository.dll"));
            builder.RegisterAssemblyTypes(servicesAssembly)
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(repositoryAssembly)
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}