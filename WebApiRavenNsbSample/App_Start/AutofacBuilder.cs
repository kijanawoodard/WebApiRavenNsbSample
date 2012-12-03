using System.Reflection;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using Common;
//using Common.Indexes;
using Common.Infrastructure;
using Common.Infrastructure.Autofac;
//using PublicService.Framework.Tasks;
using NServiceBus;
using Raven.Client;
using Raven.Client.Indexes;
//using Raven.Client.MvcIntegration;

namespace PublicService.Framework.Autofac
{
    public class AutofacBuilder
    {

        public static void Configure()
        {
            var builder = new ContainerBuilder();

            #region Module Registrations

            builder.RegisterModule(new RavenDbModule());
            builder.RegisterModule(new NServiceBusModule());

            #endregion

            #region Type Registration

            //builder.RegisterType<ApiSecurity>().As<IApiSecurity>().InstancePerApiRequest();
            //builder.RegisterType<AesCrypto>().As<IAesCrypto>().InstancePerApiRequest();
            //builder.RegisterType<AppLogger>().As<IAppLogger>().InstancePerApiRequest();

            #endregion

            #region Register Globals

            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly());
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            #endregion

            var container = builder.Build();

            #region Set Dependency Resolvers

            // Set the dependency resolver implementation as well as WebApi Resolver.
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            System.Web.Http.GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            #endregion

            #region Set RavenDB Finishing Touches

            //RavenProfiler.InitializeFor(container.Resolve<IDocumentStore>());
            //IndexCreation.CreateIndexes( typeof( MemberSearch ).Assembly, container.Resolve<IDocumentStore>() );

            #endregion
        }
    }
}