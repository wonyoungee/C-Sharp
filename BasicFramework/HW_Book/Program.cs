using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Book
{
    /*  1.책은 제목, 작가, 출판사, 출판연도를 가지고 있다.
          2.책은 제목이랑, 작가명을 가지고 있고, 출판사랑, 출판연도를 옵션으로 선택할 수 있다.
          3.책을 생성하고 책의 제목,작가출판사,출판연도를 확인 할 수 있다.
          4.책 생성 후에는 책 제목과 작가, 출판사, 출판연도 를 조회 뿐만 아니라 수정도 가능하다.
     */
    
    class Book
    {
        private string title;
        private string author;
        private string publisher;
        private int year;

        public Book(string publisher, int year)
        {
            this.title = "이것이 자바다";
            this.author = "신용권";
            this.publisher = publisher;
            this.year = year;
        }

        public void BookInfo()
        {
            Console.WriteLine($"책 이름 : {title}\t 작가 : {author}\t 출판사 : {publisher}\t 출판연도 : {year}");
        }

        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        public string Author
        {
            get { return author; }
            set { author = value; }
        }
        public string Publisher
        {
            get { return publisher; }
            set { publisher = value; }
        }
        public int Year
        {
            get { return year; }
            set { year = value; }
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            Book book = new Book("한빛미디어", 2015);
            book.BookInfo();
        }
    }
}
