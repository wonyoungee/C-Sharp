using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace HW_Regex
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("차량번호를 입력해주세요 : ");
            string str = Console.ReadLine();

           /*
            * 차량번호 규칙
            * 10~99 사이의 정수 + 한글1자리 + 정수4자리
            */
            Regex regex = new Regex(@"^[1-9]\d{1}[가-힣]\d{4}$");

            if (regex.IsMatch(str))
            {
                Console.WriteLine("조회가능한 차량번호 입니다.", str);
            }
            else
            {
                Console.WriteLine("조회 불가능한 형식입니다.");
            }
        }
    }
}