using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex26_String_Function_Quiz
{
    class Program
    {
        static void juminDisplay(string ssn)
        {
            if (juminCheck(ssn))
            {
                if (juminFirstNumber(ssn))
                {
                    switch (ssn[7])
                    {
                        case '1':
                        case '3':
                            Console.WriteLine("남자");
                            break;
                        case '2':
                        case '4':
                            Console.WriteLine("여자");
                            break;
                    }
                }
                else { Console.WriteLine("뒷번호 첫자리가 올바르지 않습니다."); }
            }
            else { Console.WriteLine("주민번호 자리수가 올바르지 않습니다."); }
        }
        
        static bool juminFirstNumber(string str)
        {
           return (str[7] >='1' && str[7] <='4') ? (true) : (false);
        }

        static bool juminCheck(string str)
        {
            return str.Length == 14 ? true : false;
        }
        static void Main(string[] args)
        {
            Console.Write("주민번호를 입력하시오 : ");
            string str = Console.ReadLine();
            juminDisplay(str);
        }
    }
}
