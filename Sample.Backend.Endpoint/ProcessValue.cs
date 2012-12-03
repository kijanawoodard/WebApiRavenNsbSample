using System;
using Backend.Samples.Contracts;
using NServiceBus;
using Sample.Backend.Messages.Commands;

namespace Sample.Backend.Endpoint
{
    public class ProcessValue : IHandleMessages<DoSomethingWithValue>
    {
        public IBus Bus { get; set; }

        public void Handle(DoSomethingWithValue message)
        {
            //do some work
            //save value to raven or wherever
            Console.WriteLine(message);
            Bus.Publish<IDidSomethingWithValue>(x => x.Id = "some id we generated or got from raven depending on preference");
        }
    }
}