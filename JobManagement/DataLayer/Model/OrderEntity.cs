namespace DataLayer.Model
{
    public class OrderEntity
    {
        public int OrderId { get; set; }
        public DateTime Date { get; set; }

        public virtual CustomerEntity Customer { get; set; }
    }
}