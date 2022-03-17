using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex01_Delegate_Thread
{
    // Delegate 는 하나의 type
    // 함수를 대리해서 실행 (함수를 감추어서 캡슐화)
    // 조건 : 함수의 형식과 동일해야함.
    // 여러개의 동일한 형식의 함수를 대리할 수 있다.

    delegate void simple();
    delegate void simple2(int x);
    delegate void staticDel();
    delegate string simple3(string x);
    // 함수를 대리해서 호출하는 형식(타입)을 생성한 것.

    class Test
    {
        public void fMethod()
        {
            Console.WriteLine("일반메서드");
        }
        public void fMethod2(int i)
        {
            Console.WriteLine("값 : {0}", i);
        }
        public static void sMethodl()
        {
            Console.WriteLine("정적 메서드");
        }
        public string fMethod3(string s)
        {
            return s+"입니다";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Test test = new Test();
            // test.fMethod();
            simple s = new simple(test.fMethod);    // delegate 사용
            s();    // 대리해서 함수 호출

            simple2 s2 = new simple2(test.fMethod2);
            s2(10);

            simple3 s3 = new simple3(test.fMethod3);
            Console.WriteLine(s3("대리")); 
        }
    }
}
