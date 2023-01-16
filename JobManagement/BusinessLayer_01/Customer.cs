namespace BusinessLayer
{
    public static class Customer
    {
        private static CustomerController _customerdController = new CustomerController();
        public List<CustomerTransferObject> GetAllCustomers()
        {
            List<CustomerTransferObject> customers = DataLayer.CustomerController.GetCustomers();
            return _customerdController.GetCustomers();
        }
    }
}