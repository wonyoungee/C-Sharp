using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_RSP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool auto = true;
            while (auto)
            {
                Console.WriteLine("**********************************************");
                Console.WriteLine("1. 가위    |   2. 바위   |   3. 보    |   4. 종료");
                Console.WriteLine("**********************************************");

                //user
                Console.Write("user의 선택(숫자) : ");
                int user = int.Parse(Console.ReadLine());
                //computer
                Random random = new Random();
                int com = random.Next(1, 4); //1,2,3

                switch (user)
                {
                    case 1:
                        Console.WriteLine($"computer의 선택 : {com}");
                        if (com == 2) { Console.WriteLine("졌습니다."); }
                        else if (com == 3) { Console.WriteLine("이겼습니다."); }
                        else { Console.WriteLine("비겼습니다."); }
                        break;
                    case 2:
                        Console.WriteLine($"computer의 선택 : {com}");
                        if (com == 3) { Console.WriteLine("졌습니다."); }
                        else if (com == 1) { Console.WriteLine("이겼습니다."); }
                        else { Console.WriteLine("비겼습니다."); }
                        break;
                    case 3:
                        Console.WriteLine($"computer의 선택 : {com}");
                        if (com == 1) { Console.WriteLine("졌습니다."); }
                        else if (com == 2) { Console.WriteLine("이겼습니다."); }
                        else { Console.WriteLine("비겼습니다."); }
                        break;
                    case 4:
                        Console.WriteLine("종료되었습니다.");
                        auto = false;
                        break;
                    default:
                        Console.WriteLine("올바른 메뉴를 선택하세요.");
                        break;
                }
                Console.WriteLine();

                /* 다른방법
                if(user == 4)
                {
                    Console.WriteLine("종료되었습니다.");
                    break;
                }
                else if (user == com)
                {
                    Console.WriteLine($"computer의 선택 : {com}");
                    Console.WriteLine("비겼습니다.");
                }
                else if((user+1)%3 == com%3)
                {
                    Console.WriteLine($"computer의 선택 : {com}");
                    Console.WriteLine("졌습니다.");
                }
                else if((user+2)%3 == com % 3)
                {
                    Console.WriteLine($"computer의 선택 : {com}");
                    Console.WriteLine("이겼습니다.");
                }
                else
                {
                    Console.WriteLine("올바른 메뉴를 선택하세요.");
                }
                Console.WriteLine();
                */
            }
        }
    }
}
