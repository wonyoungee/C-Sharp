using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Money
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int UNIT = 10000;
            int NUM = 0;
            int SW = 0;

            Console.Write("금액을 입력하세요 : ");
            int MONEY = int.Parse(Console.ReadLine());

            while (true)
            {
                NUM = (MONEY / UNIT);
                Console.WriteLine($"단위 : {UNIT}\t매수 : {NUM}");
                if (UNIT > 1)
                {
                    MONEY = MONEY - UNIT * NUM;
                    if (SW == 0)
                    {
                        UNIT /= 2;
                        SW = 1;
                    }
                    else
                    {
                        UNIT /= 5;
                        SW = 0;
                    }
                }
                else break;
            }

        }
    }
}
