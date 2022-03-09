using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumerProducer
{
    public class Manager
    {
        public static Product[][] ProductList { get; set; } //Jagged array list of products

        //  Example of jagged array:
        //
        //              Items in store:
        //  (Cola)      1,  1,  1,  1,  1
        //  (Cacao)     1,  1,  1,  1,  1,  1,  1
        //  (Sprite)    1,  1,  1
        //  (Beer)      1,  1,  1,  1,  1

        //Starts filling up jagged array with specified products and product count
        public void Start(string[] productName, int[] productLimit)
        {

            //Makes specified products with a constructor and puts in jagged array
            #region Make Products Great Again!

            //Temporary jagged array, used to fill up product array
            Product[][] tmp = new Product[productName.Length][];

            //Loops through products
            for (int i = 0; i < productName.Length; i++)
            {
                tmp[i] = new Product[productLimit[i]];

                ////Adds amount of item for product
                //for (int j = 0; j < productLimit[i]; j++)
                //{
                //    tmp[i][j] = new Product(j, productName[i]);
                //}
            }

            //Transfers dataset to productList
            ProductList = tmp;
            #endregion

            //Makes factories and consumers for products
            for(int i = 0; i < productName.Length; i++)
            {
                _ = new Factory(i, i, productLimit[i]);
                _ = new Consumer(i, i);
            }

            ////Writes out products
            //for(int i = 0; i < ProductList.Length; i++)
            //{
            //    for (int j = 0; j < ProductList[i].Length; j++)
            //    {
            //        Console.WriteLine($"Name: {ProductList[i][j].Name}, ID: {ProductList[i][j].Id}");
            //    }
            //}

            Console.ReadKey();
        }
    }
}
