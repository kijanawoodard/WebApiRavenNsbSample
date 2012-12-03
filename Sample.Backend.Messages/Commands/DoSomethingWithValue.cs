namespace Sample.Backend.Messages.Commands
{
    public class DoSomethingWithValue
    {
        public string Value { get; set; }

        public override string ToString()
        {
            return string.Format("Value: {0}", Value);
        }
    }
}
