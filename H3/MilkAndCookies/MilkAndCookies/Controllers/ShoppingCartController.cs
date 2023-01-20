using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MilkAndCookies.Models;

namespace MilkAndCookies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        [HttpGet("add")]
        public IEnumerable<Product> Get(string productName, double productPrice)
        {
            List<Product> products = new List<Product>();

            Product product = new Product();
            product.Name = productName;
            product.Price = productPrice;

            if (HttpContext.Session.GetObjectFromJson<List<Product>>("Basket") == null)
            {
                products.Add(product);
                HttpContext.Session.SetObjectAsJson("Basket", products);
            }
            else
            {
                products = HttpContext.Session.GetObjectFromJson<List<Product>>("Basket");
                products.Add(product);
                HttpContext.Session.SetObjectAsJson("Basket", products);
            }

            return products;
        }

        [HttpDelete("delete")]
        public IEnumerable<Product> Delete(string productName)
        {
            List<Product> products = new List<Product>();

            if (HttpContext.Session.GetObjectFromJson<List<Product>>("Basket") != null)
            {
                products = HttpContext.Session.GetObjectFromJson<List<Product>>("Basket");
                products.RemoveAll(x => x.Name == productName);
                HttpContext.Session.SetObjectAsJson("Basket", products);
            }

            return products;
        }
    }
}
