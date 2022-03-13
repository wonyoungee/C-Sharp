using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Ex01_ArrayList
{
    class Program
    {
        public static void PrintValues(IEnumerable myList)
        {
            IList li = (IList)myList; //코드 
            Console.WriteLine("count : {0}", li.Count);

            foreach (Object obj in myList)
            {
                Console.Write("   {0}", obj);
            }
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            // Collection : 구현하고 있는 (상속) 대표적인 클래스
            // < ArrayList >
            // - 동적으로 데이터 관리
            // - using System.Collections; 아래 있는 자원
            // - 순차적인 데이터 추가 / 삭제에 유리
            // - 단점 : 중간에 데이터 삭제하거나 삽입할때 Bad

            // ArrayList 내부적으로 데이터를 Array(배열)로 관리. 
            ArrayList list = new ArrayList();
            list.Add(10);   // list 끝에 추가
            list.Add(20);
            list.Add(30);

            foreach (int i in list)
            {
                Console.WriteLine("i : "+i);
            }
            Console.WriteLine("list.Count : "+list.Count);  // list에 들어있는 값의 개수 (java : list.size())

            for(int i = 0; i < list.Count; i++)
            {
                Console.WriteLine("list : [{0}]", i);
            }

            Console.WriteLine("\nlist ArrayList");
            Console.WriteLine("Count : {0}", list.Count);
            Console.WriteLine("Capacity : {0}", list.Capacity);

            // ------------------------------------------------------------

            // Creates and initializes a new ArrayList.
            ArrayList myAL = new ArrayList();
            myAL.Add("The");
            myAL.Add("quick");
            myAL.Add("brown");
            myAL.Add("fox");
            myAL.Add("jumps");
            myAL.Add("over");
            myAL.Add("the");
            myAL.Add("lazy");
            myAL.Add("dog");

            // Displays the ArrayList.
            Console.WriteLine("The ArrayList initially contains the following:");
            PrintValues(myAL);

            // Removes the element containing "lazy".
            myAL.Remove("lazy");

            // Displays the current state of the ArrayList.
            Console.WriteLine("After removing \"lazy\":");
            PrintValues(myAL);

            // Removes the element at index 5.
            myAL.RemoveAt(5);

            // Displays the current state of the ArrayList.
            Console.WriteLine("After removing the element at index 5:");
            PrintValues(myAL);

            // Removes three elements starting at index 4.
            myAL.RemoveRange(4, 3);

            // Displays the current state of the ArrayList.
            Console.WriteLine("After removing three elements starting at index 4:");
            PrintValues(myAL);
        }


    }
 }
