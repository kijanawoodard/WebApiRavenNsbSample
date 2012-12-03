using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using Autofac.Integration.WebApi;
//using Common.Indexes;
//using Common.Models;
using Raven.Client;
using Raven.Client.Document;
using Raven.Client.Indexes;
using Raven.Client.Shard;
//using Raven.Client.UniqueConstraints;
using NServiceBus.ObjectBuilder;

namespace Common.Infrastructure.Autofac
{
    public class RavenDbModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            IDocumentStore store = new DocumentStore
            {
                ConnectionStringName = "RavenDB",
                Conventions = new DocumentConvention
                {
                    TransformTypeTagNameToDocumentKeyPrefix = typeTagName => typeTagName
                }
            };//.RegisterListener( new UniqueConstraintsStoreListener() );
            store.Initialize();

            // Single Instance of the DocumentStore
            builder.RegisterInstance(store).SingleInstance();

            // OpenSession for each request, as well as for WebApi
            builder.Register(c => c.Resolve<IDocumentStore>().OpenSession()).InstancePerLifetimeScope().InstancePerApiRequest();
        }
    }
}