using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex10_Class
{
    // 클래스 == 설계도 == 데이터 타입
    class Person    // 설계라고 정의 : 최소 : 속성(고유, 상태, 부품) + 기능 ... => 객체 생성
    {
        // "속성" : 정보를 담는 그릇 (크기, 이름 필요 -> 변수)
        int num;    // 클래스가 가지는 변수 : instance variable (= member field) : 생성되는 객체마다 가지는 변수
                         // default 접근자 => private (데이터를 보호하겠다는 의지가 강함)
                         // 객체지향 언어의 특징 : 캡슐화, 은닉화 -> 자원 보호 -> private

        private int k;  // private : 클래스 내부에서는 모든 같은 식구,  but, 객체 입장에서는 볼 수 없음. (밖에서 바라보면 안 보임.)
        public int y;   // public : 모든 곳에서 open 됨.

        private string ename;

        //간접할당 : private 사용하면서 객체가 변수를 쓸 수 있게 하려면 ... => public 함수 생성 => 캡슐화된 자원에 read, write 가능해짐
        public int getK()   // 읽기전용 함수
        {
            return k;
        }
        public void setK(int data)  // 쓰기전용 함수
        {
            if(data < 0)
            {
                k = 0;
            }
            else k = data;
        }   // 설계자의 의도 : 음수 값 설정 X

        // Property : private한 member field에 대해서 간접적인 데이터 처리 목적으로 만든 것 : read / write 가능하게 만든 것
        // Java에서의 getter / setter 역할
        public int Num
        {
            get { return num; } // read
            set { num = value; }    // write
        }
        public string Ename
        {
            get { return ename + "님"; }
            set { ename = value; }
        }
    }

    class Apt
    {
        private string aptname;
        private string aptcolor;

        // 생성자 (Constructor) : 객체가 생성될 때 호출되는 함수 : member field의 "초기화"만을 목적으로 하는 함수
        // 생성자 이름 == 클래스 이름
        // member field가 먼저 memory에 올라가고 생성자 함수가 실행된다.
        public Apt()
        {
            aptname = "삼성";
            aptcolor = "red";
        }
        // 생성자 오버로딩 (함수의 이름은 같고 파라미터의 개수, 타입이 다른 것.)
        public Apt(string aptname, string aptcolor)
        {
            this.aptname = aptname;
            this.aptcolor = aptcolor;
        }

        public string Aptname
        {
            get { return aptname; }
        }
        public string Aptcolor
        {
            get { return aptcolor; }
        }
    }
    // 요구사항 : 아파트를 만들때 특별한 요구사항이 없으면 이름과 색상은 기본설정 한다. 그리고 필요시 강제로 이름과 색상을 설정할 수 있게 한다.
    // Apt apt = new Apt(); // aptname == null, aptcolor == null


    class Program
    {
        static void Main(string[] args)
        {
            //2명의 사람을 만드세요
            Person p = new Person();
            Person p2 = new Person();

            //p.num = 100;    // !!오류!! p라는 변수가 직접적으로 num이라는 변수에 접근하는 것을 막음.
            p.y = 100;  // 직접할당 -> 보호차원의 문제 발생 가능! -> 잘 쓰지 X

            p.setK(-100);   // 간접할당을 통해 k값 설정
            Console.WriteLine(p.getK());    // k값 얻어오기

            // Property (= smart field) 사용하기
            p.Num = 500;    // set {num = value;} 동작
            Console.WriteLine(p.Num);   // get {return num;} 동작
            p.Ename = "김유신";
            Console.WriteLine(p.Ename);

            Apt apt = new Apt();
            Console.WriteLine(apt.Aptname);
            Console.WriteLine(apt.Aptcolor); 

            Apt apt2 = new Apt("LG", "yellow"); // 객체를 생성하면서 동시에 초기화
            Console.WriteLine(apt2.Aptname);
            Console.WriteLine(apt2.Aptcolor);
        }
    }
}
