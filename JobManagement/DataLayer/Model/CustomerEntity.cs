using System.ComponentModel.DataAnnotations;

namespace DataLayer.Model
{
    public class CustomerEntity
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }

        [Required]
        public virtual AddressEntity Address { get; set; }

        [Required]
        [MaxLength(200)]
        public string EmailAddress { get; set; }

        [Required]
        [MaxLength(255)]
        public string WebsiteURL { get; set; }

        [Required]
        [MaxLength(255)]
        public string Password { get; set; }

        public virtual ICollection<OrderEntity> Orders { get; set; }
    }
}