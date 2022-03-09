using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex07_Statement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 제어문과 연산자 같이 연습
            for (int i = 0; i < 10; i++)
            {
                Console.Write("i : {0}\n", i); // == Console.WriteLine("i : {0}", i);
            }

            for (int i = 2; i < 10; i++)
            {
                for (int j = 1; j < 10; j++)
                {
                    if (i == j) break;
                    Console.Write("*");
                }
                Console.WriteLine();
            }

            for (int i = 2; i < 10; i++)
            {
                for (int j = 1; j < 10; j++)
                {
                    if (i == j) continue; //skip 해라. (아래 문장 실행 X)
                    Console.Write($"{i} * {j} = {i * j}\t");
                }
                Console.WriteLine();
            }

            int result;
            Console.Write("숫자값을 입력하세요 : ");
            result = int.Parse(Console.ReadLine()); // 정수값으로 변환

            //switch 문
            switch (result)
            {
                case 1:
                    Console.WriteLine(result);
                    break;
                case 2:
                    Console.WriteLine(result);
                    break;
                case 3:
                    Console.WriteLine(result);
                    break;
                case 4:
                    Console.WriteLine(result);
                    break;
                case 5:
                    Console.WriteLine(result);
                    break;
                default:
                    Console.WriteLine("nothing");
                    break;
            }

            //while 문
            //1~100까지 합을 구하시오.
            int k = 1; //초기값
            int ksum = 0;
            while (k <= 100) //조건
            {
                ksum += k; //누적합 구하기
                k++; // 증감설정
            }
            Console.WriteLine($"누적합 : {ksum}");

            //1~100까지 홀수의 합 구하기.
            int a = 1;
            int asum = 0;
            while (a <= 100)
            {
                if (a % 2 != 0)
                {
                    asum += a;
                }
                a++;
            }
            Console.WriteLine($"홀수 누적합 : {asum}");


            /*  지정된 계정: admin 암호: 1234 가 있다.
                두 값을 console에서 받아서 두 값이 모두 일치하는 경우 "성공" 출력
                하나라도 값이 일치하지 않는 경우 "넌 누구냐 " 출력하세요(if사용)  */

            Console.Write("사용자 id : ");
            string id = Console.ReadLine();
            Console.Write("사용자 pw : ");
            string pw = Console.ReadLine();
            if(id=="admin" && pw=="1234")
            {
                Console.WriteLine("성공");
            }
            else
            {
                Console.WriteLine("넌 누구냐");
            }

            //!=
            if ('A' != 65) //False
            {
                Console.WriteLine("True");
            }
            else
            {
                Console.WriteLine("False");
            }

            //삼항연산자
            int p = 10;
            int q = -10;
            bool result2 = (p == q) ? true : false; //false
            Console.WriteLine(result2);

            //비트 연산
            Console.WriteLine(3 & 5); //AND 연산
            Console.WriteLine(3 | 5); //OR 연산
        }
    }
}
