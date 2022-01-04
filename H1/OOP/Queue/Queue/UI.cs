using System;
using System.Collections.Generic;
using System.Text;

namespace Queue
{
    public class UI
    {
        //This region consist of graphics for the user interface.
        #region
        public void Menu()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("================================");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("\n   H1 Queue Operations Menu\n");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("================================\n");

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Choose the following options:\n");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("[1]");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(" Add items");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("[2]");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(" Delete items");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("[3]");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(" Show items");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("\n[9]");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(" Dequeue items");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("[0]");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(" Exit");

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\n[]: ");
            Console.ForegroundColor = ConsoleColor.Blue;

        }

        public void MenuException()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("================================");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("ERROR 404: ");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("The option entered, doesn't exist!");
            Console.WriteLine("Please select an option, using the menu below.");
        }

        public void AddItemsName()
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("=================");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("\n   Add Items   \n");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("=================\n");

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Write name and qty of the item.");

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\n[Name]: ");
            Console.ForegroundColor = ConsoleColor.Blue;
        }

        public void AddItemsQty()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\n[Qty]: ");
            Console.ForegroundColor = ConsoleColor.Blue;
        }

        public void DeleteItems()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("====================");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("\n   Delete Items   \n");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("====================\n");

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Write the name of the following items to delete.");
        }

        public void DeleteItemName()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\n[Name]: ");
            Console.ForegroundColor = ConsoleColor.Blue;
        }

        public void ShowItems()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("==================");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("\n   Show Items   \n");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("==================\n");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public void Dequeue()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("========================");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("\n   Dequeueing Items   \n");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("========================\n");
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        #endregion
    }
}
