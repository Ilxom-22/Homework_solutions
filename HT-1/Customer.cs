namespace HT_1
{
    internal class Customer
    {
        private readonly string _name;
        private readonly string _email;
        private readonly int _id;

        public Customer(string name, string email, int id)
        {
            _name = name;
            _email = email;
            _id = id;
        }

        public string Introduce()
        {
            return @$"Customer name: {_name}
Customer email: {_email}
Customer id: {_id}";
        }
    }
}
