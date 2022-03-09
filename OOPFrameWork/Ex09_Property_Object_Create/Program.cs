using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex09_Property_Object_Create
{
    class BirthdayInfo
    {
        // 생성자 존재 X
        // Property 를 통해서 객체 생성시 초기화 작업 가능
        /*
         * 클래스이름 인스턴스 = new 클래스이름(){
                프로퍼티1 = 값, 프로퍼티2 = 값, 프로퍼티3 = 값
           };
         */
        public string Name
        {
            get;
            set;
        }
        public DateTime Birthday
        {
            get;
            set;
        }
        public int Age
        {
            get
            {
                return new DateTime(DateTime.Now.Subtract(Birthday).Ticks).Year;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // *********** 반드시 기억 ***********
            BirthdayInfo birthdayInfo = new BirthdayInfo()
            {
                Name = "홍길동",
                Birthday = new DateTime(2022, 1, 1)
            };

            Console.WriteLine("Name : {0}", birthdayInfo.Name);
            Console.WriteLine("Birthday : {0}", birthdayInfo.Birthday.ToString());
            Console.WriteLine("Age : {0}", birthdayInfo.Age);
        }
    }
}