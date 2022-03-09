using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex07_Try_Catch_Finally
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // throw : 예외를 강제로 던지기.
                throw new IndexOutOfRangeException("인덱스 문제 발생");
            }
            catch (Exception e)
            {
                // throw를 통해 발생한 예외 확인
                Console.WriteLine("메시지 :" + e.Message);
                Console.WriteLine("소스:" + e.Source);
                Console.WriteLine("스택트레이스:" + e.StackTrace);
                Console.WriteLine("투스트링:" + e.ToString());
            }
            finally // 강제로 실행하는 블럭
            {
                Console.WriteLine("Power Off");
            }
        }
    }
}

