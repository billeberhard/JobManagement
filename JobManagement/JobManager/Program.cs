using DataLayer.Repository;
using DataLayer.TransferObjects;

namespace JobManager
{
    public class Program
    {
        public static Repository r = new Repository();

        public static void Main(string[] args)
        {
            RemoveData();
            CreateData();
            
            ShowData();
        }

        private static void CreateData()
        {
            //Customer customer1 = new Customer("Customer1", 1234);
            //Customer customer2 = new Customer("Customer2", 2345);
            //Customer customer3 = new Customer("Customer3", 3456);
            
            //Order order1 = new Order(DateTime.Now, customer1);
            //Order order2 = new Order(DateTime.Now, customer2);
            //Order order3 = new Order(DateTime.Now, customer3);

            //r.Orders.Add(order1);
            //r.Orders.Add(order2);
            //r.Orders.Add(order3);
        }

        private static void ShowData()
        {
            Console.WriteLine("\r\n--- Customers --- \r\n");

            foreach (Customer customer in r.Customers.GetAll())
                Console.WriteLine(customer);

            Console.WriteLine("\r\n--- Orders --- \r\n");
            foreach (Order order in r.Orders.GetAll())
                Console.WriteLine(order);
        }
        private static void RemoveData()
        {
            r.Orders.Clear();
            r.Customers.Clear();
        }
    }
}