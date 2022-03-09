using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex06_Try_Catch
{
    /*
     *  예외처리 : 개발자가 코드를 통해서 문제를 발생시키는 것 => 개선의 여지가 있음.
     *  오류는 개선의 여지 X
     *  내가 만든 코드가 문제가 없음을 확신하지 못할때 사용. (모든 경우의 수를 테스트 할 수 없을때)
     *  코드를 수정하는 것이 X, 프로그램이 강제로 죽는 것 방지하기 위함.
     *  문제를 인지하고 추후에 코드 수정.
     *  try ~ catch ~ finally 
     */

    class Program
    {
        static void Main(string[] args)
        {
            string str = null;
            // Console.WriteLine(str.ToString());  // 예외가 발생   >> System.NullReferenceException >> 프로그램 강제 종료
            // Console.WriteLine("성공~ 종료^^");

            /*  처리되지 않은 예외: System.NullReferenceException: 개체 참조가 개체의 인스턴스로 설정되지 않았습니다.
                 위치: Ex06_Try_Catch.Program.Main(String[] args) 파일 C:\Users\r2com\Desktop\Ecount\Labs\Ex04_this\Ex06_Try_Catch\Program.cs:줄 24  */

            try
            {
                Console.WriteLine(str.ToString());  // 문제가 발생 -> catch로 감
                // 내부적으로 예외를 담을 수 있는 객체가 자동 생성 -> 그 객체에 문제를 담고 -> 그 주소를 Exception e 에 전달.

                // 1. 계층구조
                // public class NullReferenceException : SystemException
                // 상속   Object -> Exception -> SystemException -> NullReferenceException

                // 2. 부모타입의 변수는 자식타입의 주소를 받을 수 있다. (다형성)
                // 3. Exception e = new NullReferenceException("문제 발생에 코드 .. 문자열")
                // try 문제가 생기면 ... 자동으로 그 문제에 대한 객체를 생성 ... new NullReferenceException("문제 발생에 코드 ... 문자열")

                // 4. 그런데 catch(Exception e) 코드를 생성. 왜 catch(NullReferenceException e)로 하지 않았을까?
                // 5. 이유 : 무슨 예외가 발생할지 알 수 없기 때문에 모든 예외의 부모를 가지고 다 받아서 처리.
                // *** 상위(부모) 예외가 뒤에 와야함.
                // 6. try를 쓴다는 것은 비용을 쓰는 것
            }
            catch (NullReferenceException n)
            {
                Console.WriteLine(n.Message);

                // 1. log 파일에 정보 기록 >> 수정
                // 2. 메일 시스템 연동 -> 문제에 대한 것을 관리자 메일로 보냄 >> 수정
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("성공~ 종료^^");
        }
    }
}

