using Castle.Core.Resource;
using DataLayer.Model;
using System.Net.Mail;

namespace DataLayer.TransferObjects
{
    public class Customer
    {
        public Customer(string firstName, string lastName, Location location, string streetName, string houseNumber, string emailAddress, string websiteURL, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            Location = location;
            StreetName = streetName;
            HouseNumber = houseNumber;
            EmailAddress = emailAddress;
            WebsiteURL = websiteURL;
            Password = password;
        }
        internal Customer(CustomerEntity entity)
        {
            CustomerId = entity.CustomerId;
            FirstName = entity.FirstName;
            LastName = entity.LastName;
            Location = new Location(entity.Location);
            StreetName = entity.StreetName;
            HouseNumber = entity.HouseNumber;
            EmailAddress = entity.EmailAddress;
            WebsiteURL = entity.WebsiteURL;
            Password = entity.Password;
        }

        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Location Location { get; set; }
        public string StreetName { get; set; }
        public string HouseNumber { get; set; }
        public string EmailAddress { get; set; }
        public string WebsiteURL { get; set; }
        public string Password { get; set; }

        internal CustomerEntity ConvertToEntity()
        {
            return new CustomerEntity()
            {
                FirstName = FirstName,
                LastName = LastName,
                Location = Location.ConvertToEntity(),
                StreetName = StreetName,
                HouseNumber = HouseNumber,
                EmailAddress = EmailAddress,
                WebsiteURL = WebsiteURL,
                Password = Password
            };
        }
        public override string? ToString()
        {
            return $"{FirstName}, {LastName}";
        }
        public override bool Equals(object? obj)
        {
            return obj is Customer customer &&
                   CustomerId == customer.CustomerId;
        }
        public bool DataEquals(object? obj)
        {
            return obj is Customer customer &&
                   FirstName == customer.FirstName &&
                   LastName == customer.LastName &&
                   Location.DataEquals(customer.Location) &&
                   StreetName == customer.StreetName &&
                   HouseNumber == customer.HouseNumber &&
                   EmailAddress == customer.EmailAddress &&
                   WebsiteURL == customer.WebsiteURL &&
                   Password == customer.Password;
        }
        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(CustomerId);
            hash.Add(FirstName);
            hash.Add(LastName);
            hash.Add(Location);
            hash.Add(StreetName);
            hash.Add(HouseNumber);
            hash.Add(EmailAddress);
            hash.Add(WebsiteURL);
            hash.Add(Password);
            return hash.ToHashCode();
        }
    }
}