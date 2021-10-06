using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdaYazilim.Entities;

namespace AdaYazilim.DataAccess.Abstract
{
    public interface IShoppingRepository
    {
        public List<CartLine> GetCartLines();
        public void AddToCartLine(CartLine cartLine);
        public CartLine GetCartLineById(int id);
        public void DeleteFromCartLine(int id);
        public void UpdateToCartLine(CartLine cartLine);


        public List<Cart> GetAllCarts();
        public Cart AddToCart(Cart cart);
        public Cart GetCartById(int id);
        public void DeleteFromCart(int id);
        public void UpdateToCart(Cart cart);


        public List<Customer> GetCustomers();
        public Customer AddToCustomers(Customer customer);
        public Customer GetCustomerById(int id);
        public void DeleteFromCustomer(int id);
        public void UpdateToCustomer(Customer customer);



    }
}
