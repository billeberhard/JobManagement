using Castle.Core.Resource;
using DataLayer.Model;
using DataLayer.TransferObjects;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.DataProvider
{
    internal class MicrosoftSQL : IDataProvider
    {
        public void Add(Customer customer)
        {
            using JobManagementContext context = new JobManagementContext();
            
            context.Customers.Add(customer.ConvertToEntity());
            context.SaveChanges();
        }
        public bool Contains(Customer customer)
        {
            List<Customer> customers = GetAllCustomers();
            foreach (Customer c in customers)
                if (customer.Equals(c))
                    return true;

            return false;
            // return context.Customers.Contains(customer.ConvertToEntity());
        }
        public bool Remove(Customer customer)
        {
            using JobManagementContext context = new JobManagementContext();

            if (!Contains(customer))
                return false;

            context.Customers.Remove(customer.ConvertToEntity());
            context.SaveChanges();
            return true;
        }
        public int CustomerCount
        {

            get
            {
                using JobManagementContext context = new JobManagementContext();

                return context.Customers.Count();
            }
        }
        public Customer? GetCustomer(int id)
        {
            using JobManagementContext context = new JobManagementContext();

            CustomerEntity? entity = context.Customers
                                .Where(c => c.CustomerId == id)
                                .FirstOrDefault();

            return entity == null ? null : new Customer(entity);
        }
        public List<Customer> GetAllCustomers()
        {
            using JobManagementContext context = new JobManagementContext();

            List<Customer> customers = new List<Customer>();
            
            var entitys = context.Customers;
            foreach (CustomerEntity entity in entitys)
                customers.Add(new Customer(entity));

            return customers;
        }
        public void ClearCustomers()
        {
            using JobManagementContext context = new JobManagementContext();

            context.Customers.ExecuteDelete();
            context.SaveChanges();
        }



        public void Add(Order order)
        {
            using JobManagementContext context = new JobManagementContext();

            context.Orders.Add(order.ConvertToEntity());
            context.SaveChanges();
        }
        public bool Contains(Order order)
        {
            List<Order> orders = GetAllOrders();
            foreach (Order o in orders)
                if (order.Equals(o))
                    return true;

            return false;
            // return context.Orders.Contains(order.ConvertToEntity());
        }
        public bool Remove(Order order)
        {
            using JobManagementContext context = new JobManagementContext();

            if (!Contains(order))
                return false;

            context.Orders.Remove(order.ConvertToEntity());
            context.SaveChanges();
            return true;
        }
        public int OrderCount
        {

            get
            {
                using JobManagementContext context = new JobManagementContext();

                return context.Orders.Count();
            }
        }
        public Order? GetOrder(int id)
        {
            using JobManagementContext context = new JobManagementContext();

            OrderEntity? entity = context.Orders
                            .Where(c => c.OrderId == id)
                            .FirstOrDefault();

            return entity == null ? null : new Order(entity);
        }
        public List<Order> GetAllOrders()
        {
            using JobManagementContext context = new JobManagementContext();

            List<Order> orders = new List<Order>();
            
            var entitys = context.Orders;
            foreach (OrderEntity entity in entitys)
                orders.Add(new Order(entity));
            
            return orders;
        }
        public void ClearOrders()
        {
            using JobManagementContext context = new JobManagementContext();

            context.Orders.ExecuteDelete();
            context.SaveChanges();
        }
    }
}
