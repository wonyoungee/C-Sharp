using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex19_CallByVal_CallByRef
{
    class Car
    {
        public int speed;
        public void run(int data)
        {
            speed += data;
            data = 100; // 영향 X
        }
    }

    // ref : 값을 싸고있는 주소를 보내는 것.
    // ref는 잘 사용하지 않음. 알고만 있자.
    class Car2
    {
        public int speed;
        public void run(ref int data)   // xx주소 들어옴
        {
            speed += data;
            data = 50;  // xx주소에 값을 50으로 변경
        }
    }
    class Car3
    {
        public int speed;
        public void run(out int data)   // xx주소 들어옴
        {
            data = 100; // out은 함수안에서 초기화한 후 사용.
            speed += data;
            data = 50;  // xx주소에 값을 50으로 변경
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Car car = new Car();
            int data2 = 20;
            car.run(data2); // data2 변수가 가지는 값을 전달
            Console.WriteLine(car.speed);
            Console.WriteLine(data2);


            Car2 car2 = new Car2();
            int data3 = 20;
            car2.run(ref data3);    // data3(xx)의 주소 보냄
            Console.WriteLine(car2.speed);
            Console.WriteLine(data3);   //변경된 값 출력

            Car3 car3 = new Car3();
            int data4;  // 초기화 x
            car3.run(out data4);  
            Console.WriteLine(car3.speed);
            Console.WriteLine(data4);   //변경된 값 출력
        }
    }
}
