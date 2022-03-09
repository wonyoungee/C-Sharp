using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04_This
{
 /*
 *  this : 객체 자신을 가리키는  this (앞으로 생성될 객체의 주소를 가진다는 가정하에)
 *  사용 : 함수 안에서 member field와 parameter를 구분하기 위함.
 *  관용적으로 함수의 parameter 이름과 member field 이름을 동일하게 씀. => 가독성을 높임.
 *  생성자를 호출하는 this
 */

    class ThisSelf
    {
        private string name;
        public int age;

        /* 이 코드의 문제점 :  할당하는 코드가 너무 많음!!
          public ThisSelf() {
              this.name = "홍길동";
              this.age = 0;
          }
          public ThisSelf(string name) { //name 사용하면 member field name에 할당될 것임을 유추.
              this.name = name;   // this.name == 해당 객체의 member field인 name
              this.age = 0;
          }
          public ThisSelf(string name, int age) { this.name = name; this.age = age; }
        */

        /* Good Code*/
        public ThisSelf() : this("홍길동") { Console.WriteLine("매개변수가 없어요^^"); }   // this("홍길동") => 밑의 생성자(string name) 호출.
        public ThisSelf(string name) : this(name, 0) { Console.WriteLine("매개변수가 하나 있어요^^"); }   // this(name, 0) => 밑의 생성자 호출.
        public ThisSelf(string name, int age)
        {     // 따라서 이 생성자가 먼저 실행됨.
            // member field 할당을 한번만 (반복적 코드 줄임)
            this.name = name;
            this.age = age;
            Console.WriteLine("매개 변수가 두 개 : {0} - {1}", this.name, this.age);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // 원칙적으로 생성자 함수는 객체 생성시 1개만 호출
            // 예외적으로 내부적으로  this() 구현한다면 

            ThisSelf t = new ThisSelf();
            Console.WriteLine();
            ThisSelf t2 = new ThisSelf("김유신");
            Console.WriteLine();
            ThisSelf ThisSelf = new ThisSelf("홍길동", 100);
        }
    }
}
