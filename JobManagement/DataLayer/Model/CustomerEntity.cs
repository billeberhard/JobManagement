using System.Diagnostics.CodeAnalysis;

namespace DataLayer.Model
{
    public class CustomerEntity
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public int PostalCode { get; set; }

        public virtual ICollection<OrderEntity> Orders { get; set; }
    }
}