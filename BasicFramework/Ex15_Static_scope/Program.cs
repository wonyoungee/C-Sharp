using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex15_Static_scope
{
    public class Test
    {   // 원칙 : 클래스 내부에서는 private과 public이 같은 식구.
        private static int i;   // private : 클래스 이름으로 접근 불가. ex) Test.i (X)
        public static int j;    //  public : 클래스 이름으로 접근 가능. ex) Test.j (O)
    
        // 클래스가 일반자원과 static 자원을 다 가지고 있는 경우, 서로 교류 가능?
       
        public static void method()
        {
            i = 100;
            j = 200;
            Console.WriteLine($"Method => i : {i}, j : {j}");
         }

        // 일반함수에서 static 멤버를 가지고 놀 수 있다? (O)
        public void gMethod()
        {
            i = 111;
            j = 222;
            Console.WriteLine($"gMethod => i : {i}, j : {j}");
        }
    }
    
    class Test2
    {
        public static int sk;
        public int gk;

        public void method()
        {
            sk = 100; // static 변수 접근 가능. static이 만들어진 후 일반 자원 생성되기 때문.
            gk = 200; // 일반 변수 접근 가능.
        }

        // static 함수에서 일반 멤버 가지고 놀 수 있다? (X)
        public static void sMethod()
        {
            sk++; // static 변수 접근 가능.
            // gk++;    // !!오류!! static 함수가 먼저 생성되므로 아직 일반자원인 gk는 생성 X
        }
    }
    class Program
    {
        private static int sint;
        private int gint;

        static void Main(string[] args)
        {
            Test.method();
            //Test.gMethod(); // !!오류!! static이 아니라 new로 생성해준 후 사용 가능!
            Test t = new Test();
            t.gMethod();

            Program.sint = 100; // 클래스로 접근 가능
            Program p = new Program();
            p.gint = 100;

        }
    }
}
