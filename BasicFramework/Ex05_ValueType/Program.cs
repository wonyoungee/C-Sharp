using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex05_ValueType
{
    // #region : 접는 기능
    // struct가 class보다 성능면에서는 더 좋음.
    // 구조체는 "값 타입"
    #region + 값 타입 : 구조체 : 작은 타입을 모아서 의미있는 집합을 만듦.
    struct Book
    {
        public string name;
        public int price;

        public Book(string _name, int _price) //생성자 함수 : Book이 갖고 있는 member(name, prince)를 초기화.
        {
            name = _name;
            price = _price;
        }
    }

    struct Human //생성자 X인 구조체
    {
        public string ename;
        public int age;
    }
    #endregion

    #region + 열거형 : 하나의 값 타입 : 개발자를 위한 것
    enum mycolor {black, white, red, green, blue}; //열거 타입 (내부적으로 상수값 '0'부터 ++1 씩 자동 설정.) mycolor이 타입명.
    enum week {mon, tue = 101, sat, sun}; // 명시적으로 상수값 설정. 값을 설정한 이후부터 ++1 씩 자동 설정. mon=0, sat=102, sun=103
    #endregion

    class Car
    {
        public string name;
        public int price;

        public Car(string _name, int _price)
        {
            name = _name;
            price = _price;
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            //value type
            int i = 100;
            float f = 3.14f;

            //*** 구조체에서의 [new] 는 객체를 생성하는 연산자가 아님! 단지, 생성자를 통해 '초기화'를 하는 연산자일뿐임. 
            // 구조체는 stack 에 만들어짐!! (heap X)
            Book book = new Book("홍길동전", 10000);
            //구조체가 값 타입임을 증명하세요.
            Book book2 = book; //값 복사
            book2.name = "NEW";
            book2.price = 20000;
            //다른 값 출력
            Console.WriteLine("book : {0} {1}", book.name, book.price);
            Console.WriteLine("book2 : {0} {1}", book2.name, book2.price);

            //new라는 연산자는 객체를 생성하는 연산자 (new를 통해서 만들어진 객체는 heap 에 생성)
            Car car = new Car("GV80", 1000);
            Car car2 = car;
            car2.name = "NEW_CAR";
            car2.price = 6000;
            //똑같은 값 출력
            Console.WriteLine("car : {0} {1}", car.name, car.price);
            Console.WriteLine("car2 : {0} {1}", car2.name, car2.price);
            Console.WriteLine(car == car2);

            Human h;
            h.ename = "홍길동"; //초기화 하고 사용하는 것은 동일 -> 생성자로 초기화하는 것이 편리.
            h.age = 100;
            Console.WriteLine(h.ename);
            Console.WriteLine(h.age);

            //열거타입
            mycolor m;
            //m 열거 타입 변수는 열거형 중에 하나를 가질 수 있음.
            m = mycolor.black;
            Console.WriteLine(m); // "black" 출력. 내부적으로는 '0'을 가짐.
            Console.WriteLine((int)m); // '0'출력. Casting

            // 시스템이 제공하는 열거 타입 ex)
            Console.BackgroundColor = ConsoleColor.Magenta;

            week w;
            w = week.sat; // 개발자는 문자열 형태로 코드 해석 -> 편하게 작업 가능.
            Console.WriteLine($"week은 {w}입니다."); // 문자열 보간법

            // 문자열 보간법 사용
            int a = 10;
            int b = 20;
            Console.WriteLine($"{a}+{b}={a+b}입니다.");

            //상수
            const double PI = 3.14; // 상수의 이름은 대문자로 쓰자! (관용적표현)
            //PI = 3.192; // 오류! 상수는 변경 불가!

            //형변환
            int num = 1234;
            long lon = num; // [암시적 형변환] long > int
            long lon2 = (long)num; // 컴파일러가 내부적으로 수행하는 코드.
            long lon3 = 10000000000;

            //int num2 = lon3; //오류! 값으로 보지 말고 가지고 있는 타입으로 보셔야 합니다.
            int num2 = (int)lon3; // [명시적 형변환] long -> int (long>int) 바꾸는 것은 위험! [데이터 손실]이 발생할 수 있음.
            Console.WriteLine(num2); // 데이터 손실 -> 쓰레기 값 출력

            int x = 254;
            byte y = (byte)x; //byte 의 범위 : 0 ~ 255
            Console.WriteLine(y);

            x = 258;
            y= (byte)x; 
            Console.WriteLine(y); // byte 범위 초과! 원하는 값 안 나옴.

            //var type
            var name = "문자열"; //string
            var version = 8.0; //double
            Console.WriteLine(name.GetType());
            Console.WriteLine(version.GetType());
        }
    }
}