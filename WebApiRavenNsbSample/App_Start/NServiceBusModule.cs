using Autofac;
using NServiceBus;

namespace Common.Infrastructure.Autofac
{
    public class NServiceBusModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.Register(c =>
                             NServiceBus.Configure.With()
                                        .AutofacBuilder()
                                        .Log4Net()
                                        .MsmqTransport()
                                        .UnicastBus()
                                        .SendOnly())
                   .As<IBus>()
                   .SingleInstance();
        }
    }
}