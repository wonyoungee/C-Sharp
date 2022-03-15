using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace HW_Library
{
    // 도서
    class Book
    {
        private int ISBN;
        private string bname;
        private string author;
        private string publisher;
        private int price;

        public Book(int ISBN, string bname, string author, string publisher, int price)
        {
            this.ISBN = ISBN;
            this.bname = bname;
            this.author = author;
            this.publisher = publisher;
            this.price = price;
        }
    }

    // 도서 관리자
    class Manager
    {
        List<Book> books = new List<Book>();

        public void AddBook(int ISBN, string bname, string, string, int)
        {
            List.Add(new Book(ISBN, ))
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
