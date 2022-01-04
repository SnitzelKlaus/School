using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace TripToLibrary
{
    class Start
    {
        private Stack<Book> LoanedBooks = new Stack<Book>();
        private Stack<Book> AvailableBooks = new Stack<Book>();
        private List<Book> BookList = new List<Book>();

        public void Library()
        {
            UI ui = new UI();

            char userInput;
            int usrInput;
            int count;

            //Adding a list of books
            #region
            BookList.Add(new Book("Laughing at Wall Street", "Chris Camillo"));
            BookList.Add(new Book("But How Do It Know?","J Clark Scott"));
            BookList.Add(new Book("The Art of Electronics", "Paul Horowitz"));
            BookList.Add(new Book("Hacking\t\t", "Jon Erickson"));
            BookList.Add(new Book("The Book of F#\t", "Dave Fancher"));
            BookList.Add(new Book("Art of Assembly\t", "Randall Hyde"));
            BookList.Add(new Book("Game Hacking\t", "Nick Cano"));
            BookList.Add(new Book("Hacking VoIP\t", "Himanshu Dwivedi"));
            BookList.Add(new Book("Book of GNS3\t", "Jason C. Neumann"));
            BookList.Add(new Book("Linux Firewalls\t", "Micheal Rash"));
            BookList.Add(new Book("TCP/IP Guide\t", "Charles M. Kozierok"));
            BookList.Add(new Book("PoC||GTFO\t\t", "Manul Laproaig"));
            BookList.Add(new Book("PoC||GTFO, Volume 2", "Manul Laproaig"));
            BookList.Add(new Book("PoC||GTFO, Volume 3", "Manul Laproaig"));
            #endregion

            //Stocking up the avialablebooks with booklist
            foreach(Book book in BookList)
            {
                AvailableBooks.Push(new Book(book.Title, book.Auther));
            }

            while (true)
            {
                ui.Menu();

                    userInput = Console.ReadKey().KeyChar;

                switch (userInput)
                {
                    case '1':
                        ui.AddBook();

                        count = 0;
                        foreach (Book book in BookList)
                        {
                            count++;
                            Console.ForegroundColor = ConsoleColor.Red;
                            foreach (Book available in AvailableBooks)
                            {
                                if(available.Title == book.Title)
                                {
                                    Console.ForegroundColor = ConsoleColor.Blue;
                                }
                            }
                            Console.Write("[{0}]", count);
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.Write("\tBook: {0}", book.Title);
                            Console.WriteLine("\t\tAuther: {0}", book.Auther);
                        }

                        ui.AddBookInput();
                        usrInput = InputParse.ParseInt();
                        Console.Clear();

                        //Removes a book from 'AvailableBooks' and adds to 'LoanedBooks'
                        Stack<Book> tmpAddedBook = new Stack<Book>();
                        if (usrInput > 0 && usrInput <= BookList.Count)
                        {
                            count = 0;
                            foreach (Book book in BookList)
                            {
                                count++;
                                if (usrInput == count)
                                {
                                    foreach (Book available in AvailableBooks)
                                    {
                                        if (book.Title == available.Title)
                                        {
                                            LoanedBooks.Push(new Book(book.Title, book.Auther));
                                            ui.AddedBook();
                                        }
                                    }
                                }
                                else if (userInput != count)
                                {
                                    foreach (Book available in AvailableBooks)
                                    {
                                        if (book.Title == available.Title)
                                        {
                                            tmpAddedBook.Push(new Book(book.Title, book.Auther));
                                        }
                                    }
                                }
                            }
                            AvailableBooks.Clear();
                            foreach (Book book in tmpAddedBook)
                            {
                                AvailableBooks.Push(new Book(book.Title, book.Auther));
                            }
                            tmpAddedBook.Clear();
                        }
                        else
                        {
                            ui.AddBookException();
                        }
                        break;

                    case '2':
                        ui.RemoveBook();

                        count = 0;
                        foreach (Book book in LoanedBooks)
                        {
                            count++;
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write("[{0}]", count);
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.Write("\tBook: {0}", book.Title);
                            Console.WriteLine("\t\tAuther: {0}", book.Auther);
                        }

                        //Removes a book from user and adds to 'AvailableBooks'
                        ui.RemoveBookInput();
                        usrInput = InputParse.ParseInt();
                        Stack<Book> tmpBooks = new Stack<Book>();
                        count = 0;
                        if (usrInput > 0 && usrInput <= LoanedBooks.Count)
                        {
                            foreach(Book book in LoanedBooks)
                            {
                                count++;
                                if(usrInput != count)
                                {
                                    tmpBooks.Push(new Book(book.Title, book.Auther));
                                }
                                else
                                {
                                    AvailableBooks.Push(new Book(book.Title, book.Auther));
                                    ui.RemovedBook();
                                }
                            }
                            LoanedBooks.Clear();
                            foreach(Book book in tmpBooks)
                            {
                                LoanedBooks.Push(new Book(book.Title, book.Auther));
                            }
                            tmpBooks.Clear();
                        }
                        else
                        {
                            ui.RemoveBookException();
                        }

                        break;

                    case '3':
                        Console.Clear();
                        count = 0;
                        foreach (Book book in LoanedBooks)
                        {
                            count++;
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.Write("[{0}]", count);
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.Write("\tBook: {0}", book.Title);
                            Console.WriteLine("\t\tAuther: {0}", book.Auther);
                        }
                        break;

                    case '9':
                        ui.Checkout();
                        count = 0;
                        foreach (Book book in LoanedBooks)
                        {
                            LoanedBooks.Peek();
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.Write("[{0}]", count);
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.Write("\tBook: {0}", book.Title);
                            Console.Write("\t\tAuther: {0}\n", book.Auther);
                            userInput = Console.ReadKey().KeyChar;
                            if (userInput == '0')
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine(" = Stopped lending. Press a key to go back...");
                                break;
                            }
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("[LOANED]::Lending period: 3 month(s)\n");
                            count++;
                        }
                        for (int i = 0; i < count; i++)
                        {
                            LoanedBooks.Pop();
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
