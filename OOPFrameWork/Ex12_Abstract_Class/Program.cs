using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex12_Abstract_Class
{
    /*
     *  1. 추상 클래스 (미완성 클래스)
     *      - 미완성 : 완성 + 미완성    >> 기준 : 함수를 구현했느냐 / 구현하지 않았느냐
     *      - 함수 구현 : {...}실행블럭을 가지고 있음.
     *      - 추상 함수 : 함수 구현 X , {...}실행 블럭 가지고 있지 X
     *      
     *  2. 추상 클래스 사용 목적
     *      - 상속 관계에서 method를 [강제로 구현]하는 것을 목적으로 함.
     *      
     *  3. 추상 클래스 특징
     *      - 스스로 객체 생성 X
     *      - 상속 관계에서만 존재, 구현
     *      - abstract method(추상함수)를 반드시 구현해야 함.
     *      - abstract method 는 자동 virtual (반드시 override 통해서 구현) - 재정의
     *      - abstract property { get; set; } 구현은 추상함수와 동일하게 적용. - 잘 안 만들긴 함.  
     */

    abstract class AbstractClass
    {
        public void print()
        {
            Console.WriteLine("완성된 코드 ... ");
        }
        public abstract void abMethod();         // 미완성 함수. {실행블럭}이 없음. 상속관계에서 강제적 구현이 목적.

    }

    class Dummy : AbstractClass
    {
        public override void abMethod()                 // 강제 구현 >> {실행블럭} 만들기. override
        {
            Console.WriteLine("추상 메서드 구현 ... ");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Dummy dummy = new Dummy();
            dummy.abMethod();
            dummy.print();
        }
    }
}
