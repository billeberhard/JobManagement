using DataLayer.Model;

namespace DataLayer.TransferObjects
{
    public class Customer : IConvertableToEntity<CustomerEntity>
    {
        public string FirstName { get; set; }
        public int PostalCode { get; set; }

        public Customer(string firstName, int postalCode)
        {
            FirstName = firstName;
            PostalCode = postalCode;
        }
        public Customer(CustomerEntity entity)
        {
            FirstName = entity.FirstName;
            PostalCode = entity.PostalCode;
        }

        public CustomerEntity ConvertToEntity()
        {
            return new CustomerEntity()
            {
                FirstName = FirstName,
                PostalCode = PostalCode
            };
        }
        public override string ToString()
        {
            return $"Customer: FirstName='{FirstName}' PostalCode='{PostalCode}'";
        }

        public override bool Equals(object? obj)
        {
            return obj is Customer customer &&
                   FirstName == customer.FirstName &&
                   PostalCode == customer.PostalCode;
        }
    }
}