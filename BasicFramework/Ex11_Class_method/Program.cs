using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex11_Class_method
{
    // Method (함수) == 행위 == 기능
    class Test
    {
        private int i;  // instance variable

        // 행위 / 기능
        // 4가지 종류 (void parameter(O), void parameter(X), return parameter(O), return parameter(X)) 
        public void callMethod()
        {
            Console.WriteLine("일반함수");
        }
        public void callMethod2(int i)
        {
            if (i < 10)
            {
                Console.WriteLine("...");
            }
            else Console.WriteLine("<<<<<");
        }
        public string callMethod3()
        {
            return "string 타입 동일";
        }
        public string callMethod4(string str)
        {
            return str + "방가";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Test test = new Test(); // 메모리에 로드. 생성
            test.callMethod();  // 함수 호출
            test.callMethod2(5);
            Console.WriteLine(test.callMethod3());
            Console.WriteLine(test.callMethod4("친구야"));
        }
    }
}
