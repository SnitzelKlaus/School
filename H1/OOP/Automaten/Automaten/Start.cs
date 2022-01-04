using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Automaten
{
    class Start
    {
        //List of items you can buy
        private List<Item> Items = new List<Item>();
        int ItemID;

        //Basket
        private Stack<Item> Basket = new Stack<Item>();
        double Price;

        //User input values
        public int UserInput;
        public char UsrInput;

        //User balance
        private double Balance;

        public void Menu()
        {
            //Using UIGraphics class for a graphical interface
            UIGraphics uiGraphics = new UIGraphics();
            //Using ParseInput class to safely input data
            ParseInput parseInput = new ParseInput();

            //Items
            #region
            //                  Item Name       Price       Qty
            Items.Add(new Item( "Gummibears",   3.99,       20));
            Items.Add(new Item( "Chocolate",    4.99,       20));
            Items.Add(new Item( "Jelly Beans",  4.99,       20));
            Items.Add(new Item( "Skittles",     9.99,       25));
            Items.Add(new Item( "Coke",         4.99,       20));
            Items.Add(new Item( "Sprite",       4.99,       20));
            Items.Add(new Item( "Fanta",        4.99,       20));
            Items.Add(new Item( "Cocio",        9.99,       10));
            #endregion

            //Infinite loop, always returns to menu
            while (true)
            {
                //Displaying menu
                uiGraphics.Menu();

                //Displaying items
                ItemID = 0;
                foreach (Item item in Items)
                {
                    ItemID++;
                    uiGraphics.Items(ItemID, item.Name, item.Price, item.Qty);
                }

                //User input
                uiGraphics.UserInput();
                UserInput = parseInput.ParseInt();

                if(UserInput >= 1 && UserInput <= 8)
                {
                    //Checks if item is in stock
                    if (Items[UserInput - 1].Qty >= 1)
                    {
                        //Removing 1 qty of item
                        Items[UserInput - 1].Qty--;

                        //Adding item to basket
                        Basket.Push(new Item(Items[UserInput - 1].Name, Items[UserInput - 1].Price, 1));

                        //Outputs 'item has been added'
                        uiGraphics.ItemAdded(Items[UserInput - 1].Name, Items[UserInput - 1].Price, 1);
                    }
                    else
                    {
                        uiGraphics.InputNotValid();
                    }
                }
                else if (UserInput == 0)
                {
                    UserCheckout(); //Goes to checkout
                }
                else if (UserInput == 9)
                {
                    UserBasket(); //Shows content of basket
                }
                else
                {
                    //Displays error message
                    uiGraphics.InputNotValid();
                }
            }
        }
        
        public void UserBasket()
        {
            //Using UIGraphics class for a graphical interface
            UIGraphics uiGraphics = new UIGraphics();

            uiGraphics.Basket();
            Price = 0;
            foreach (Item item in Basket)
            {
                Price = Price + item.Price;
                uiGraphics.BasketItems(item.Name, item.Price, item.Qty);
            }

            uiGraphics.TotalPrice(Math.Round(Price, 2));
        }

        public void UserCheckout()
        {
            //Using UIGraphics class for a graphical interface
            UIGraphics uiGraphics = new UIGraphics();

            UserBasket();

            uiGraphics.Checkout();

            while (Balance < Price)
            {
                //User input
                uiGraphics.UserInput();
                UsrInput = Console.ReadKey().KeyChar;

                switch (UsrInput)
                {
                    case '1': //$1
                        Balance = Balance + 1;
                        uiGraphics.Balance(Balance, Math.Round(Price, 2));
                        break;

                    case '2': //$10
                        Balance = Balance + 10;
                        uiGraphics.Balance(Balance, Math.Round(Price, 2));
                        break;

                    case '3': //$20
                        Balance = Balance + 20;
                        uiGraphics.Balance(Balance, Math.Round(Price, 2));
                        break;

                    case '4': //$50
                        Balance = Balance + 50;
                        uiGraphics.Balance(Balance, Math.Round(Price, 2));
                        break;

                    case '5': //$100
                        Balance = Balance + 100;
                        uiGraphics.Balance(Balance, Math.Round(Price, 2));
                        break;

                    default:
                        uiGraphics.BillRejected();
                        break;
                }
            }

            //Outputs money getting returned
            Balance = Balance - Price;
            uiGraphics.PurchaseCompleted(Math.Round(Balance));


            //Dispenses items
            int count = 0;
            Console.WriteLine();
            foreach (Item item in Basket)
            {
                count++;
                uiGraphics.Dispenser(item.Name);
                Thread.Sleep(50);
                Console.WriteLine("Item received!");
            }
            Console.WriteLine();

            //Removes items from basket
            for(int i = 0; i < count; i++)
            {
                Basket.Pop();
            }

            //Resetting Balance and Price
            Balance = 0;
            Price = 0;

            Console.ReadKey();
            Console.Clear();
        }
    }
}
