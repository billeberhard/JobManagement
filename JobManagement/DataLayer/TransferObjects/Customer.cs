using DataLayer.Model;

namespace DataLayer.TransferObjects
{
    public class Customer
    {
        public Customer()
        { }
        internal Customer(CustomerEntity entity)
        {
            Id = entity.Id;
            FirstName = entity.FirstName;
            LastName = entity.LastName;
            PostalCode = entity.Address.PostalCode;
            City = entity.Address.City;
            StreetName = entity.Address.StreetName;
            HouseNumber = entity.Address.HouseNumber;
            EmailAddress = entity.EmailAddress;
            WebsiteURL = entity.WebsiteURL;
            Password = entity.Password;
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StreetName { get; set; }
        public string HouseNumber { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string EmailAddress { get; set; }
        public string WebsiteURL { get; set; }
        public string Password { get; set; }

        internal CustomerEntity ToEntity()
        {
            var entity = new CustomerEntity()
            {
                FirstName = FirstName,
                LastName = LastName,
                Address = new AddressEntity()
                {
                    StreetName = StreetName,
                    HouseNumber = HouseNumber,
                    City = City,
                    PostalCode = PostalCode
                },
                EmailAddress = EmailAddress,
                WebsiteURL = WebsiteURL,
                Password = Password
            };

            if (Id != 0)
                entity.Id = Id;

            return entity;
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}