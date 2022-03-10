using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex16_User_Provider
{
    /*
     *  <객체간의 관계>
     *  상속 / 포함
     *  
     *  <포함>
     *  user : 사용자  (어떤 클래스 ...)
     *  provider : 제공자 (어떤 클래스 ...)
     *  
     *  class A {}
     *  class B {}
     *  관계 : A는 B를 사용합니다.
     *  
     *  1. 상속 : class A : B { }
     *  2. 포함 : A라는 클래스 안에서 B의 member field 사용  => class A {B b;}
     *      - 부분 vs 전체 : 기준 ) 생성과 소멸을 같이 할거냐 / 같이 안 할거냐
     *      
     *  class B { }
     *  class A {
     *      B b;    // 포함 (A는 B를 사용합니다.)
     *      A(){
     *          b = new B();
     *      }
     *  }
     *  >> 1. B는 독자적으로 생성된 것이 아니고  A객체가 생성될때 B가 같이 생성됨
     *  >> ex) A a = new A();   >> B도 같이 생성됨.
     *  >> "전체 포함" (운명공동체)
     *  >> ex) 차와 엔진 (차가 폐차되면 엔진도 폐기됨)
     *  
     *  --------------------------------------------------------------------------------------
     *  
     *  class B { }
     *  class A {
     *      B b;    // 포함 (A는 B를 사용합니다.)
     *      A( ) { }
     *      A(B b){
     *          this.b = b;
     *      }
     *      
     *      void method(B b){
     *          this.b = b;
     *      }
     *  }
     *  >> Main() {B b = new B();   A a = new A(b);}
     *  >> A가 만들어진다해서 반드시   B 가 만들어지는 것 X
     *  >> 서로 다른 운명
     *  >> "부분 포함" (lifeCycle이 다르다.)
     *  >> ex) 경찰과 총 (경찰이 없어져도 총은 존재)
     *  
     *  -------------------------------------------------------------------------------------
     *  
     *  <의존관계 (dependency)> : 함수를 기반으로 (함수 안에서 생성, 전달 ... )
     *  class B { }
     *  class A { 
     *      // member field로 B타입 변수를 가지지 않는 것.
     *      
     *      // 함수를 기반으로 함
     *      B print() {
     *          B b = new B();
     *          return b;
     *      }
     *  }
     *  
     *  >> 활용 사례
     *      interface Icall { void m(); }
     *      class C : Icall {
     *          // 반드시 재정의
     *          public void m() { }
     *      }
     *      class B : Icall {
     *          // 반드시 재정의
     *          public void m() { }
     *      }
     *      
     *  ** 현대적인 프로그램 방식은 : 유연한, 대충 하는 것
     *  
     *  class E {
     *      void method(Icall ic) { }   // Good Code => Icall을 구현한 C, D 객체 주소 모두 가능 (확장성 측면에서 유연함.)
     *      void method2(C c) { }   // C 객체의 주소만 가능
     *      void method3(D d) { }   // D 객체의 주소만 가능
     *  }
     */

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
