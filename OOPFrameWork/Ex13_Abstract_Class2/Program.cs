using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex13_Abstract_Class2
{
    abstract class EmptyCan
    {
        public int count;
        public abstract int Count   // property 강제 구현
        {
            get;    // 강제구현 -> return 구현
            set;    // 강제 구현 -> value parameter 사용 구현
        }
        public void speak()
        {
            Console.WriteLine("speak!!");
        }
        public abstract void Sound();   // 강제 구현
        public abstract void Who();     // 강제 구현
    }

    class BeerCan : EmptyCan
    {
        public override int Count {     // 추상 property 구현 
            get { return this.count; }
            set { this.count = value; }
        }
        public override void Sound()    //override
        {
            Console.WriteLine("깡깡깡 ... ");
        }
        public override void Who()
        {
            Console.WriteLine("홍길동");
        }
    }

    class CyderCan : EmptyCan
    {
        public override int Count
        {     // 추상 property 구현 
            get { return this.count; }
            set { this.count = value; }
        }
        public override void Sound()    //override
        {
            Console.WriteLine("윙윙윙 ... ");
        }
        public override void Who()
        {
            Console.WriteLine("아무개");
        }
        //필요하다면 함수 더 구현할 수 있음 (개발자 마음)
        public void where()
        {
            Console.WriteLine("공원에서 .... ");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            BeerCan beercan = new BeerCan();
            beercan.speak();
            beercan.Sound();
            beercan.Who();

            CyderCan can = new CyderCan();
            can.speak();
            can.Sound();
            can.Who();
            can.where();
        }
    }
}
