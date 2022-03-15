using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Ex06_Collection
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList list = new ArrayList();
            List<string> list2 = new List<string>();

            /*** Stack (LIFO == FILO) ***/
            Stack stack = new Stack();
            stack.Push("aaa");  // object 입력 가능
            stack.Push("bbb");

            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());
            // Console.WriteLine(stack.Pop());     // 예외발생

            Stack<int> stack2 = new Stack<int>();   //제너릭 - 타입 강제
            stack2.Push(1);     // int값만 입력 가능
            stack2.Push(1);     // 값 중복 가능
            stack2.Push(3);

            /*** Queue (FIFO) ***/
            Queue queue = new Queue();
            queue.Enqueue(100); // object 입력 가능
            queue.Enqueue(200);
            queue.Enqueue(300);

            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue.Dequeue());
            // Console.WriteLine(queue.Dequeue());  // 예외발생

            Queue<string> queue2 = new Queue<string>();


            /*** Hashtable ***/
            // 순서 X
            Hashtable hashtable = new Hashtable();
            hashtable.Add("A", "사과는 맛있어");  //object 입력 가능
            hashtable.Add("B", "바나나 맛있어");
            hashtable.Add("O", "오렌지 맛있어");
            // hashtable.Add("O", "오렌지 맛있어");   // 예외발생! key값 중복 불가능!

            Console.WriteLine(hashtable.ContainsKey("O"));  // key 값의 존재 여부 확인 (true/false)
            ICollection ic = hashtable.Keys;    // Keys : property (get)가 내부적으로 new list 객체 생성하고 주소값 return
            foreach(string key in ic)
            {
                Console.WriteLine(key);
            }

            // key, value 모두를 한 번에 보려면 ...
            foreach(DictionaryEntry item in hashtable)  // DictionaryEntry : key, value 한쌍.
            {
                Console.WriteLine("key : {0}, value : {1}", item.Key, item.Value);
            }

            // Dictionary 제너릭 : key, value 타입 강제
            // 순서 X
            Dictionary<string, string> ht2 = new Dictionary<string, string>();
            ht2.Add("A", "사과는");
            ht2.Add("B", "바나나");
            ht2.Add("O", "오렌지");

            foreach(KeyValuePair<string, string> item in ht2)
            {
                Console.WriteLine("[{0} : {1}]", item.Key, item.Value);
            }

            // 이때는 주로 var 타입 사용
            foreach(var item in ht2)
            {
                Console.WriteLine("[{0} : {1}]", item.Key, item.Value);
            }

            ////////////////////////////////////////////////////////////////////////////
            /* 게시판     댓글
             1, 홍길동, 방가방가
             2, 김유신 방가
             
             댓글
             1, 1, 나도방가
             2, 1, 정말방가
             
             Dictionary<1, List<>>
            */

            // 중요한 것
            // 1. List<>
            // 2. Dictionary<int, Book>

            // SortedList : key값을 기준으로 자동 정렬
            SortedList so = new SortedList();
            SortedList<int, string> so2 = new SortedList<int, string>();
            so.Add(10, "F");
            so.Add(3, "D");
            so.Add(31, "K");
            so.Add(1, "Z");
            Console.WriteLine(so.GetKey(0));    // 0번째 key를 return
            Console.WriteLine(so.IndexOfValue("D"));
            IList sollist = so.GetKeyList();
            foreach(int i in sollist)
            {
                Console.WriteLine(i);
            }
            sollist = so.GetValueList();
            foreach(string i in sollist)
            {
                Console.WriteLine(i);
            }
        }
    }
}

/*
 *  1. ArrayList       >>  List<T>
 *  2. Stack            >>  Stack<T>
 *  3. Queue          >> Queue<T>
 *  4. HashTable    >>  Dictionary<T,V>
 *  5. SortedList    >> SortedList<T,V>
 *  6. LinkedList
 */