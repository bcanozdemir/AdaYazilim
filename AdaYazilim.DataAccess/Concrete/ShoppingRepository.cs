using System.Collections.Generic;
using System.Linq;
using AdaYazilim.DataAccess.Abstract;
using AdaYazilim.Entities;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using AdaYazilim.DataAccess.DTOs;

namespace AdaYazilim.DataAccess.Concrete
{
    public class ShoppingRepository : IShoppingRepository
    {


        public List<CartLine> GetCartLines()
        {
            using (var adaDbContext = new AdaDbContext())
            {
                return adaDbContext.CartLines.ToList();
            }
        }


        public CartLine GetCartLineById(int id)
        {
            using (var adaDbContext = new AdaDbContext())
            {
                return adaDbContext.CartLines.FirstOrDefault(x => x.Id == id);
            }

        }

        public void AddToCartLine(CartLine cartLine)
        {
            using (var adaDbContext = new AdaDbContext())
            {
                adaDbContext.CartLines.Add(cartLine);
                adaDbContext.SaveChanges();
            }

        }

        public void DeleteFromCartLine(int id)
        {
            using (var adaDbContext = new AdaDbContext())
            {
                var deletedUser = adaDbContext.CartLines.FirstOrDefault(x => x.Id == id);
                adaDbContext.CartLines.Remove(deletedUser);
                adaDbContext.SaveChanges();
            }
        }

        public void UpdateToCartLine(CartLine cartLine)
        {
            using (var adaDbContext = new AdaDbContext())
            {
                var updatedCart = adaDbContext.CartLines.FirstOrDefault(x => x.Id == cartLine.Id);
                updatedCart.Price = cartLine.Price;
                updatedCart.Description = cartLine.Description;
                adaDbContext.CartLines.Update(updatedCart);
                adaDbContext.SaveChanges();
            }
        }

        public List<Cart> GetAllCarts()
        {
            using (var adaDbContext = new AdaDbContext())
            {
                return adaDbContext.Carts.ToList();
            }
        }

        public Cart AddToCart(Cart cart)
        {
            using (var adaDbContext = new AdaDbContext())
            {
                adaDbContext.Carts.Add(cart);
                adaDbContext.SaveChanges();
                return cart;
            }
        }

        public Cart GetCartById(int id)
        {
            using (var adaDbContext = new AdaDbContext())
            {
                return adaDbContext.Carts.FirstOrDefault(x => x.Id == id);
            }
        }

        public void DeleteFromCart(int id)
        {
            using (var adaDbContext = new AdaDbContext())
            {
                var deletedUser = adaDbContext.Carts.FirstOrDefault(x => x.Id == id);

                adaDbContext.Carts.Remove(deletedUser);
                adaDbContext.SaveChanges();
            }
        }

        public void UpdateToCart(Cart cart)
        {
            using (var adaDbContext = new AdaDbContext())
            {
                var updatedCart = adaDbContext.Carts.FirstOrDefault(x => x.Id == cart.Id);
                updatedCart.Customer = cart.Customer;
                updatedCart.CustomerId = cart.CustomerId;
                adaDbContext.Carts.Update(updatedCart);
                adaDbContext.SaveChanges();
            }
        }






        public List<Customer> GetCustomers()
        {

            using (var adaDbContext = new AdaDbContext())
            {
                return adaDbContext.Customers.ToList();
            }

        }
        public Customer AddToCustomers(Customer customer)
        {
            using (var adaDbContext = new AdaDbContext())
            {
                adaDbContext.Customers.Add(customer);
                adaDbContext.SaveChanges();
                return customer;
            }
        }

        public Customer GetCustomerById(int id)
        {
            using (var adaDbContext = new AdaDbContext())
            {
                return adaDbContext.Customers.FirstOrDefault(x => x.Id == id);
            }
        }

        public void DeleteFromCustomer(int id)
        {
            using (var adaDbContext = new AdaDbContext())
            {
                var deletedUser = adaDbContext.Customers.FirstOrDefault(x => x.Id == id);
                adaDbContext.Customers.Remove(deletedUser);
                adaDbContext.SaveChanges();
            }
        }

        public void UpdateToCustomer(Customer customer)
        {
            using (var adaDbContext = new AdaDbContext())
            {
                var updatedCustomer = adaDbContext.Customers.FirstOrDefault(x => x.Id == customer.Id);
                updatedCustomer.FirstName = customer.FirstName;
                updatedCustomer.LastName = customer.LastName;
                updatedCustomer.City = customer.City;
                adaDbContext.Customers.Update(updatedCustomer);
                adaDbContext.SaveChanges();
            }
        }
        public void GetByCity(string cityName)
        {
            using (var adaDbContext = new AdaDbContext())
            {
            }
        }
    }
}
