using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex17_Constructor_static
{
    class Test
    {
        public static int staticint = 0;    //이거보다
        public static int staticInt;    // 이렇게 한 다음 생성자로 초기화 하는 것이 좋음.

        static Test() //static 생성자 => static member field가 메모리에 올라간 후 바로 자동 호출됨.
        {
            staticInt = 0;
            // 제어 로직 가능
        }
        public static void print()
        {
            Console.WriteLine($"staticInt value : {staticInt}");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Test.print();
        }
    }
}
