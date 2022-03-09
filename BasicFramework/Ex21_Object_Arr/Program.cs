using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex21_Object_Arr
{

    // class 생성
    class Ani
    {
        private string dogname;

        public Ani() { }
        public Ani(string dogname)
        {
            this.dogname = dogname;
        }

        public void aniDisplay()
        {
            Console.WriteLine($"dogname : {dogname}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            /*** 좋지 않은 방법 ***/
            Ani[] ani = new Ani[3];     // 선언하면 heap 메모리에 Ani 타입의 방만 만든것. [방의 값은 null].
            Console.WriteLine(ani[0]);  // null 값이므로 아무것도 출력 x

            // 각 방에 값을 넣으세요 == 각 방에 Ani 타입을 갖는 주소를 넣어 주세요.
            Ani a = new Ani("멍멍이");
            Ani a2 = new Ani("발발이");
            Ani a3 = new Ani("순돌이");

            ani[0] = a;     // 주소값 전달 (Ani 타입)
            ani[1] = a2;
            ani[2] = a3;

            ani[0].aniDisplay();
            ani[1].aniDisplay();
            ani[2].aniDisplay();

            /*** 좋은 방법 ***/
            Ani[] ani2 = new Ani[3];
            ani2[0] = new Ani("멍멍이");
            ani2[1] = new Ani("발발이");
            ani2[2] = new Ani("순돌이");
            
            /*** 한번에 초기화하는 방법 ***/
            Ani[] ani3 = { new Ani("멍멍이"), new Ani("발발이"), new Ani("순돌이")};
            foreach (Ani anii in ani3)
            {
                anii.aniDisplay();
            }
        }
    }
}
