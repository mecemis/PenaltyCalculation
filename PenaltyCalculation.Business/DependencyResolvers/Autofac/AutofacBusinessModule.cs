using Autofac;
using System;
using System.Collections.Generic;
using System.Text;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using PenaltyCalculation.DataAccess.Abstract;
using PenaltyCalculation.DataAccess.Concrete.EntityFramework;
using PenaltyCalculation.Business.Concrete;
using PenaltyCalculation.Business.Abstract;
using PenaltyCalculation.Core.Utilities.Interceptors;

namespace PenaltyCalculation.Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CountryManager>().As<ICountryService>();
            builder.RegisterType<EfCountryDal>().As<ICountryDal>();

            builder.RegisterType<LibraryManager>().As<ILibraryService>();


            //for using aspect interceptors
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
