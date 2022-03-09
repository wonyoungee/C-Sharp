//using == import(java)
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex01_Basic // namespace == package(java). 논리적인 묶음의 단위 (클래스간 충돌 방지)
{
    //클래스는 설계도. 클래스는 타입이다.
    //객체지향프로그래밍 : 재사용성
    //클래스 종류 2가지 : Main 가진 클래스(직접 실행 가능한 클래스 : exe) / Main 없는 클래스(다른 클래스 도와줌 : dll)
    /* 원칙적 방법 : 모든 클래스는  new 연산자를 통해 메모리에 로드. 그래야 사용 가능.
       Program p = new Program(); */

    class Car //dll
    {

    }

    class Test
    {
        public int data;
    }
    
    class Program //exe
    {
        static void Main(string[] args) //함수(method) > 기능 > static (독자적으로 메모리 로드) > 이름이  Main() > stack 메모리에서 실행 가능.
        {
            //Console.WriteLine("Hello world");

            //데이터 타입과 변수
            char c; //선언(2byte). 한글 한 자 : 2byte / 영문자, 특수문자, 공백 : 1byte >> 약속 : '한 문자'를 그냥 2byte로 통일하자. (유니코드 체제)
            c = 'A';

            char d;
            d = '가';

            Console.WriteLine("c:{0}, d:{1}", c, d); //Format 메소드로 출력

            // 지역변수는 반드시 [초기화]를 통해 사용해야함.
            short s;
            s = 1000;
            Console.WriteLine(s);

            int i = 10000000;
            Console.WriteLine(i);

            //float f = 1.12; // 오류! 1.12 실수 리터럴의 기본형을 무조건 double형으로 봄.
            float f = 1.12f; //float은 접미사 f(F)를 붙여줘야함.
            Console.WriteLine(f);

            double dd = 1.123456789;
            Console.WriteLine(dd);

            bool b = true; // 논리구조 파악. (제어구조에서 논리 판단)
            //증명하기
            //aa가 value type임을 증명해보세요.
            int aa = 100; 
            int bb = aa; //값 할당
            bb = 200;
            Console.WriteLine(aa.GetHashCode()); //aa의 값인 100 출력 => value type
            Console.WriteLine(bb.GetHashCode());
            Console.WriteLine(aa == bb); //False

            //참조 타입 증명
            Test t = new Test();
            Console.WriteLine(t.GetHashCode()); //t의 주소값 출력 => reference type
            t.data = 100;

            Test t2 = t; //주소값 할당
            t2.data = 1111;
            Console.WriteLine("t객체의 data변수값은 : {0}", t.data);
            Console.WriteLine(t == t2); //True
            Console.WriteLine("{0}-{1}", t.GetHashCode(), t2.GetHashCode());
        }
    }
}
