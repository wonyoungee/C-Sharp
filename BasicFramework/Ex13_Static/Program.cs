using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex13_Static
{
    /*
        static 자원
        1. 객체 생성 이전에 메모리에 올라가는 자원
        2. 객체를 생성하지 않고도 직접적인 접근 (사용) 가능한 자원
        3. 종류 : static class , static field(중요) , static constructor , static method(중요)
        4. static 한 단어로 : 공유자원 (단, 객체끼리)
        5. static 자원 접근 방법 ... 
     */

    public class Sample
    {
        
        public static int s; //static variable (public으로 해야 클래스 이름으로 접근 가능)
        public int i;   // instance variable (new Sample() => heap에 생성되고 사용 가능)

        public void print()
        {
            int l = 100; // local variable (함수가 호출되면 생성되고 함수가 끝나면 같이 소멸됨.)
        }

        public void printStatic()
        {
            Console.WriteLine($"static s : {s}");
        }

        /* static method
        public static void staticMethod()
        {
            // static method 를 왜 만들었을까? 얻는 이점은?
            // new 하지 않고도 사용할 수 있는 함수
            // [ 자주 사용 ] 하는 함수니까 -> [ 편하게 사용 ]
        }
        // static 자원은 성능 향상에 도움이 된다? => NO!
        // why? static의 소멸시점은 app이 종료될때이므로 data 영역의 메모리 계속 차지하기 때문.
        */
    }

    class Program
    {
        static void Main(string[] args)
        {
            // 원칙적으로는 클래스는 반드시 new를 통해서 메모리에 load 후 사용.
            // Sample sample = new Sample(); 후 사용
            // But!! s는 static 변수이기 때문에 data 영역에 load 됨. new없이 사용가능.
            Sample.s = 100; // static 자원은 클래스 이름으로 접근
           

            Sample sa = new Sample(); // 이때 생성되는 static s 는 data 영역에 있는 s를 가리킴. (공유자원)
            sa.printStatic(); // 100 출력
           // sa.s = 200; // !!오류!! C#은 참조변수로 static 자원에 접근 불가! (자바는 가능)
           // C#은 static 자원에 클래스 이름으로 접근해야함.


        }
    }
}
