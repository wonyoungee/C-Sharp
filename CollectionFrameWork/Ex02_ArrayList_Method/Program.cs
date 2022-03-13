using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;   // 정의하기

namespace Ex02_ArrayList_Method
{
    class Program
    {
        public static void PrintValues(IEnumerable myList)
        {
            foreach (Object obj in myList)
                Console.Write("   {0}", obj);
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            // Creates and initializes a new ArrayList.
            ArrayList myAL = new ArrayList();
            myAL.Add("The");
            myAL.Add("quick");
            myAL.Add("brown");
            myAL.Add("fox");
            myAL.Add("jumps");

            // Displays the count, capacity and values of the ArrayList.
            Console.WriteLine("Initially,");
            Console.WriteLine("   Count    : {0}", myAL.Count);
            Console.WriteLine("   Capacity : {0}", myAL.Capacity);
            Console.Write("   Values:");
            PrintValues(myAL);

            // Trim the ArrayList.
            myAL.TrimToSize(); //Count == Capacity

            // Displays the count, capacity and values of the ArrayList.
            Console.WriteLine("After TrimToSize,");
            Console.WriteLine("   Count    : {0}", myAL.Count);
            Console.WriteLine("   Capacity : {0}", myAL.Capacity);
            Console.Write("   Values:");
            PrintValues(myAL);

            // Clear the ArrayList.
            myAL.Clear(); //모든 요소를 제거합니다 (수용용량은 그대로 존재)

            // Displays the count, capacity and values of the ArrayList.
            Console.WriteLine("After Clear,");
            Console.WriteLine("   Count    : {0}", myAL.Count);
            Console.WriteLine("   Capacity : {0}", myAL.Capacity);
            Console.Write("   Values:");
            PrintValues(myAL);

            ////////////////////////////////////////////////////////////////////////
            ArrayList myAL2 = new ArrayList();
            myAL2.Insert(0, "The");
            myAL2.Insert(1, "fox");
            myAL2.Insert(2, "jumps");
            myAL2.Insert(3, "over");
            myAL2.Insert(4, "the");
            myAL2.Insert(5, "dog");
            PrintValues(myAL2);

            myAL2.Insert(1, "fox!!!!!!");
            PrintValues(myAL2);
            // 성능 안좋아요 ...
            // ArrayList 순차적인 데이터 추가 삭제시 성능을 ^^
        }
    }
}
