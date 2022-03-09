using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Array_Cinema_Quiz
{
    public class Cinema
    {
        private static string[,] seats;// 좌석 번호
        private static int[,] reservedNumber; 
        private static int count= 10000;
        public Cinema(int r, int c)
        {
            seats = new string[r, c];
            reservedNumber = new int[r, c];
            // 좌석 현황 초기화
            for(int i = 0; i < seats.GetLength(0); i++)
            {
                for (int j = 0; j < seats.GetLength(1); j++)
                {
                    seats[i, j] = $"{i}-{j}";
                }
            }
            // 예약 번호 초기화
            for (int i = 0; i < reservedNumber.GetLength(0); i++)
            {
                for (int j = 0; j < reservedNumber.GetLength(1); j++)
                {
                    reservedNumber[i, j] = 0;
                }
            }
        }

        public void ticketing()
        {
            //좌석 현황
            Console.WriteLine("**********좌석 현황**********");
            for (int i = 0; i < seats.GetLength(0); i++)
            {
                for (int j = 0; j < seats.GetLength(1); j++)
                {
                    Console.Write("["+seats[i, j]+"]");
                }
                Console.WriteLine();
            }
            // 좌석 선택하기
            Console.WriteLine("----------------------------------");
            Console.WriteLine("좌석을 선택해주세요.   예) 1-1");
            Console.WriteLine("이미 예매된 좌석은 \"예매\"라고 표시됩니다.");
            string useat = Console.ReadLine();
            for (int i = 0; i < seats.GetLength(0); i++)
            {
                for (int j = 0; j < seats.GetLength(1); j++)
                {
                    if(useat == seats[i, j])
                    {
                        Console.WriteLine("예매 가능합니다. 예매하시겠습니까?");
                        Console.WriteLine("네(1), 아니오(2), 초기화면(0)중 하나를 입력해주세요.");
                        int yn = int.Parse(Console.ReadLine());
                        switch (yn)
                        {
                            case 1:
                                Console.WriteLine("예매가 완료되었습니다.");
                                reservedNumber[i,j] = ++count;
                                Console.WriteLine($"예매한 좌석번호 : [{seats[i,j]}] / 예매번호 : {reservedNumber[i,j]}");
                                Console.WriteLine("감사합니다.");
                                seats[i, j] = "예매";
                                break;
                            case 2: break;
                            case 0: break;
                        }
                        i=seats.GetLength(0);
                        break;
                    }
                }
                if (i == seats.GetLength(0) - 1) { Console.WriteLine("예매 불가능합니다."); }
            }
        }

        public void check()
        {
            Console.WriteLine("예매번호를 입력해주세요.");
            int ruser = int.Parse(Console.ReadLine());
            Console.WriteLine();
            for(int i=0; i < reservedNumber.GetLength(0); i++)
            {
                for(int j=0; j < reservedNumber.GetLength(1); j++)
                {
                    if (ruser == reservedNumber[i, j])
                    {
                        Console.WriteLine($"고객님이 예매하신 좌석은 {i}-{j}입니다.");
                        i=reservedNumber.GetLength(0);
                        break;
                    }
                }
                if (i == reservedNumber.GetLength(0) - 1) { Console.WriteLine("예매하신 내역이 없습니다."); }
            }
        }

        public void cancel()
        {
            Console.WriteLine("예매번호를 입력해주세요.");
            int ruser = int.Parse(Console.ReadLine());
            Console.WriteLine();
            for (int i = 0; i < reservedNumber.GetLength(0); i++)
            {
                for (int j = 0; j < reservedNumber.GetLength(1); j++)
                {
                    if (ruser == reservedNumber[i, j])
                    {
                        Console.WriteLine($"고객님이 예매하신 좌석은 {i}-{j}입니다.");
                        Console.WriteLine("예매를 취소하시겠습니까?");
                        Console.WriteLine("네(1), 아니오(2) 중 하나를 입력해주세요.");
                        int yn = int.Parse(Console.ReadLine());
                        if(yn == 1)
                        {
                            seats[i, j] = $"{i}-{j}";
                            reservedNumber[i, j] = 0;
                            Console.WriteLine("예매가 취소되었습니다. 감사합니다.");
                        }
                        else
                        {
                            Console.WriteLine("예매가 취소되지 않았습니다. 갑사합니다.");
                        }

                        i = reservedNumber.GetLength(0);
                        break;
                    }
                }
            }
        }
    }
        class Program
    {
        static void Main(string[] args)
        {
            int choice = 0;
            bool t = true;
            Cinema cin =  new Cinema(4,5);
            while (t)
            {
                // 처음 화면
                Console.WriteLine();
                Console.WriteLine("***************************");
                Console.WriteLine("*****영화 예매 시스템*****");
                Console.WriteLine("***************************");
                Console.WriteLine("1. 예매하기\n");
                Console.WriteLine("2. 예매조회\n");
                Console.WriteLine("3. 예매취소\n");
                Console.WriteLine("4. 종료\n");

                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1: cin.ticketing();
                        break;
                    case 2: cin.check();
                        break;
                    case 3: cin.cancel();
                        break;
                    case 4: t = false;
                        break;
                }
            }
        }
    }
}
