using AdaYazilim.DataAccess.Abstract;
using AdaYazilim.DataAccess.DTOs;
using AdaYazilim.DataAccess.Helpers;
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
    public class CartController : Controller
    {
        private IShoppingRepository _shoppingRepository;

        public CartController(IShoppingRepository shoppingRepository)
        {
            _shoppingRepository = shoppingRepository;
        }



        [HttpGet]

        public List<Cart> GetCarts()
        {
            return _shoppingRepository.GetAllCarts();
        }
        [HttpGet("{id}")]

        public Cart GetCartById(int id)
        {
            return _shoppingRepository.GetCartById(id);
            //var cartLine = _shoppingRepository.GetCartLineById(id);
            //return CartLineMapper.ToResponseModel(cartLine);
        }


        [HttpPut]

        public void UpdateCart(Cart cart)
        {
            _shoppingRepository.UpdateToCart(cart);
        }
        [HttpDelete("{id}")]

        public void DeleteCart(int id)
        {
            _shoppingRepository.DeleteFromCart(id);
        }







        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }


        [HttpPost("{musteriAdet}/{sepetAdet}")]
        public string TestVerisiOlustur(int musteriAdet, int sepetAdet)
        {
            Random rnd = new Random();
            var myCustomerIdList = new List<int>();
            var myCardIdList = new List<int>();

            string[] Cities = { "Ankara", "İstanbul", "İzmir", "Bursa", "Edirne", "Konya", "Antalya", "Diyarbakır", "Van", "Rize" };
            for (int i = 0; i < musteriAdet; i++)
            {
                var x = _shoppingRepository.AddToCustomers(new Customer
                {

                    FirstName = RandomString(10),
                    LastName = RandomString(10),
                    City = Cities[rnd.Next(0, 10)]

                }).Id;
                myCustomerIdList.Add(x);
            }



            for (int i = 0; i < sepetAdet; i++)
            {

                var x = _shoppingRepository.GetCustomers();
                var totalUserCount = x.Count;

                var y = _shoppingRepository.AddToCart(new Cart
                {

                    CustomerId = myCustomerIdList.ElementAt(rnd.Next(1, musteriAdet))

                }).Id;
                myCardIdList.Add(y);

            }

            for (int x = 0; x < sepetAdet; x++)
            {
                for (int i = 0; i < rnd.Next(1, 6); i++)
                {
                    _shoppingRepository.AddToCartLine(new CartLine
                    {
                        CartId = myCardIdList.ElementAt(x),
                        Price = rnd.Next(100, 1000),
                        Description = RandomString(10)

                    });

                }

            }

            return "";
        }


        [HttpGet("analysisWithSqlQuery")]
        public List<DtoSehirAnaliz> SehirBazliAnalizYap()
        {
            return RawSqlHelper.RawSqlQuery(
                    "SELECT cu.City, COUNT(ca.Id), SUM(cl.Price) " +
                    "FROM Customers cu " +
                    "JOIN Carts ca ON ca.CustomerId = cu.Id " +
                    "JOIN CartLines cl ON cl.CartId = ca.Id " +
                    "GROUP BY cu.City " +
                    "ORDER BY 2 DESC, 3 DESC ",
             x => new DtoSehirAnaliz
             {
                 CityName = (string)x[0],
                 CartCount = (int)x[1],
                 TotalPrice = (double)x[2]
             });
        }
        [HttpGet("analysisWithEntityFramework")]
        public List<DtoSehirAnaliz> SehirBazliAnalizYap2()
        {
            var responseSehirList = new List<DtoSehirAnaliz>();

            var cartList = _shoppingRepository.GetAllCarts();
            foreach (var cart in cartList)
            {
                var cartLinesx = _shoppingRepository.GetCartLines();
                var cartLines = cartLinesx.Where(f => f.CartId == cart.Id);
                var firstTimeCart = true;
                foreach (var cartLine in cartLines)
                {
                    var customer = _shoppingRepository.GetCustomerById(cart.CustomerId);

                    if (responseSehirList.Where(f => f.CityName == customer.City).Count() == 0)
                    {
                        responseSehirList.Add(new DtoSehirAnaliz
                        {
                            CityName = customer.City,
                            CartCount = 1,
                            TotalPrice = cartLine.Price
                        });
                    }
                    else
                    {
                        responseSehirList.First(f => f.CityName == customer.City).TotalPrice += cartLine.Price;
                        if (firstTimeCart)
                        {
                            responseSehirList.First(f => f.CityName == customer.City).CartCount++;
                        }
                    }
                    firstTimeCart = false;
                }
            }
            return responseSehirList.OrderByDescending(f => f.CartCount).ToList();

        }
    }
}
