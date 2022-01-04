using System;
using System.Collections.Generic;
using System.Text;

namespace TripToLibrary
{
    class Book
    {
        public Book(string title, string book)
        {
            Title = title;
            Auther = book;
        }

        public string Title { get; set; }
        public string Auther { get; set; }
    }
}
