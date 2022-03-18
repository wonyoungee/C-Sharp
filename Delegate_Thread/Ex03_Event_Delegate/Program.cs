using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03_Event_Delegate
{
    delegate void onClick(string what); //델리게이트 타입(void, parameter(string)) 대리

    class TestDel
    {
        public void MouseClick(string what)
        {
            Console.WriteLine($"마우스의 {what} 버튼이 클릭");
        }
        public void KeyboardClick(string what)
        {
            Console.WriteLine($"키보드의 {what} 자판이 클릭");
        }
    }

    class Program
    {
        public event onClick myClick;   // 이벤트 onClick 델리게이트 형식을 이벤트 핸들러로 가진다.

        static void Main(string[] args)
        {
            TestDel testDel = new TestDel();
            Program m = new Program();

            m.myClick += new onClick(testDel.MouseClick);
            // myClick 이벤트 발생하면 onClick이라는 델리게이트를 통해서 등록된 이벤트 핸들러 함수를 호출.
            // 핸들러로 등록되는 함수(testDel.MouseClick)는 델리게이트(onClick)와 형식이 같아야 함.
            // m.myClick -= new onClick(testDel.MouseClick);
            m.myClick += new onClick(testDel.KeyboardClick);
            m.myClick("왼쪽");
        }
    }
}
