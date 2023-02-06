namespace DataLayer.Model
{
    public class CustomerEntity
    {
        public int CustomerId { get; set; }
        public int CustomerNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int LocationId { get; set; }
        public virtual LocationEntity Location { get; set; }
        public string StreetName { get; set; }
        public string HouseNumber { get; set; }
        public string EmailAddress { get; set; }
        public string WebsiteURL { get; set; }
        public string Password { get; set; }

        public virtual ICollection<OrderEntity> Orders { get; set; }
    }
}