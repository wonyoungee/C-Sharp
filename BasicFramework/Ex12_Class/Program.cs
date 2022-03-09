using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex12_Class
{
    class Program
    {
        static void Main(string[] args)
        {
            Car car = new Car();
            car.CarInfo();

            Car car2 = new Car("기아", "pink");
            Console.WriteLine(car2.Color); // color만 출력
        }
    }
}
