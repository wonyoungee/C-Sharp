using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Circle_This
{
    /*
    class Circle : Shape
    { //상속
        private Point point; //포함 (다른 클래스 타입을 member field 로 가지는 것) ******
        private int r; //특수화

        //문제점 : 각각의 생성자에 member field 에 할당 작업을 반복적으로 하고 있다 .... 고민.....
        //답안지 : this 

        public Circle()
        {
            this.r = 10;
            this.point = new Point(10, 15);
        }

        public Circle(int r, Point point)
        {
            this.r = r;
            this.point = point;
        }

        public void circlePrint()
        {
            Console.WriteLine("반지름 : {0} , 좌표값 : {1},{2}", r, point.x, point.y);
        }

    }
    */
    class Shape
    { //공통속성 , 공통함수
        public string color = "gold";
        public virtual void draw()  // virtual
        {
            Console.WriteLine("도형을 그리다");
        }
    }
    class Point
    {
        public int x; //public 은 아니지만 출력해볼려고 잠시 .... 원칙 : private
        public int y;

        public Point() : this(1, 1) { }
        public Point(int x, int y)
        {  //원하는 점
            this.x = x;
            this.y = y;
        }
    }


    //코드 간소화
    class Circle : Shape
    { //상속
        private Point point; //포함 (다른 클래스 타입을 member field 로 가지는 것) ******
        private int r; //특수화

        // this() 사용 => 반복 할당 제거.

        public Circle() : this(10, new Point(10, 15)) { }

        public Circle(int r, Point point)
        {
            this.r = r;
            this.point = point;
        }

        public void circlePrint()
        {
            Console.WriteLine("반지름 : {0} , 좌표값 : {1},{2}", r, point.x, point.y);
        }

        public override void draw()
        {
            Console.WriteLine("원을 그리다.");
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Circle circle = new Circle();
            circle.draw();
            circle.circlePrint();
        }
    }
}