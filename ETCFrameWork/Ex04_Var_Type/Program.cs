using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04_Var_Type
{
    class Human
    {
        public string Name;
        public List<string> hobby = new List<string>();  // 취미가 여러개

    }

    class Program
    {
        static void Main(string[] args)
        {
            // List<Human> Friend
            var Friend = new List<Human>{
                //초기화 (property 형식)
                new Human{Name = "이", hobby = { "농구", "야구", "축구"} },
                new Human{Name = "김", hobby = { "농구", "야구"} },
                new Human{Name = "박", hobby = { "농구"} },
            };

            Console.WriteLine(Friend[0].Name+"/"+Friend[0].hobby);
            foreach (var item in Friend[0].hobby)
            {
                Console.WriteLine("hobby : " + item);
            }

            //////////////////////////////////////////////////////////////////////
            var x = 10;
            var y = 5;
            var str = "문자열";

            int[] arr = { 1, 2, 3, 4, 5 };
            foreach(var item in arr)
            {
                Console.WriteLine(item);
            }

            List<string> list = new List<string> { "가","나","다"};
            foreach(var item in list)
            {
                Console.WriteLine(item);
            }

            // Var타입 사용 >> 익명타입(이름없는 클래스)   >> 1회성  >> 재사용 불가
            // 유연성 확보 , 가독성은 떨어짐.
            var lee = new {name = "홍길동", age = 100 };   // 익명 클래스
            Console.WriteLine(lee.name);
            Console.WriteLine(lee.age);

        }
    }
}
