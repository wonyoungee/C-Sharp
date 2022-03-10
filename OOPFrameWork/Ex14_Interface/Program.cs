using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex14_Interface
{
    /*
     * <인터페이스> : 표준 , 약속 , 규칙 , 규약을 만드는 행위
     *   - 객체간 연결 고리 (객체간 소통)   >> 다형성
     *   - 100% 구현해야함.
     *   - SW설계 최상위 단계
     *   - Ex) 게임 >> run() : 달린다 , move(int x, int y) : 움직인다(좌표필요) >> 표준을 만듦.
     *      
     *  초급개발자
     *   - 인터페이스를 [다형성] 입장에서 접근, 사용.   (Inteface - 부모타입)
     *   - 서로 연관성이 없는 클래스를 하나로 묶어주는 기능. (같은 부모를 가짐)
     *   - ***** C#이 제공하는 수많은 API (ex. Collection)    >> 인터페이스 활용 >> 사용방법 >> 다형성 ******
     *   - ~ able ... I~ 수리할 수 있는 , 날 수 있는 의미 접근.
     *   
     *   문법)
     *   1. 인터페이스는 모든 멤버가 구현부를 가지지 않는다.
     *   2. 인터페이스는 상속을 통한 강제 구현을 목적을 한다.
     *   3. 모든 접근자는 public  -> 굳이 코드에서 사용할 필요가 X    -> 대부분 생략
     *   4. 멤버 필드를 가지지 않는다.
     *   5. 유일하게 다중상속 지원. (여러개의 약속을 강제 구현 ... 인터페이스는 작은 단위로 설계)
     */

    interface Ia    //Irunable Icloneabel
    {   // default public
        void m();   // 자동 public vitrual
        int Count   // 자동 public virtual. 강제로 property get 구현하도록
        {
            get;
        }
    }
    interface Ib
    {
        void m2();
    }
    abstract class Abclass
    {
        public void run() { }   // 완성된 자원
        public abstract void move();    // 미완성 자원
    }

    class Child : Abclass, Ia, Ib
    {
        public override void move()     // 추상메서드 구현
        {
            Console.WriteLine("Abclass.move()");
        }
        public int Count { get { return 100; } }    // Ia의 추상 property 구현
        public void m() {   // Interface는 어차피 구현해야 하므로 override 쓰지 않아도 됨.
            Console.WriteLine("Ia.m()");
        }
        public void m2() {
            Console.WriteLine("Ia.m2()");
        }
    }

    #region
    // 인터페이스
    // - ~ able ... I~ 수리할 수 있는 , 날 수 있는 의미 접근
    // - 객체간 연결 고리 (객체간 소통)   >> 다형성

    // 인터페이스 - 부모타입
    interface Irepairable {

    }   // ~할 수 있는 (하나의 의미로)


    class Unit
    {
        public int hitpoint;    // 기본 에너지
        public readonly int MAXHP;  // 최대 에너지
        public Unit(int hp)
        {
            this.MAXHP = hp;
        }
    }

    // 지상 유닛
    class GroundUnit : Unit
    {
        public GroundUnit(int hp) : base(hp) { }    // unit 생성자 호출 (부모)
    }

    // 공중 유닛
    class AirUnit : Unit
    {
        public AirUnit(int hp) : base(hp) { }    // unit 생성자 호출 (부모)
    }

    // 건물
    class CommandCenter : Irepairable
    {

    }

    class Tank : GroundUnit, Irepairable
    {
        public Tank() : base(50) { }    // Tank 생성시 최대 hp = 50
        public override string ToString()
        {
            return "Tank";
        }
    }

    class Marine : AirUnit
    {
        public Marine() : base(50) { }  // Marine 생성시 최대 hp = 50
        public override string ToString()
        {
            return "Marine";
        }
    }

    class Scv : GroundUnit, Irepairable
    {
        public Scv() : base(50) { } // Scv 생성시 최대 hp = 50
        public override string ToString()
        {
            return "Scv";
        }

        // 수리의 기능을 가짐.
        // Scv만의 구체화되고 특수화된 기능 => "repair"
        // repair의 대상 : Tank , Scv , CommandCenter

        // 문제점 : 오버로딩을 사용하게 되면 => Unit 개수가 증가하면 repair함수의 개수도 같이 증가
        // 해결 : 한 개의 repair함수로 모두 수리.
        // ex) public void repair(Unit unit) {...} 으로 하게 되면 CommandCenter는 수리 불가능, Marine 가능 => 문제 발생!
        // Marine, Scv, Tank, CommandCenter     >> 서로 연관성이 없음.  -> 서로 연관성이 없는 자원들을 "묶어주기"   >> Interface 사용하기!
        // 수리 가능한 , 수리할 수 있는 : ~ able   >> interface    >> interface Irepairable { }
        //  class Tank : GroundUnit, Irepairable // class Scv : GroundUnit, Irepairable //    class CommandCenter : Irepairable

        public void repair(Irepairable repairunit)   // Irepairable 부모타입 : CommandCenter, Scv, Tank
        {
            // 고민 : repairunit이 무엇인지 판단해서 로직 다르게 ....
            /*if(repairunit.GetType() == typeof(Unit))
            {
                Unit unit = (Unit)repairunit;
                if (unit.hitpoint != unit.MAXHP) { unit.hitpoint += 5; }
             }
             else
             {
                Console.WriteLine("Command Center 입니다.");
             }*/

            if (repairunit is Unit)
            {
                Unit unit = (Unit)repairunit;  //downcasting
                if (unit.hitpoint != unit.MAXHP)
                {
                    unit.hitpoint += 5;
                }
            }
            else
            {
                Console.WriteLine("command");
            }

            /*
            if (repairunit.GetType() == typeof(CommandCenter))
            {
                Console.WriteLine("Commandcenter가 복구되었습니다.");
            }  //downcasting
            else if (repairunit.GetType() != typeof(CommandCenter))
            {
                Unit unit = (Unit)repairunit;
                if (unit.hitpoint != unit.MAXHP)
                {
                    unit.hitpoint += 5;
                }
            }*/

        }
    }

    #endregion

    class Program
    {
        static void Main(string[] args)
        {
            Child child = new Child();
            child.m();
            child.m2();
            child.move();
            Console.WriteLine(child.Count);     // property 출력

            Scv scv = new Scv();
            Tank tank = new Tank();
            tank.hitpoint = 5;
            tank.hitpoint = 0;
            scv.repair(tank);
            scv.repair(scv);
        }
    }
}
