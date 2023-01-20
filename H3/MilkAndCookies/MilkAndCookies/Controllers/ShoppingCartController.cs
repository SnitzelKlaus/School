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
        public IEnumerable<Product> GetProduct(string productName, double productPrice)
        {
            // List of products in the shopping cart
            List<Product> shoppingCart = new List<Product>();

            // Creates new product object
            Product product = new Product();
            product.Name = productName;
            product.Price = productPrice;

            // If session is null, add product to list and set session
            if (HttpContext.Session.GetObjectFromJson<List<Product>>("shoppingCart") == null)
            {
                shoppingCart.Add(product);
                HttpContext.Session.SetObjectAsJson("shoppingCart", shoppingCart); //Sets session with key "shoppingcart" and list of products
            }
            else // Else get list of products from session and add new product to session
            {
                shoppingCart = HttpContext.Session.GetObjectFromJson<List<Product>>("shoppingCart");
                
                shoppingCart.Add(product);
                HttpContext.Session.SetObjectAsJson("shoppingCart", shoppingCart);
            }

            //returns shopping cart
            return shoppingCart;
        }

        [HttpDelete("delete")]
        public IEnumerable<Product> Delete(string productName)
        {
            // List of products in the shopping cart
            List<Product> shoppingCart = new List<Product>();

            // If session is not null, delete requested product from the list and set session
            if (HttpContext.Session.GetObjectFromJson<List<Product>>("shoppingCart") != null)
            {                
                shoppingCart = HttpContext.Session.GetObjectFromJson<List<Product>>("shoppingCart");
                shoppingCart.RemoveAll(x => x.Name == productName);
                HttpContext.Session.SetObjectAsJson("shoppingCart", shoppingCart);
            }
            
            return shoppingCart;
        }
    }
}
