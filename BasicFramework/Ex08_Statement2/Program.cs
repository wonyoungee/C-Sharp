using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex08_Statement2
{
    class Program
    {
        static void Main(string[] args)
        {
            /* 오류! case 문에 실행문이 있을땐 break 꼭 필요! (java는 가능한 코드)
            switch (100)
            {
                case 100: Console.WriteLine(data);
                case 90: Console.WriteLine(data);
                case 80: Console.WriteLine(data);
                default: Console.WriteLine("nothing");
            }
            */

            int month = 1;
            string res;
            switch (month)
            {
                case 1: //실행문 없으니 break 없어도 가능! break만날때까지 모두 실행.
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    res = "31";
                    Console.WriteLine($"{month}월은 {res}일까지 있습니다.");
                    break;
            }

         /*  간단한 학점 계산기
               학점 : A+ A- B+ B- ...... F
               데이터 점수 : 94점
                판단기준 : 90점 이상 -> A ,,, 70점 이상 -> C, 나머지 -> F 
                판단기준2 : 95점 이상 -> A+ 아니면 A- ,,, 70미만 -> F        */

            int data = 94;
            string grade;
            if (data >= 90)
            {
                grade = "A";
                grade += (data >= 95) ? "+" : "-";
            }
            else if (data >= 80)
            {
                grade = "B";
                if (data >= 85) grade += "+";
                else grade += "-";
            }
            else if (data >= 70)
            {
                grade = "C";
                if (data >= 75) grade = "C+";
                else grade = "C-";
            }
            else grade = "F";
            Console.WriteLine(grade);

            //함수().함수().함수() => chain : string 다루기
            //함수(함수(함수())) => 무식한 방법

            //for( ; ; ) // 무한루프

        }
    }
}
