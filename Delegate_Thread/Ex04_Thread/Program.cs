using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading; // 추가

namespace Ex04_Thread
{
    // 하나의 프로세스에 한개의 스레드를 동작 (지금까지)
    // 한 개의 Tread (Main() 함수 >> stack 메모리 사용)

    // 하나의 프로세스에 여러 개의 일꾼을 만들어서 사용하겠다.
    // 일꾼 (메모리로 따지면 stack . 즉, thread) 사용
    // Multi Thread 무조건 좋은 것은 X
    // 문제점 : 공유 자원 동기화(여러개의 쓰레드가 하나의 자원을 공유하는데 그 자원을 "보호" (lock) 하는 것.)
    // 동기화 보장 (lock) -> 나머지 쓰레드 대기 ... -> 성능은 좋지 않음.

    // 1. System.Threading.TreadStart 델리게이이트 (동작할 함수)
    // 2. Thread 객체를 생성하고 델리게이트 통해서 함수 등록


    class Program
    {
        public static void sPrint()
        {
            Console.WriteLine("static 함수");
        }

        public void Print()
        {
            Console.WriteLine("일반 함수");
        }

        static void Main(string[] args)
        {
            Program program = new Program();
            ThreadStart t1 = new ThreadStart(program.Print);
            ThreadStart t2 = new ThreadStart(Program.sPrint);

            Thread th = new Thread(t1);  // 스레드 생성
            Thread th2 = new Thread(t2);

            th.Start();     // stack 하나 생성 ... 그 stack에 program.Print 올려 놓고 자기(start 함수)는 종료.
            th2.Start();    // stack 하나 생성 ... 그 stack에 Program.sPrint 올려 놓고 자기(start 함수)는 종료.
            Console.WriteLine("나 메인이야 (나도 스레드)");
            // 결국 스레드 3개 만들어짐.
            //실행 시키고 실행되는 함수의 순서 보기 -> 순서 없음. 뭐가 먼저 실행될지 모름.
        }
    }
}
