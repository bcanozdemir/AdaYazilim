using AdaYazilim.DataAccess.Abstract;
using AdaYazilim.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdaYazilim.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : Controller
    {
        private IShoppingRepository _shoppingRepository;

        public CustomerController(IShoppingRepository shoppingRepository)
        {
            _shoppingRepository = shoppingRepository;
        }


        [HttpGet]
        public List<Customer> GetCustomers()
        {
            return _shoppingRepository.GetCustomers();
        }

        [HttpGet("{id}")]
        public Customer GetCustomerById(int id)
        {
            return _shoppingRepository.GetCustomerById(id);
            //var cartLine = _shoppingRepository.GetCartLineById(id);
            //return CartLineMapper.ToResponseModel(cartLine);
        }
        [HttpPost]
        //   [Route("Customers")]
        public void AddCustomer([FromBody] Customer customer)
        {
            _shoppingRepository.AddToCustomers(customer);
        }

        [HttpPut]
      
        public void UpdateCustomer(Customer customer)
        {
            _shoppingRepository.UpdateToCustomer(customer);
        }
        [HttpDelete("{id}")]
       
        public void DeleteCustomer(int id)
        {
            _shoppingRepository.DeleteFromCustomer(id);
        }
    }
}
