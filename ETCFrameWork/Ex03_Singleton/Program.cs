using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03_Singleton
{
    class Test
    {
        // 객체 안 만들고 ... static 사용
        private static Test instance;   // instance member field는 주소값 (메모리) 없음 (null) 
        // 왜 private? => public 으로 하면 null 값을 안가지므로...

        private Test()  // 싱글톤 : 객체를 한개만 생성. -> 생성자 private
        {   
            
        }
        
        public static Test getInstance()      // 유일하게 밖에서 접근 가능. (public)
        {
            if (instance == null)
            {
                instance = new Test();      // 객체 생성 (한번만!) => 클래스 내부에서는 private 생성자 호출 가능
            }
            return instance;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            // 싱글톤 : 당신이 한개의 객체만을 가지고 노는 것 (공유) 을 보장.
            // Test test = new Test();      // private 생성자 이므로 객체 new 불가!
            Test t = Test.getInstance();
            Test t2 = Test.getInstance();
            Test t3 = Test.getInstance();

            Console.WriteLine(t == t2);     // true
            Console.WriteLine(t2 == t3);    // true
            Console.WriteLine(t.GetHashCode() + "/"+t2.GetHashCode() + "/"+ t3.GetHashCode());
        }
    }
}
