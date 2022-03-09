using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Millitary
{
    public class Millitary
    {
        protected string color;

        public Millitary(string color)
        {
            this.color = color;
        }

        public virtual void guard()
        {
            Console.WriteLine("나라를 지킨다");
        }
        public virtual void mission()
        {

        }


    }
    public class Army : Millitary
    {

        public Army() : base("녹색")
        {

        }
        public override void guard()
        {
            Console.WriteLine("육지를 지킨다");
        }
    }

    public class Navy : Millitary
    {

        public Navy() : base("흰색")
        {

        }
        public override void guard()
        {
            Console.WriteLine("바다를 지킨다");
        }
    }
    public class AirForce : Millitary
    {
        public AirForce() : base("청색")
        {

        }
        public override void guard()
        {
            Console.WriteLine("하늘을 지킨다");
        }
    }
    public class Sonar : Navy
    {
        string equipment;
        public Sonar()
        {
            equipment = "sonar";
        }
        public override void mission()
        {
            Console.WriteLine("수중 소음 접촉한다.");
            Console.WriteLine("잠수함 및 기뢰를 탐지한다.");
        }
    }
    // 조타
    public class Helmsman : Navy
    {
        int trapSize;
        public Helmsman(int trapSize)
        {
            this.trapSize = trapSize;
        }
        public override void mission()
        {
            Console.WriteLine("함정을 조종한다.");
            Console.WriteLine("기상을 관측한다.");
        }
    }
    public class artillery : Army //포병
    {
        string equipment;
        public artillery()
        {
            equipment = "poo";
        }
        public override void mission()
        {
            Console.WriteLine("포를 쏜다.");
        }
    }
    public class sapper : Army //공병
    {
        string build;
        string bomb;

        public override void mission()
        {
            Console.WriteLine("다리를 짓는다.");
            Console.WriteLine("건물을 폭파시킨다.");
        }
    }
    class Control : AirForce
    {
        int missail_Amt;
        public Control(int missail_Amt)
        {
            this.missail_Amt = missail_Amt;
        }
        public override void mission()
        {
            //base.guard();
            Console.WriteLine("상징색은 {0} 이고 전투기 미사일 {1}개로 나라를 지킨다.", this.color, this.missail_Amt);
        }
    }

    class Officialism : AirForce
    {
        int airAmt;
        public Officialism(int airSize)
        {
            this.airAmt = airSize;
        }
        public override void mission()
        {
            //base.guard();
            Console.WriteLine("상징색은 {0} 이고 비행관제 적군비행기 {1}를 감시하며 나라를 지킨다.", this.color, this.airAmt);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}

