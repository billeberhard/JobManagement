using DataLayer.Model;

namespace DataLayer.TransferObjects
{
    public class Order
    {
        public Order(DateTime creationData, Customer customer)
        {
            CreationData = creationData;
            Customer = customer;
        }
        internal Order(OrderEntity entity)
        {
            OrderId = entity.OrderId;
            CreationData = entity.CreationData;
            Customer = new Customer(entity.Customer);
        }

        public int OrderId { get; set; }
        public DateTime CreationData { get; set; }
        public Customer Customer { get; set; }

        internal OrderEntity ConvertToEntity()
        {
            return new OrderEntity()
            {
                CreationData = CreationData,
                Customer = Customer.ConvertToEntity()
            };
        }
        public override string? ToString()
        {
            return $"{CreationData.ToString("dd.MM.yyyy")}, {Customer}";
        }
        public override bool Equals(object? obj)
        {
            return obj is Order order &&
                   OrderId == order.OrderId;
        }
        public bool DataEquals(object? obj)
        {
            return obj is Order order &&
                   CreationData == order.CreationData &&
                   Customer.DataEquals(order.Customer);
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(OrderId, CreationData, Customer);
        }
    }
}