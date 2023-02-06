using DataLayer.Model;

namespace DataLayer.TransferObjects
{
    public class Order : IConvertableToEntity<OrderEntity>
    {
        public Order(DateTime date, Customer customer)
        {
            Date = date;
            Customer = customer;
        }
        internal Order(OrderEntity entity)
        {
            Date = entity.CreationData;
            Customer = new Customer(entity.Customer);
        }

        public DateTime Date { get; set; }
        public Customer Customer { get; set; }

        public OrderEntity ConvertToEntity()
        {
            return new OrderEntity()
            {
                Customer = this.Customer.ConvertToEntity(),
                CreationData = Date
            };
        }
        public override string? ToString()
        {
            return $"{Date.ToString("dd.MM.yyyy")}, {Customer}";
        }
        public override bool Equals(object? obj)
        {
            return obj is Order order &&
                   Date == order.Date &&
                   EqualityComparer<Customer>.Default.Equals(Customer, order.Customer);
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Date, Customer);
        }
    }
}