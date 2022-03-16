using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;    // 추가
using System.Runtime.Serialization.Formatters.Binary;   //추가

namespace Ex09_Serializable
{
    [Serializable]  // 직렬화 대상
    class Emp
    {
        public int empno;
        public string ename;
        [NonSerialized]
        public string job = "IT";   // 직렬화 대상 X
        public Emp(int empno, string ename) {
            this.empno = empno;
            this.ename = ename;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            /*** 직렬화한 객체를 파일에 write ***/
            Stream stream = new FileStream("emp.txt", FileMode.Create); // FileStream의 부모는 Stream임.
            BinaryFormatter formatter = new BinaryFormatter(); // 객체를 줄을 세워서 보낼 수 있게 해줌 (직렬화 과정)
            Emp emp = new Emp(9000, "홍길동"); // 객체 생성

            // 직렬화 -> write
            formatter.Serialize(stream, emp);  // emp.txt 파일에 emp 객체를 직렬화해서 write
            stream.Close();


            /*** read ***/
            //직렬화한 자원은 반드시 [역직렬화]를 통해서만 read가능!!
            // 역직렬화 안하면 다 깨짐 ...
            Stream rs = new FileStream("emp.txt", FileMode.Open);
            BinaryFormatter br = new BinaryFormatter();
            Emp empdata = (Emp)br.Deserialize(rs);     // 파일에 쓰여진 자원을 다시 조립하는 것 (원본으로).   (Emp)로 다시 캐스팅 필요!!

            Console.WriteLine(empdata.empno + ", " +empdata.ename);
            Console.WriteLine(empdata.job); // job은 직렬화 안했기 때문에 출력 안 됨.


        }
    }
}
