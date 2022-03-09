using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03_EmpLib
{
    public class Emp
    {
        // 속성(정보저장) + 기능
        private int empno; // 접근자 private -> 캡슐화(간접접근)
        private string ename;
        private int sal;

        public Emp() //생성자 함수(디폴트) >> 목적 : 속성의 초기화
        {

        }
        public Emp(int empno, string ename, int sal) // 생성자 함수 (오버로딩:이름은 같으나 파라미터의 개수 등이 다름)
        {
            this.empno = empno;
            this.ename = ename;
            this.sal = sal;
        }

        // 속성(property)
        //캡슐화된 자원에 대하여 read, write 기능 제공 >> get / set
        public int Empno // private int empno 자원에 간접적으로 get / set을 사용하여 접근
        {
            get { return empno; }
            set { empno = value; }
        }
        public string Ename { 
            get { return ename; }
            set { ename = value; }
        }
        public int Sal 
        {
            get { return sal; }
            set { sal = value; }
        }

        public void EmpPrint() // 출력함수
        {
            Console.WriteLine("{0} - {1} - {2}", this.empno, this.ename, this.sal); //format 메소드 사용하여 출력.
        }
    }
}
