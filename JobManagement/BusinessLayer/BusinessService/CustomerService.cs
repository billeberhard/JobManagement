using DataLayer.Repository;
using DataLayer.TransferObjects;
using Microsoft.IdentityModel.Tokens;

namespace BusinessLayer.BusinessService
{
    public class CustomerService
    {
        private readonly ICustomerRepository _repository;

        public CustomerService(ICustomerRepository repository)
        {
            _repository = repository;
        }

        //GetCustomerById
        /* 
        public List<CustomerService> GetCustomerById(int id)
        {
           var customer = _repository.GetById(id);
            return new CustomerService(customer);
        }
        //GetCustomerBySearchTerm
        public List<CustomerService> GetCustomersBySearchTerm(string searchTerm)
        {
            var customers = _repository.GetBySearchTerm(searchTerm);
            return (List<CustomerService>)customers;
        }*/

        //GetAllCustomers
        public List<CustomerService> GetAllCustomers()
        {
            
            var customers = _repository.GetAll();
            return (List<CustomerService>)customers;
        }

        //AddNewCustomer
        //public void AddNewCustomer(CustomerService customer)
        //{
        //    _repository.Add(customer);
        //}
        ////DeleteCustomerByDto
        //public string DeleteCustomerByDto(CustomerService customer)
        //{
        //    return _repository.Remove(CustomerService.CustomerDtoToCustomer(customer));
        //}
        ////UpdateCustomerByDto
        //public void UpdateCustomerByDto(CustomerService customer)
        //{
        //    _repository.Update(CustomerService.CustomerDtoToCustomer(customer));
        //}
        //SetAdressByICustomerAndAddressDto
        //public void SetAddressByICustomerAndAddressDto(CustomerService customer, LocationService address)
        //{
        //    customerRepository_.SetAddressByCustomerAndAddress(
        //        CustomerDto.CustomerDtoToCustomer(customer),
        //        AddressDto.AddressDtoToAddress(address));
        //}
    }
  
}

