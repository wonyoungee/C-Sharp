using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex10_ToString_Override
{
    // 1. 사용자가 모든 클래스는 기본적으로 Object 상속받는다.
    // 2. Framework 제공하는 수많은 클래스도 Object 상속 받고 필요에 따라서 재정의 구현.

    class Person    // : Object (암묵적으로)
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public override string ToString()
        {
            // return base.ToString();
            return "person : " + Name + "-" + Age;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person() { Name = "Smith", Age = 12 };
            Console.WriteLine(person.ToString());   // 개발자가 목적에 따른 출력을 위해 재정의.
            Console.WriteLine(person);  // ToString 안붙여도 자동으로 ToString 붙여줌.
        }
    }
}
