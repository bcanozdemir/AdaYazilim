using AdaYazilim.DataAccess.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdaYazilim.DataAccess.Concrete;
using AdaYazilim.Entities;

namespace AdaYazilim.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartLineController : Controller
    {
        private IShoppingRepository _shoppingRepository;

        public CartLineController(IShoppingRepository shoppingRepository)
        {
            _shoppingRepository = shoppingRepository;
        }
        [HttpGet]
        public List<CartLine> GetCartLines()
        {
            return _shoppingRepository.GetCartLines();

        }

        [HttpGet("{id}")]
        public CartLine GetCartLineById(int id)
        {
            return _shoppingRepository.GetCartLineById(id);
          
          

        }



        [HttpPost]
        public void AddCartLine(CartLine cartLine)
        {
            _shoppingRepository.AddToCartLine(cartLine);
        }

        [HttpPut]
        public void UpdateCartLine(CartLine cartLine)
        {
            _shoppingRepository.UpdateToCartLine(cartLine);
        }
        [HttpDelete("{id}")]
        public void DeleteCardLine(int id)
        {
            _shoppingRepository.DeleteFromCartLine(id);

        }





    }
}
