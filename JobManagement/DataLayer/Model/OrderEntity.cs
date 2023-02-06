namespace DataLayer.Model
{
    public class OrderEntity
    {
        public int OrderId { get; set; }
        public DateTime CreationData { get; set; }
        public int CustomerId { get; set; }
        public virtual CustomerEntity Customer { get; set; }

        public virtual ICollection<PositionEntity> Positions { get; set; }
    }
}