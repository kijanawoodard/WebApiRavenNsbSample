using NServiceBus;

namespace Sample.NServiceBus.Conventions
{
    public class UnobtrusiveConventions : IWantToRunBeforeConfiguration
    {
        //http://www.serrate.net/2012/10/16/nservicebus-dry-with-unobtrusive-conventions/
        public void Init()
        {
                Configure.Instance
                     .DefiningCommandsAs(t => t.Namespace != null
                                              && t.Namespace.EndsWith("Commands"))
                     .DefiningEventsAs(t => t.Namespace != null
                                            && (t.Namespace.EndsWith("Events") || t.Namespace.EndsWith("Contracts")));
//                     .DefiningMessagesAs(t => t.Namespace != null
//                                              && t.Namespace.EndsWith("Messages"));
        }
    }
}