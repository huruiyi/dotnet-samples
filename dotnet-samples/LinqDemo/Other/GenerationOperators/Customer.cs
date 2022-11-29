namespace GenerationOperators
{
    public class Customer
    {
        public Customer(string customerID, string companyName)
        {
            CustomerID = customerID;
            CompanyName = companyName;
            Orders = new Order[10];
        }

        public Customer()
        {
        }

        public string CustomerID;
        public string CompanyName;
        public string Address;
        public string City;
        public string Region;
        public string PostalCode;
        public string Country;
        public string Phone;
        public string Fax;
        public Order[] Orders;
    }
}