using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NServiceBus;
using Sample.Backend.Messages.Commands;

namespace WebApiRavenNsbSample.Controllers
{
    public class ValuesController : ApiController
    {
        private readonly IBus _bus;

        public ValuesController(IBus bus)
        {
            _bus = bus;
        }

        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post(DoSomethingWithValue command)
        {
            //if there is some fast validations that for some reason can't be done on the client, do them now and return
            //otherwise, send.
            _bus.Send(command);
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}