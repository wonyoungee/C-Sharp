using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04_RefType
{   
    //원칙적인 방법은 별도의 Library 만들어서 사용하는 것이 원칙. (하나의 namespace에 class 여러개 하는 것 X)
    class Test
    {
        public int i; // member field (= instance variable). i변수는 클래스 내에서 유효.

        public void print()
        {
            int data = 100; //local variable (함수 안에 있는 변수)
            Console.WriteLine("data : {0}", data);
        }
    }


   class Program
    {
        static void Main(string[] args)
        {
            Test test = new Test();
            test.print();
            
            Test test2 = new Test();
            test2.print();

            Test test3 = new Test();
            test3.print();
        
            //test, test2, test3 은 참조 타입이다. (변수가 주소를 갖고 있음.)
        }
    }
}
