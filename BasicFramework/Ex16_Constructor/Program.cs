using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex16_Constructor
{
    class Test
    {
        /*
             생성자 
         */
        private int data;
        public Test(int i)
        {
            data = i;
        } //overloading 생성자
        //overloading 생성자 하나라도 존재하면 default 생성자는 구현을 통해서만 가능.
    }

    class Book
    {
        private string bname;
        private int price;

        // 할당하는 코드가 많으면 안좋은 코드.
        public Book(string bname)
        {
            this.bname = bname;
            this.price = 10000;
        }

        public Book(int price)
        {

        }

        public Book(string bname, int price)
        {
            this.bname = bname;
            this.price = price;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
