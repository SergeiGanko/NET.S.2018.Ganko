namespace Account
{
    public sealed class Client
    {
        public Client(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public string FirstName { get; }

        public string LastName { get; }
    }
}
