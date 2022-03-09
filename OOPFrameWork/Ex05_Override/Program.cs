using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex05_Override
{
    /*
     * [상속관계] 에서 override : 상속관계에서 자식이 부모의 자원(member field, method)을 재정의 하는 것. (주로 method)
     * 상속관계에서 자식클래스가 부모클래스의 method의 "내용"만 바꾸는 것. (틀을 바꾸는 것 X)
     * 재정의 : 틀(부모함수의 이름/매개변수/타입)의 변화는 X , 내용({...실행블럭...})만 바뀌는 것.
     * new (상위자원 무시하기) , virtual (재정의 해주었으면 좋겠어 : 부모의 강한 의지) , override (재정의 방법)
     
     * Tip ) java는 
        @override 
        public void 재정의() {}
     */

    // new
    public class BaseC
    {
        public int x = 100;
        public void Invoke()
        {
            Console.WriteLine("부모함수");
        }
    }
    public class DerivedC : BaseC
    {
        new public int x = 111; // new를 쓰던 안쓰던 똑같음. 하지만 new 쓰는 것을 권고
        new public void Invoke()
        {
            Console.WriteLine("자식함수");
        }
    }

    // virtual
    class Father
    {
        public int Fmoney = 1000;
        public void Fprint() { Console.WriteLine("Fmoney : {0}", Fmoney); }
        public virtual void Vprint()    // virtual : 자식에게 Vpring 재정의 부탁 (안하면 말고 ...)
        {                                             // 이름은 그대로 Vprint인데 내용은 다르게 바꾸길 부탁.
            Console.WriteLine("부모함수 Vprint");
        }
    }
    // override
    class Child : Father
    {
        public override void Vprint()   // override : 부모가 virtual 부탁한거 override,,,
        {
            //base.Vprint();
            Console.WriteLine("부모의 뜻을 받들어 재정의 합니다.");
        }

        // *** 자식이 재정의한 부모 함수를 부르는 유일한 방법
        // base : 상속 관계에서의 this (java : super)
        public void FatherMethod() { base.Vprint(); }   // base.함수(); 상위 자원으로 가서 함수 호출
    }

    // 간단한 예제
    class Point2    // 한 점을 가진 클래스
    {
        public int x = 4;
        public int y = 5;

        public virtual string getPosition()
        {
            return this.x + ":" + this.y;
        }
    }
    class Point3D : Point2
    {
        public int z = 6;

        //string getPosition3D { return this.x+":"+this.y+":"+this.z; }
        public override string getPosition()    // override
        {
            return this.x + ":" + this.y + ":" + this.z;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            DerivedC derivedC = new DerivedC();
            derivedC.Invoke();
            Console.WriteLine(derivedC.x);  // 항상 가까운게 우선. 111 출력.

            Child child = new Child();  // 부모 먼저 생성됨.
            child.Fprint();
            child.Vprint();


            // *** 문제점 : 부모가 정의한 Vprint 함수는 호출할 수 없는가?
            // 상속관계에서 부모가 먼저 heap 에 올라가고 따라서 자식이 heap에 올라감.
            // child 타입은 heap에 있는 Father , Child 객체에 다 접근 가능. (상속관계)
            // if, 부모쪽에 있는 함수를 자식이 재정의하면 , child 입장에서는 부모 자원을 볼 수 X. 재정의한 자원만 접근 가능.

            // 다형성 *********************
            // 부모 타입은 자식 타입의 주소를 가질 수 있다.
            // 그러나 자식의 자원은 부모가 볼 수 없음.
            Father f = child;  // 자식이 가지고 있는 "주소"를 부모 타입의 f 라는 변수에 할당 (단, 상속관계)

            // ********* 부모 타입으로 접근 하더라도 재정의가 되어있다면 자식쪽 함수로 접근됨.
            f.Vprint(); // child가 재정의한 Vprint() 함수 호출됨.
            child.FatherMethod();   // 부모 함수를 부르는 유일한 방법 (재정의 됐을때)
        }
    }
}
