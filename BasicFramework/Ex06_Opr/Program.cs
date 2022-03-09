using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex06_Opr
{
    class Program
    {
        static void Main(string[] args)
        {
            // 연습 Main 함수 안에서 작업
            Console.WriteLine(100+100); // 숫자 : 산술
            Console.WriteLine("100" + "100"); //문자열 : 결합
            Console.WriteLine("100" + 100); // 결합

            int i = 10; //지역변수 항상 초기화
            int j;
            j = i++; // 후치증가 (넣고 증가)
            Console.WriteLine("i : {0}, j : {1}", i, j); // i : 11, j : 10
            j = ++i; // 전치증가 (증가 후 넣음)
            Console.WriteLine("i : {0}, j : {1}", i, j); // i : 12, j : 12

            
        }
    }
}
