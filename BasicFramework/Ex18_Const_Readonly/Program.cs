using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex18_Const_Readonly
{
    class Test
    {
        // const 상수 생성시...
        // 1. 객체간 공유자원 -> 자동으로 static 이 붙어버림.
        // 2. 강제 초기화 필요.
        public const int MAXVALUE=10000;

        // readonly 상수 생성시 ...
        // 1. 반드시 초기화 할 필요는 없음.
        // 2. 생성자에서 딱 한번 값을 할당할 수 있음. => 변경불가 (상수니까)
        public readonly int readdata;
        public Test(int data)
        {
            readdata = data; // new 통한 생성시 객체마다 다른 상수값을 가짐
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //const
            Console.WriteLine(Test.MAXVALUE);   // const는 static 공유자원이므로 클래스 이름 통해 접근 가능.

            //readonly
            Test t = new Test(10);
            Console.WriteLine(t.readdata);
            Test t2 = new Test(20);
            Console.WriteLine(t2.readdata);
        }
    }
}
