using System;
using System.Collections.Generic;
using System.Text;

namespace Automaten
{
    class UIGraphics
    {
        #region
        public void Menu()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("-----{");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Vending Machine");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("}-----\n");

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Select an item: \n");

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("[0] ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("$Checkout");

            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Write("[9] ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Show Basket\n");
        }

        public void Items(int id, string item, double price, int qty)
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("[{0}]  ", id);
            Console.ForegroundColor = ConsoleColor.Gray;

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("Item: ");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(item.ToString().PadRight(20));

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("Price: ");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(price.ToString().PadRight(15));

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("Qty: ");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(qty.ToString().PadRight(15));
        }

        public void UserInput()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\n[]: ");
            Console.ForegroundColor = ConsoleColor.Green;
        }

        public void ItemAdded(string name, double price, int qty)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("----------{");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Added");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("}----------\n");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("[Added]  ");
            Console.ForegroundColor = ConsoleColor.Gray;

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("Item: ");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(name.ToString().PadRight(20));

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("Price: ");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(price.ToString().PadRight(15));

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("Qty: ");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(qty.ToString().PadRight(15));

            Console.WriteLine();
        }

        public void InputNotValid()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("----------{");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Opsie");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("}----------\n");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("ERROR: ");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("The item entered, doesn't exist or is out of stock! (Enter an item that exists)\n");
        }

        public void Basket()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("--------{");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("My Basket");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("}--------\n");
        }

        public void BasketItems(string name, double price, int qty)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("[Added]  ");
            Console.ForegroundColor = ConsoleColor.Gray;

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("Item: ");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(name.ToString().PadRight(20));

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("Price: ");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(price.ToString().PadRight(15));

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("Qty: ");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(qty.ToString().PadRight(15));
        }

        public void TotalPrice(double price)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("\n[Total Price]: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(price);

            Console.WriteLine();
        }

        public void Checkout()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("--------{");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("$Checkout");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("}--------\n");

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Insert only: ");

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("\n[1]: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("$1");

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("[2]: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("$10");

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("[3]: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("$20");

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("[4]: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("$50");

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("[5]: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("$100");
        }

        public void Balance(double balance, double price)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("\n[Balance]: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(balance);

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("[Missing]: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(price - balance);
        }

        public void BillRejected()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("\nERROR: ");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("$ rejected! (Enter $ that exists)\n");
        }

        public void PurchaseCompleted(double balance)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nPurschase completed!");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("Returning money: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"${balance}");
        }

        public void Dispenser(string name)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("[Dispensing]: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"{name}...");
        }
        #endregion
    }
}
