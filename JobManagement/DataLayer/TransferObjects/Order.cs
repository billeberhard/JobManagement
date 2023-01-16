using DataLayer.Model;

namespace DataLayer.TransferObjects
{
    public class Order : IConvertableToEntity<OrderEntity>
    {
        public DateTime Date { get; set; }
        public Customer Customer { get; set; }

        public Order(DateTime date, Customer customer)
        {
            Date = date;
            Customer = customer;
        }
        public Order(OrderEntity entity)
        {
            Date = entity.Date;
            Customer = new Customer(entity.Customer);
        }
        public OrderEntity ConvertToEntity()
        {
            return new OrderEntity()
            {
                Customer = this.Customer.ConvertToEntity(),
                Date = Date
            };
        }
        public override string ToString()
        {
            return $"Order: Date={Date}\n\r\t{Customer}";
        }
        public override bool Equals(object? obj)
        {
            return obj is Order order &&
                   Date == order.Date &&
                   EqualityComparer<Customer>.Default.Equals(Customer, order.Customer);
        }
    }
}