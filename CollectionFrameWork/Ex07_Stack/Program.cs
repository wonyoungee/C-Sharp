using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Ex07_Stack
{
    // LIFO
    //
    class MyStack
    {
        object[] items;     // 저장 구조(타입)
        int index = 0;  // 스택 배열의 위치 정보를 저장
        public MyStack() :this(100) { }
        public MyStack(int size)
        {
            items = new object[size];
        }

        public void Push(object item)
        {
            if(index > items.Length-1) { throw new InvalidOperationException("stack full"); }
            items[index] = item;
            index++;
        }
        public object Pop()
        {
            index--;
            if(index < 0) { index = 0;  throw new InvalidOperationException("stack empty"); }
            else return items[index];
        }
    }

    // Generic 클래스 만들기
    class GStack<T>
    {
        T[] items;     // 저장 구조(타입)
        int index = 0;  // 스택 배열의 위치 정보를 저장
        public GStack() : this(100) { }
        public GStack(int size)
        {
            items = new T[size];
        }

        public void Push(T item)
        {
            if (index > items.Length - 1) { throw new InvalidOperationException("stack full"); }
            items[index] = item;
            index++;
        }
        public T Pop()
        {
            index--;
            if (index < 0) { index = 0; throw new InvalidOperationException("stack empty"); }
            else return items[index];
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Stack 클래스 - c# API 제공 해주는 자원
            // 하지만 내부적인 구현방법 이해 필요...

            Stack stack = new Stack();  // c# API

            MyStack stack2 = new MyStack(); // 개발자가 직접 생산한 Stack
            stack2.Push(1);
            stack2.Push(2);
            stack2.Pop();   //return object

            int number = (int)stack2.Pop();     // Down Casting -> Bad...
            Console.WriteLine(number);

            GStack<int> gstack = new GStack<int>(3);
            gstack.Push(10);
            gstack.Push(20);
            gstack.Push(30);
            //gstack.Push(40);

            int data = gstack.Pop();    // Casting 필요 X
            Console.WriteLine(data);

        }
    }
}
