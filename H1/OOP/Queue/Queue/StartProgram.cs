using System;
using System.Threading;
using System.Collections.Generic;
using System.Text;

namespace Queue
{
    public class StartProgram
    {
        private Queue<Item> ItemQueue = new Queue<Item>();

        public void Menu()
        {
            UI ui = new UI();

            char userInput;
            string name;
            int qty;


            while (true)
            {

                ui.Menu();

                userInput = Console.ReadKey().KeyChar;

                switch (userInput)
                {
                    case '1':
                        //Adds an item to the queue
                        ui.AddItemsName();
                        name = Console.ReadLine();

                        ui.AddItemsQty();
                        qty = ParseInput.ParseInt();

                        ItemQueue.Enqueue(new Item(name, qty));

                        Console.Clear();
                        break;

                    case '2':
                        ui.DeleteItems();
                        foreach(Item item in ItemQueue)
                        {
                            Console.Write("Item: {0}", item.Name);
                            Console.WriteLine("\t\tQty: {0}", item.Qty);
                        }

                        ui.DeleteItemName();
                        name = Console.ReadLine();

                        //Creates a temporary queue to sort out the unwanted item
                        Queue<Item> tmpQueue = new Queue<Item>();
                        foreach(Item item in ItemQueue)
                        {                          
                            if(item.Name != name)
                            {
                                tmpQueue.Enqueue(new Item(item.Name, item.Qty));
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("\nSuccesfully removed '{0}' from the queue!", item.Name);
                            }
                        }

                        //Pastes the temporary queue to the item queue
                        ItemQueue.Clear();
                        foreach(Item item in tmpQueue)
                        {
                            ItemQueue.Enqueue(new Item(item.Name, item.Qty));
                        }
                        tmpQueue.Clear();

                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case '3':
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        foreach (Item item in ItemQueue)
                        {
                            Console.Write("Item: {0}", item.Name);
                            Console.WriteLine("\t\tQty: {0}", item.Qty);
                        }
                        break;

                    case '9':
                        //Dequeueing all items
                        ui.Dequeue();
                        int count = 0;
                        foreach(Item item in ItemQueue)
                        {
                            Console.Write("Item: {0}", item.Name);
                            Console.Write("\t\tQty: {0}", item.Qty);
                            Thread.Sleep(150);
                            Console.WriteLine("\t\t[DEQUEUED]");
                            count++;
                        }
                        for(int i = 0; i < count; i++)
                        {
                            ItemQueue.Dequeue();
                        }
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case '0':
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Black;
                        Environment.Exit(0);
                        break;

                    default:
                        ui.MenuException();
                        break;
                }

            }
        }
    }
}
