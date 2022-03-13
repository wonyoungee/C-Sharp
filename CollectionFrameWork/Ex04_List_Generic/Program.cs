using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04_List_Generic
{
    // ArrayList 가 Object 타입을 가지고 노는 것에 대한 반기 >> casting (반환)
    // JAVA : ArrayList<int> list = new ArrayList<int>();
    // JAVA : interface     List<int> = new List<int>();

    class Account
    {
        public string num;
        public string name;

        public Account(string num, string name)
        {
            this.num = num;
            this.name = name;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>();   // 타입 강제 : 제너릭
            //list.Add("가");    // 불가능.
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);

            foreach (int i in list)
            {
                Console.WriteLine("item : "+ i );       // 타입 캐스팅 필요X

            }

            List<bool> list2 = new List<bool>();
            list2.Add(true);
            list2.Add(false);
            Console.WriteLine(list2.Count); // 2
            list2.Clear();
            Console.WriteLine(list2.Count); // 0

            // 연습
            int[] array = { 10, 20, 30 };
            List<int> list3 = new List<int>(array);     // IEnumerable 구현하고 하위자원 올 수 있다. (다형성)
            Console.WriteLine(list3.Count);
            foreach (int i in list3)
            {
                Console.WriteLine(i);
            }

            // 사용
            List<Account> list4 = new List<Account>();
            list4.Add(new Account("111", "홍길동"));
            list4.Add(new Account("222", "김유신"));
            list4.Add(new Account("333", "이순신"));

            foreach(Account account in list4)
            {
                Console.WriteLine("번호 : "+account.num+ "이름 : " + account.name);
            }
            // 즉, 제너릭 사용하면, 타입 캐스팅 필요 X

            /* 
            foreach (Account account in list)
            {
                Console.WriteLine("번호 : {0} , 이름 : {1}", ((Account)account).num, ((Account)account).name);
            }
            */
        }
    }
}
