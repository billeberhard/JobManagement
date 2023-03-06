using DataLayer.Model;

namespace DataLayer.TransferObjects
{
    public class Order
    {
        public Order()
        { }
        internal Order(OrderEntity entity)
        {
            Id = entity.Id;
            CreationDate = entity.CreationDate;
            Customer = new Customer(entity.Customer);
        }

        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public Customer Customer { get; set; }
        public ICollection<Position> Positions { get; set; } = new List<Position>();

        internal OrderEntity ToEntity()
        {
            var entity = new OrderEntity()
            {
                CreationDate = CreationDate,
                Customer = Customer.ToEntity()
            };

            if (Id != 0)
                entity.Id = Id;

            return entity;
        }
    }
}