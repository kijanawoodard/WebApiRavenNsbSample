using NServiceBus;

namespace Sample.Backend.Endpoint 
{
    public class EndpointConfig : IConfigureThisEndpoint, AsA_Publisher
    {
    }
}