using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading; // 추가

namespace Ex10_Thread_lock_wroom
{
    class Wroom
    {
        private object locker = new object();
        public void opendoor(string name)
        {
            // lock 을 걸어 동기화 보장
            //lock(this){
            lock (locker) { 
                Console.WriteLine(name + "님 화장실 입장");
                for (int i = 0; i < 100; i++)
                {
                    Console.WriteLine(name + "사용중 : " + i);
                    if (i == 10) { Console.WriteLine(name + "님 끙 ~~~~"); }
                }
                Console.WriteLine("시원하시죠 ^^!");
            }
        }
    }

    class User
    {
        Wroom wroom;
        string who;
        public User(Wroom wroom, string who)
        {
            this.wroom = wroom;
            this.who = who;
        }
        public void run()
        {
            wroom.opendoor(this.who);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // 한강 둔치
            Wroom wroom = new Wroom();  //화장실

            //사람들
            User kim = new User(wroom, "김씨");
            User park = new User(wroom, "박씨");
            User lee = new User(wroom, "이씨");

            // 배가 아파요
            // 각각을 Thread를 만들어
            Thread kimT = new Thread(new ThreadStart(kim.run));
            Thread parkT = new Thread(new ThreadStart(park.run));
            Thread leeT = new Thread(new ThreadStart(lee.run));

            kimT.Start();
            parkT.Start();
            leeT.Start();

        }
    }
}
