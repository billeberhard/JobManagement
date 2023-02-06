namespace DataLayer.Model
{
    public class LocationEntity
    {
        public int LocationId { get; set; }
        public string PostalCode { get; set; }
        public string Name { get; set; }

        public virtual ICollection<CustomerEntity> Customers { get; set; }
    }
}