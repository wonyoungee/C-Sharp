using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    객체지향
    class == 설계도 == 데이터 타입
    
    문제점)
    설계도 1장이 아니라 여러장이 사용됨...
    99칸 기와집 (거실..방..화장실 등 설계도 1장 이상 ...많이 필요)
    
    설계도를 나누는 기준 : "관계"
    여러장의 설계도가 있을때의 관계는...

      1. is ~ a : 상속 => 부모-자식간의 관계
        !!다중상속은 불가!! ex) 할아버지꺼, 아버지꺼도 따로 상속 불가. 
                                                 아버지가 할아버지꺼를 상속받고 있어야 둘다 상속 가능. (계층적 상속)
        사용자가 만드는 모든 클래스는 기본적으로 Object (root) 를 상속하고 있다.

      2. has ~ a : 포함
 */

namespace Ex01_OOP
{
    class GrandFather   // : Object 가 숨어있음.
    {
        public int Gmoney = 1000;
        private int Pmoney = 1000000;   // private : 누구에게도 상속되지 않음
        protected int Tmoney = 2000;    // protected : 상속관계에서만 존재하는 접근자
                                                                  //                       상속관계에서는 public 이지만, 객체(참조변수)가 바라볼때는 private
    }
    class Father : GrandFather  // : 은 java의 extends
    {
        public int Fmoney = 500;
        public void print()
        {
            Console.WriteLine("Tmoney : {0}", Tmoney);  // 상속관계라 가능.
        }
    }
    class Child : Father    // Father와 GrandFather 클래스 둘 다 상속됨.
    {
        public int Cmoney = 100;
        
        // (할아버지, 아버지, 나) 가 가진 돈 다 내돈....
    }

    sealed class aaa    // sealed : 봉인된 ... 상속 불가능한 클래스
    {

    }
    /*
    class bbb : aaa     // aaa는 sealed 클래스이므로 상속 불가.
    {
    }
    */

    /* 다형성
        1. Overloading (하나의 이름으로 여러가지 기능)
            : 함수의 parameter 개수와 타입을 다르게 하여 만드는 방법
            : 목적 -  개발자의 편리성
    */
    class Test
    {
        public void method()
        {
            Console.WriteLine("일반함수");
        }
        public void method(int i)
        {
            Console.WriteLine("i : {0}", i);
        }
        public void method(string i)
        {
            Console.WriteLine("i : {0}", i);
        }

        // 순서가 다름을 인정
        public void method(int i, string str)
        {

        }
        public void method(string str, int i)
        {

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Child child = new Child();
            // 상속받은 상위 자원에 접근 가능
            Console.WriteLine("Cmoney : {0}", child.Cmoney);
            Console.WriteLine("Fmoney : {0}", child.Fmoney);
            Console.WriteLine("Gmoney : {0}", child.Gmoney);
            
            // child.Tmoney     // Tmoney는 protected 접근자이기 때문에 참조변수에선 보이지 X
        
            Test test = new Test();
            test.method();
            test.method(100);
            test.method("문자열");
        }
    }
}
