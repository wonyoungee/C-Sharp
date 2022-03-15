using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Ex09_Generic
{
    // DTO, VO, DOMAIN 클래스 (데이터를 담을 수 있는 클래스)
    class Person
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public Person() { }
        public Person(string name, string phone, string email)
        {
            this.Name = name;
            this.Phone = phone;
            this.Email = email;
        }
        public override string ToString()
        {
            return "Name : " + Name + "Phone : " + Phone + "Email : " + Email;
        }
    }

    class PersonList : IEnumerable , IEnumerator    // '열거된 자원'에 대해서 '순차적으로 접근'하여 데이터 read
    {
        private ArrayList persons = new ArrayList();
        // private List<Person> persons = new List<Person>();
        private int pos = -1;  // 위치 디폴트값 : -1 (reset 값)

        public void Add(Person person)
        {
            persons.Add(person);
        }
        public void Add(string name, string phone, string email)
        {
            persons.Add(new Person(name, phone, email));
        }



        // override
        public IEnumerator GetEnumerator()
        {
            // IEnumerator 상속해서 구현하고, 객체의 주소를 리턴
            return this;
        }
        public object Current
        { 
            //property 구현 - get 로직 구현
            get { return persons[pos]; }
        }
        public bool MoveNext() { 
            if(pos + 1 < persons.Count)
            {
                pos++;
                return true;
            }
            else return false;
        }    // 로직구현 (bool 리턴되도록)
        public void Reset() { pos = -1; }     // 실행블럭에 초기화 작업 구현  >> 배열의 reset : -1
    }

    class Program
    {
        static void Main(string[] args)
        {
            //Person person = new Person();   // 데이터 1건 처리
            //List<Person> list = new List<Person>();     // 데이터 여러건 처리
            PersonList personlist = new PersonList();

            for(int i = 0; i<10; i++)
            {
                personlist.Add("Ne" + i, "Ph" + i, "Em" + i);
            }

            foreach(var person in personlist)
            {
                Console.WriteLine(person);  // 재정의한 person.ToString() 출력
            }

            IEnumerator ie = personlist.GetEnumerator();    // ie == personlist 객체의 주소
            while (ie.MoveNext())
            {
                Console.WriteLine(ie.Current);
            }

            ////////////////////////////////////////////////////////////////////////////
            // Dictionary<int, string> dic
            var dic = new Dictionary<int, string>()
            {
                {0, "value_0" },
                {1, "value_1" },
                {2, "value_2" }
            };  // 초기화

            for (int i = 0; i < dic.Count; i++)
            {
                Console.WriteLine("index :{0}-{1}",i,dic[i]);
            }

            // 딕셔너리 사용시 많이 쓰이는 유형. entry는 key, value 모두 담고 있음.
            foreach (var entry in dic)     
            {
                Console.WriteLine("key : {0}, value : {1}", entry.Key, entry.Value);
            }
        }
    }
}
