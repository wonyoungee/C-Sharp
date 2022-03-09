using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03_EmpLib;

namespace Ex02_Basic
{
     class Program
    {
        static void Main(string[] args)
        {
            //Ex03_EmpLib.Emp emp = new Ex03_EmpLib.Emp(); //namespace쓰기 귀찮으니까 using Ex03_EmpLib 추가.
            Emp emp = new Emp();
            Console.WriteLine(emp.GetHashCode()); //emp의 주소값 출력
            emp.Empno = 7788; //set 동작
            emp.Ename = "홍길동";
            emp.Sal = 1000;
            Console.WriteLine(emp.Empno); //get 동작
            emp.EmpPrint();
        }
    }
}
