using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex23_Array_Cinema
{
    class Program
    {
        static void Main(string[] args)
        {
            // 예약 , 예약확인 , 취소
            string[ , ] seat = new string[3 , 5];   // 3행 5열 좌석

            // 초기화
            for(int i = 0; i < seat.GetLength(0); i++)
            {
                for(int j = 0; j < seat.GetLength(1); j++)
                {
                    seat[i, j] = "__";
                }
            }

            //예매 정보 확인
            seat[2, 1] = "홍길동";
            seat[0, 0] = "김유신";

            for (int i = 0; i < seat.GetLength(0); i++)
            {
                for (int j = 0; j < seat.GetLength(1); j++)
                {
                    Console.Write((seat[i, j] == "__") ? "[빈좌석]" : "[예매된 좌석]");
                }
                Console.WriteLine();
            }

            // 예매하기
            int row, col;
            //[0, 0] 좌석 예매
            row = 0;
            col = 0;
            if(seat[row, col] == "__") { Console.WriteLine("예매 가능한 좌석입니다."); }
            else { Console.WriteLine("이미 예약된 좌석입니다."); }

            //예매 가능 하도록 좌석 초기화
            for (int i = 0; i < seat.GetLength(0); i++)
            {
                for (int j = 0; j < seat.GetLength(1); j++)
                {
                    seat[i, j] = "__";
                }
            }
            for (int i = 0; i < seat.GetLength(0); i++)
            {
                for (int j = 0; j < seat.GetLength(1); j++)
                {
                    Console.Write((seat[i, j] == "__") ? "[빈좌석]" : "[예매된 좌석]");
                }
                Console.WriteLine();
            }


            /*
            for (int i = 0; i < seat.GetLength(0); i++)
            {
                for (int j = 0; j < seat.GetLength(1); j++)
                {
                    Console.WriteLine(seat[i, j]);
                }
            }*/

        }
    }
}
