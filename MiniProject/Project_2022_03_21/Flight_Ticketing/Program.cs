using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;




namespace Flight_Ticketing
{
    public enum Cities  // 출발지, 도착지 목록
    {
        Incheon,
        Jeju,
        Tokyo,
        NewYork,
        London
    }

    class Program
    {
        static void Main(string[] args)
        {
            AirLine air = new AirLine();
            air.AuthMenu();
        }
    }
}
