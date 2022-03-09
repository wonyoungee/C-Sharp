using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03_Inheritance_Composition
{
    /*
        실제 개발환경 -> 업무가 복잡하다 (도메인 지식)
        ex) 쇼핑몰 : 회원관리, 주문관리, 상품관리 ... 각각의 업무 독립적인 것 보다는 "관계"를 가지고 있다.
        
        여러개의 설계도는 [관계]를 가져야 한다.
        1. 상속 (is ~ a)은 [~이다] 명제가 성립되면 90% 상속 ... (원은 도형이다, 새는 조류다,,,)
        2. 포함 (has ~ a)은 [~을 가지고 있다] (자동차는 엔진을 가지고 있다. 경찰은 권총을 가지고 있다.)
        
        원 - 도형간의 관계
        원은 도형이다

        원 - 점과의 관계
        원은 점이다 (X)
        원은 점을 가지고 있다 (O)
        class 원 { 점 자원을 가지고 있다 }

        경찰 - 권총간의 관계
        class 경찰 { 권총 자원을 가지고 있다 }
    */

    /*
        Ex) 원, 삼각형, 사각형 설계도 제작
              원은 도형이다 / 삼각형은 도형이다 / 사각형은 도형이다 => 공통분모 : 도형
              도형 : 추상화, 일반화 : 그리다, 색상 >> 공통 자원
              원 : 구체화 (한 점), 특수화 (반지름) >> 본인만이 가지는 특징 >> 부품속성 (한점은 (x,y))
              
              class Shape { 색상, 그리다 } >> 부모
              class Point { 좌표값 } >> 부품 >> 포함

              class Circle : Shape { Point ... + 나머지는 특수하고 구체화 된 것 (반지름) 구현}
     */

    class Shape {   // 공통속성, 공통함수
        public string color = "gold";
        public void draw()
        {
            Console.WriteLine("도형을 그리다");
        }
     }
    class Point
    {
        public int x;   // 원칙은 private이나 쉽게 확인위해 public으로 설정한것
        public int y;
        public Point()  // 기본점  // Bad => 할당을 두번하고 있음. => this() 생성자 호출 할당을 통해 1개로 줄여야함.
        {
            x = 1;
            y = 1;
        }
        public Point(int x, int y)  // 원하는점
        {
            this.x = x;
            this.y = y;
        }
    }

    //문제 : 원을 만드세요.
    // 원의 반지름은 초기값 10을 가지고 있다.
    // 점의 좌표는 초기값 (10, 15) 가지고 있다,

    class Circle : Shape {
        private Point point;    // *** 포함 : 다른 클래스 타입을 member로 가지는 것 ***
        private int radius;     // 특수화 
        public Circle()
        {
            this.point = new Point(10, 15);
            this.radius = 10;
        }
        public Circle(int radius, Point point)
        {
            this.radius = radius;
            this.point = point;
        }
        public void circlePrint()
        {
            Console.WriteLine("반지름 : {0}, 좌표값 : ({1},{2})", radius, point.x, point.y);
        }
    }

    // 문제 2) 삼각형 클래스를 만드세요
    // 삼각형의 정의 : 3개의 점과 색상과 그리다는 기능을 가지고 있다.
    // Shape, Point 클래스 제공 받음
    // defualt 값으로 삼각형을 그릴 수 있고, 3개의 좌표값 모두를 입력받아서 삼각형을 그릴 수 있다.
    class Triangle : Shape
    {
        Point[] point;

        public Triangle()
        {
            this.point = new Point[3] {new Point(1,1), new Point(3,1), new Point(3,3)};
        }
        public Triangle(Point[] point)
        {
            this.point = point;
        }
        public void trianglePrint()
        {
            Console.WriteLine("좌표값 : ({0},{1}), ({2},{3}), ({4},{5})", point[0].x, point[0].y, point[1].x, point[1].y, point[2].x, point[2].y);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Circle c = new Circle();
            c.draw();
            c.circlePrint();

            // 내가 반지름과 좌표값 설정하기
            Circle c2 = new Circle(5, new Point(6,9));
            c2.draw();
            c2.circlePrint();

            Triangle t = new Triangle();
            t.draw();
            t.trianglePrint();

            Triangle t2 = new Triangle(new Point[] { new Point(10, 10), new Point(20,20), new Point(20,10)});
            t2.draw();
            t2.trianglePrint();
        }
    }
}
/*
    상속의 진정한 의미 : 재사용성 (부모)
    상속은 좋은 것일까 : (-) 초기 설계 비용이 많이 든다, 부모와 자식간의 관계 - 서로 영향을 너무 많이 받음.
    따라서 현대 >> 상속 사용 별로 X . 느슨한 프로그래밍 좋아함. >> 주로 interface 사용
 */