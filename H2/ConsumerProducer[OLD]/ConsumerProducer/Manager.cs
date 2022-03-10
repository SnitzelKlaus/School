using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumerProducer
{
    public class Manager
    {
        //List of products, using jagged array
        public static Product[][] ProductList { get; set; } 

        #region Example of jagged array
        //  Example of jagged array:
        //
        //              Items in store:
        //  (Cola)      1,  1,  1,  1,  1
        //  (Cacao)     1,  1,  1,  1,  1,  1,  1
        //  (Sprite)    1,  1,  1
        //  (Beer)      1,  1,  1,  1,  1
        #endregion

        //Starts filling up jagged array with specified products and product count
        public void Start(string[] productName, int[] productionLimit)
        {

            //Makes specified products with a constructor and puts in jagged array
            #region Make Products Great Again!

            //Temporary jagged array, used to fill up product array
            Product[][] tmp = new Product[productName.Length][];

            //Adds product rows to array
            for (int i = 0; i < productName.Length; i++)
            {
                tmp[i] = new Product[productionLimit[i]];
            }

            //Transfers dataset to productList
            ProductList = tmp;
            #endregion

            //Makes factories and consumers for products
            for(int i = 0; i < productName.Length; i++)
            {
                _ = new Factory(i, i, productName[i], productionLimit[i]);
                _ = new Consumer((productName.Length + i + 1), i, productName[i]);
            }

            Console.ReadKey();
        }
    }
}


#region Remember?
////Writes out products
//for(int i = 0; i < ProductList.Length; i++)
//{
//    for (int j = 0; j < ProductList[i].Length; j++)
//    {
//        Console.WriteLine($"Name: {ProductList[i][j].Name}, ID: {ProductList[i][j].Id}");
//    }
//}



////Adds amount of item for product
//for (int j = 0; j < productLimit[i]; j++)
//{
//    tmp[i][j] = new Product(j, productName[i]);
//}


//Console.WriteLine($"Factory: {Id}, is producing {Manager.ProductList[ProductId][0].Name}");
//Console.WriteLine($"Consumer: {Id}, is consuming {Manager.ProductList[ProductId][0].Name}");
#endregion