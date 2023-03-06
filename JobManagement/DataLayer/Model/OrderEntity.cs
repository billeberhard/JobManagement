using System.ComponentModel.DataAnnotations;

namespace DataLayer.Model
{
    public class OrderEntity
    {
        public int Id { get; set; }

        [Required]
        public DateTime CreationDate { get; set; }

        [Required]
        public virtual CustomerEntity Customer { get; set; }

        public virtual ICollection<PositionEntity> Positions { get; set; }
    }
}